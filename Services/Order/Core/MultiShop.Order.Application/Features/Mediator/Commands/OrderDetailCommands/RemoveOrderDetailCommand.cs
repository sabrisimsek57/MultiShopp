﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public RemoveOrderDetailCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
