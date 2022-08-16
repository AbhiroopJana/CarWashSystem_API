using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class OrderService
    {
        private IOrderRepository _IOrder;
        public OrderService(IOrderRepository _order)
        {
            _IOrder = _order;
        }


        public async Task<Order> SendEmail(Order order)
        {
            return await _IOrder.SendEmail(order);
        }
    }
}
