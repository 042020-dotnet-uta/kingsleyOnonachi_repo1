using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProject1.BusinessLogic;
using MvcProject1.Data;
using MvcProject1.DataLogic;
using MvcProject1.Models;

namespace MvcProject1.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IProductRepository _productRepository;
        private readonly MvcProject1Context _context;

        public InventoryController(MvcProject1Context context, IStoreRepository storeRepository, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _storeRepository = storeRepository;
            
        }

        // GET: Inventory
        public IActionResult Index(string Name, string Description, string SearchString)
        {
            var products = _productRepository.GetAllProducts();
            var stores = _storeRepository.GetAllStore();

            foreach(var item in stores)
            {
                Console.WriteLine(item.CityAddress);
            }
            if (Description != null)
            {
                var productDes = _productRepository.GetProductByDescription(Description);
            }
            var InventoryViewModel = new InventoryViewModel
            {
                Products = products.ToList(),
                StoreLocation = new SelectList(stores),

            };

            return View(InventoryViewModel);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed) 
        {
            return $"From [HttpPost] Index Action Method: filtered on the substring, {searchString}";
        }
        // GET: Inventory/Details/5
        public IActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            int Id = id.Value;
            var product = _productRepository.GetProductById(Id);


            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("InventoryID,Name,Description,SearchString")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProductToStore(inventory);
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int Id = id.Value;
            var product = _productRepository.GetProductById(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
           
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("InventoryID,Name,Description,SearchString")] Inventory inventory)
        {
            if (id != inventory.InventoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var product = _productRepository.GetProductById(id);
                    var inventoryView = _productRepository.UpdateProductInfo(product);
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;
                }
               
            }
            return RedirectToAction(nameof(Index));
        } 

        // GET: Inventory/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int Id = id.Value;
            var inventory = _productRepository.GetProductById(Id);
               
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var inventory = _productRepository.GetProductById(id);
            _productRepository.DeleteProduct(inventory);

            return RedirectToAction(nameof(Index));
        }

    }
}
