using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.interfaces
{
    public interface IAllServices
    {
        //The function returns a list of all services
        IEnumerable<Service> Services { get;}
        //The function returns a list of selected services
        IEnumerable<Service> getFavServices { get; }
        //The function returns a specific service by its id
        Service getObjectService(int serviceId);

    }
}
