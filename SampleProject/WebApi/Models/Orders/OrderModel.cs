﻿using System;
using System.Collections.Generic;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public Guid UserId { get; set; }
        public Dictionary<Guid, int> Products { get; set; } // ProductId and Quantity
    }
}