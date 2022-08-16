using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public interface IAcceptOrderRepository
    {
        Task<Order> SendEmail(Order order);
    }
}
