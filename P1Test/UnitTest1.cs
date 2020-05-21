using Microsoft.AspNetCore.Mvc;
using Moq;
using Proj1.BusinessLogic;
using Proj1.Controllers;
using Proj1.Data;
using Proj1.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace P1Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task IndexShouldReturnViewWithData()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();
           
            mockRepo.Setup(x => x.GetAllCustomers())
                .Returns(new List<Customer> { new Customer { CustomerID = 1 } });


            var controller = new AdmController(mockRepo.Object, null);

            // act
            IActionResult result = await controller.Index(null, null);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            // ...that the model of the view is a CustomersViewModel
            var viewModel = Assert.IsAssignableFrom<AdmCustomerViewModel>(viewResult.Model);
            // ...that the list has one element with ID 1 (based on the MockRepo's data)
            Customer customer = Assert.Single(viewModel.Customers);
            Assert.Equal(1, customer.CustomerID);
            // we might also test that the correct view was chosen (DailyTasks/Index)

            // verify that the method was called once
        }
        /// <summary>
        /// Testing the update feature of the customer repository with regards to updating the customer
        //</summary>
        // <returns></returns>
        [Fact]
        public async Task EditRedirectsToIndex()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();
            //Setting up mock test for customer update method
            mockRepo.Setup(x => x.UpdateCustomer(new Customer { CustomerID = 1 })).Verifiable();

            var controller = new CustomerController(mockRepo.Object, null,null);

            // act
            //
            IActionResult viewResult = await controller.Edit(1);

            // assert
            // ...that the result is a ViewResult
            var viewResult1 = Assert.IsAssignableFrom<ViewResult>(viewResult);
            // ...that the model of the view is a CustomersViewModel
            //Assert.Equal("Index", viewResult1.ViewName);
        }
        [Fact]
        public async Task DeleteConfirmedRedirectsToIndex()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(x => x.DeleteCustomer(1));

            var controller = new CustomerController(mockRepo.Object, null,null);

            // act
            IActionResult result = await controller.DeleteConfirmed(1);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            // ...that the model of the view is a CustomersViewModel
            Assert.Equal("Index", viewResult.ActionName);
        }

        [Fact]
        public async Task CreateNewRedirectsToIndex()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();


            mockRepo.Setup(x => x.AddCustomer(new Customer { CustomerID = 1 }))
                .Returns(1);

            var controller = new CustomerController(mockRepo.Object, null,null);

            // act
            IActionResult result = controller.Create();

            // assert
            // ...that the result is a ViewResult
            var viewResult1 = Assert.IsAssignableFrom<ViewResult>(result);
            // ...that the model of the view is a CustomersViewModel
            //Assert.Equal("Index", viewResult1.ViewName);
        }
        [Fact]
        public async Task CreateNewRedirectsToIndexForLogin()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();
            string email = "";
            string password = "";
            mockRepo.Setup(x => x.UserLogin(email, password))
                .Returns(new Customer { CustomerID = 1 });

            var controller = new CustomerLoginController(mockRepo.Object);

            // act
            IActionResult result = controller.UserLogin(new CustomerLoginModel { EmailID = "asd@dhf.co", Password = "askffd" });

            // assert
            // ...that the result is a ViewResult
            var viewResult1 = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            // ...that the model of the view is a CustomersViewModel
            //Assert.Equal("Index", viewResult1.ViewName);
        }

        [Fact]
        public async Task CreateRedirectsToIndexForLogin()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();
            string email = "";
            string password = "";
            mockRepo.Setup(x => x.UserLogin(email, password))
                .Returns(new Customer { CustomerID = 1 });

            var controller = new CustomerLoginController(mockRepo.Object);

            // act
            IActionResult result = controller.UserLogin(new CustomerLoginModel { EmailID = "asd@dhf.co", Password = "askffd" });

            // assert
            // ...that the result is a ViewResult
            var viewResult1 = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            // ...that the model of the view is a CustomersViewModel
            //Assert.Equal("Index", viewResult1.ViewName);
        }
        [Fact]
        public async Task DeleteRedirectsToIndex()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(x => x.DeleteCustomer(1));

            var controller = new CustomerController(mockRepo.Object, null, null);

            // act
            IActionResult result = await controller.DeleteConfirmed(1);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            // ...that the model of the view is a CustomersViewModel
            Assert.Equal("Index", viewResult.ActionName);
        }
        [Fact]
        public async Task CustomerRedirectsToIndex()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(x => x.DeleteCustomer(1));

            var controller = new CustomerController(mockRepo.Object, null, null);

            // act
            IActionResult result = await controller.DeleteConfirmed(1);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            // ...that the model of the view is a CustomersViewModel
            Assert.Equal("Index", viewResult.ActionName);
        }
        [Fact]
        public async Task AdmShouldReturnViewWithData()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(x => x.GetAllCustomers())
                .Returns(new List<Customer> { new Customer { CustomerID = 1 } });


            var controller = new AdmController(mockRepo.Object, null);

            // act
            IActionResult result = await controller.Index(null, null);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            // ...that the model of the view is a CustomersViewModel
            var viewModel = Assert.IsAssignableFrom<AdmCustomerViewModel>(viewResult.Model);
            // ...that the list has one element with ID 1 (based on the MockRepo's data)
            Customer customer = Assert.Single(viewModel.Customers);
            Assert.Equal(1, customer.CustomerID);
            // we might also test that the correct view was chosen (DailyTasks/Index)

            // verify that the method was called once
        }

        [Fact]
        public async Task OrderShouldReturnViewWithData()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(x => x.GetAllCustomers())
                .Returns(new List<Customer> { new Customer { CustomerID = 1 } });


            var controller = new AdmController(mockRepo.Object, null);

            // act
            IActionResult result = await controller.Index(null, null);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            // ...that the model of the view is a CustomersViewModel
            var viewModel = Assert.IsAssignableFrom<AdmCustomerViewModel>(viewResult.Model);
            // ...that the list has one element with ID 1 (based on the MockRepo's data)
            Customer customer = Assert.Single(viewModel.Customers);
            Assert.Equal(1, customer.CustomerID);
            // we might also test that the correct view was chosen (DailyTasks/Index)

            // verify that the method was called once
        }
        [Fact]
        public async Task StoreShouldReturnViewWithData()
        {
            // arrange
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(x => x.GetAllCustomers())
                .Returns(new List<Customer> { new Customer { CustomerID = 1 } });


            var controller = new AdmController(mockRepo.Object, null);

            // act
            IActionResult result = await controller.Index(null, null);

            // assert
            // ...that the result is a ViewResult
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            // ...that the model of the view is a CustomersViewModel
            var viewModel = Assert.IsAssignableFrom<AdmCustomerViewModel>(viewResult.Model);
            // ...that the list has one element with ID 1 (based on the MockRepo's data)
            Customer customer = Assert.Single(viewModel.Customers);
            Assert.Equal(1, customer.CustomerID);
            // we might also test that the correct view was chosen (DailyTasks/Index)

            // verify that the method was called once
        }

    }
}
