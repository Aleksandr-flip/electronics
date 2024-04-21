using Microsoft.EntityFrameworkCore;
using Shop.interfaces;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repository
{
    //Connecting the AppDBContent file and getting data from it
    public class ServiceRepository : IAllServices
    {
        private readonly AppDBContent appDBContent;

        public ServiceRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        //We get all the data that belongs to a certain category
        public IEnumerable<Service> Services => appDBContent.Service.Include(c => c.Category);
        //Select those records whose isFavourit is true
        public IEnumerable<Service> getFavServices => appDBContent.Service.Where(p => p.isFavourit).Include(c => c.Category);
        //Select one object whose id == serviceId
        public Service getObjectService(int serviceId) => appDBContent.Service.FirstOrDefault(p => p.id == serviceId);
    }
}
