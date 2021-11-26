using NUnit;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using Metering.Controllers;
using Metering.Services;
using Microsoft.AspNetCore.Mvc;
using Metering.Model;

namespace MeterngSystemTests

{
    class AccountsTests
    {

        private readonly CustomerAccounts _controller;
        private readonly ICustomerAccountsService _service;
        public AccountsTests()
        {
            _service = new CustomerAccountService_ForTest();
            _controller = new CustomerAccounts(_service);
        }
        [Test]
        public void ShouldReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            Assert.IsInstanceOf(typeof(List<Accounts>), okResult.Value);
            
            var _items = (List<Accounts>)okResult.Value;
            Assert.AreEqual(2, _items.Count());
            
        }
        
        [Test]
        public void ShouldReturnsAnItems()
        {
            // Act
            var okResult = _controller.Get(1002) as OkObjectResult;
            
            // Assert
            Assert.IsInstanceOf(typeof(Accounts), okResult.Value);
            var _item = (Accounts)okResult.Value;

            Assert.AreEqual("Justin", _item.FirstName); //Jeremy
        }

    }    
}
