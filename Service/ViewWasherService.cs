using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class ViewWasherService
    {
        private IViewWashersRepository _repository;
        public ViewWasherService(IViewWashersRepository repository)
        {
            _repository = repository;
        }
        public List<Washer> ViewWashersAsync()
        {
            return _repository.ViewWashersAsync();
        }
    }
}
