﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopCet47.Web.Data.Repositories;

namespace ShopCet47.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task <IActionResult> Index()
        {
            var model = await _orderRepository.GetOrderAsync(this.User.Identity.Name); // é o user que está logado no momento
            return View(model);
        }
    }
}
