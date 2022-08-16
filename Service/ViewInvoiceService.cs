using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class ViewInvoiceService
    {
        private IViewInvoiceRepository _repository;
        public ViewInvoiceService(IViewInvoiceRepository repository)
        {
            _repository = repository;
        }
        public List<Invoice> ViewInvoice(string email)
        {
            return _repository.ViewInvoiceAsync(email);
        }
    }
}
