using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class ViewCustomerService
    {
        private IViewCustomersRepository _repository;
        public ViewCustomerService(IViewCustomersRepository repository)
        {
            _repository = repository;
        }
        public List<Customer> ViewCustomersAsync()
        {
            return _repository.ViewCustomersAsync();
        }
    }
}
