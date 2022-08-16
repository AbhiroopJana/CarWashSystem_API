using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public interface IViewWashersRepository
    {
        List<Washer> ViewWashersAsync();
    }
}
