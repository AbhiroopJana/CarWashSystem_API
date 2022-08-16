using CarWashApi.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class AcceptOrderRepository : IAcceptOrderRepository
    {
        public Task<Order> SendEmail(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
