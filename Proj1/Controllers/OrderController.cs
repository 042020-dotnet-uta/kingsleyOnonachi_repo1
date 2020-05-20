using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proj1.BusinessLogic;
using Proj1.Data;
using Proj1.Helpers;
using Proj1.Models;

namespace Proj1.Controllers
{
    public class OrderController : Controller
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IOrderListRepository _orderListRepository;
        public readonly ICustomerRepository _customerRepository;
        public readonly IProductRepository _productRepository;
        public readonly IStoreRepository _storeRepository;
        public OrderController(IOrderRepository _orderRepository, IOrderListRepository _orderListRepository, 
            ICustomerRepository _customerRepository, IProductRepository _productRepository, IStoreRepository _storeRepository)
        {
            this._orderRepository = _orderRepository;
            this._orderListRepository = _orderListRepository;
            this._customerRepository = _customerRepository;
            this._productRepository = _productRepository;
            this._storeRepository = _storeRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orderViews = new List<OrderViewModel>();
            var orders = await _orderRepository.GetAllOrders();
            foreach (var order in orders)
            {
                orderViews.Add(new OrderViewModel
                {
                    Order = order
                });
            }

            return View(orderViews);
        }


        public async Task<IActionResult> Details(int? id)
        {
            //if (model == null)
            //{
            //    return NotFound();
            //}
            var order = await _orderListRepository.GetOrderlists(id.Value);

            if (order == null)
            {
                return NotFound();
            }
            //model = new OrderListViewModel
            //{
            //    Customer = Customer,

            //};
            //foreach (var item in order.Orderlist)
            //{
            //    model.LineItems.Add(
            //        new LineItemViewModel
            //        {
            //           OrderList  = item
            //        });
            //}

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create(int? storeId, int? SelectedProduct, int? SelectedQuantity)
        {
            var customer = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "Customer");

            if (customer == null)
            {
                return NotFound();
            }
            var createOrder = new NewOrderViewModel
            {
                Customer = customer
            };

            if (storeId == null)
                storeId = SessionHelper.GetObjectFromJson<int?>(HttpContext.Session, "SelectedStore");
            else
                SessionHelper.SetObjectAsJson(HttpContext.Session, "SelectedStore", storeId);

            var stores = await _storeRepository.GetAllStore();
            createOrder.StoreLocations = new SelectList(stores, "StoreId", "Location");

            if (SelectedProduct != null)
                AddProductToOrder(SelectedProduct.Value, SelectedQuantity.Value);

            if (storeId != null)
            {
                var store = await _storeRepository.GetStoreById(storeId.Value);
                if (null == store)
                    return NotFound();
                createOrder.SelectedStore = store;

                var cart = SessionHelper.GetObjectFromJson<List<LineItemViewModel>>(HttpContext.Session, "cart");
                createOrder.SelectedProducts = cart == null ? new List<LineItemViewModel>() : cart;
            }

            return View(createOrder);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            if (ModelState.IsValid)
            {
                var newOrder = CreateOrder();
                var model = new OrderListViewModel
                {
                    OrderID = newOrder.OrderID
                };

                //Clear the session information
                SessionHelper.SetObjectAsJson(HttpContext.Session, "SelectedStore", null);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", null);

                return RedirectToAction(nameof(OrderList), model);
            }
            return RedirectToAction(nameof(Create));
        }

        private Order CreateOrder()
        {
            var customer = SessionHelper.GetObjectFromJson<Customer>(HttpContext.Session, "Customer");
            var storeId = SessionHelper.GetObjectFromJson<int?>(HttpContext.Session, "SelectedStore");
            var cart = SessionHelper.GetObjectFromJson<List<LineItemViewModel>>(HttpContext.Session, "cart");
            List<OrderList> details = new List<OrderList>();
            foreach (var item in cart)
            {
                item.OrderList.Product = null;
                details.Add(item.OrderList);
            }

            var order = new Order
            {
                CustomerID = customer.CustomerID,
                Customer = null,
                StoreID = storeId.Value,
                Store = null,//_unitOfWork.StoreRepository.Get(storeId).Result,
                Orderlist = details,
                OrderDate = DateTime.Now
            };

            _orderRepository.AddOrder(order);

            return order;
        }

        private async void AddProductToOrder(int SelectedProduct, int SelectedQuantity)
        {
            var product = await _productRepository.GetProductById(SelectedProduct);

            var cart = SessionHelper.GetObjectFromJson<List<LineItemViewModel>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                cart = new List<LineItemViewModel>();

                cart.Add(new LineItemViewModel
                {
                    OrderList = new OrderList
                    {
                        InventoryID = product.InventoryID,
                        Product = product,
                        Price = product.ListPrice,
                        Quantity = SelectedQuantity
                    }

                }); ;
            }
            else
            {
                int index = isExist(SelectedProduct);
                if (index != -1)
                {
                    cart[index].OrderList.Quantity += SelectedQuantity;
                }
                else
                {
                    cart.Add(new LineItemViewModel
                    {
                        OrderList = new OrderList
                        {
                            InventoryID = product.InventoryID,
                            Product = product,
                            Price = product.ListPrice,
                            Quantity = SelectedQuantity
                        }

                    });
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            //return RedirectToAction("Create");
        }
        private int isExist(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<LineItemViewModel>>(HttpContext.Session, "cart");

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].OrderList.InventoryID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderById(id.Value);//_context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            //ViewData["CusomerId"] = new SelectList(customerRepo.All().Result, "CustomerId", "CustomerId", order.CusomerId);
            //ViewData["StoreId"] = new SelectList(storeRepo.All().Result, "StoreId", "StoreId", order.StoreId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CusomerId,StoreId,OrderDateTime")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //_context.Update(order);
                //await _context.SaveChangesAsync();
                order = await _orderRepository.UpdateOrder(order);
                /*
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                */
                return RedirectToAction(nameof(Index));
            }
            
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderById(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _orderRepository.d(id);

        //    return RedirectToAction(nameof(Index));
        //}
    }
}