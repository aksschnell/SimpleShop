﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShodModels
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }

        public OrderStatus(int id, string name)
        {
            OrderStatusId = id;
            OrderStatusName = name;

        }
    }
}
