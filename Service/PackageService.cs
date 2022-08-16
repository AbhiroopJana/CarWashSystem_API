using CarWashApi.Models;
using CarWashApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Service
{
    public class PackageService
    {
        private IPackage _IPackage;
        public PackageService(IPackage Ipackage)
        {
            _IPackage = Ipackage;
        }
        public async Task<Package> SendEmail(Package package)
        {
            return await _IPackage.SendEmail(package);
        }
    }
}
