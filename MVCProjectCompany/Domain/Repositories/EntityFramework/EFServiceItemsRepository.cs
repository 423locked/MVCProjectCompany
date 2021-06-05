using Microsoft.EntityFrameworkCore;
using MVCProjectCompany.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProjectCompany.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository
    {
        public readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get a collection of ServiceItem entities from the context.
        /// </summary>
        /// <returns>An IQueryable collection of ServiceItem instances</returns>
        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        /// <summary>
        /// Get a particular service by its ID.
        /// </summary>
        /// <param name="id">Guid unique id</param>
        /// <returns>ServiceItem instance</returns>
        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Create/Update a service.
        /// </summary>
        /// <param name="service">ServiceItem instance</param>
        public void SaveServiceItem(ServiceItem service)
        {
            if (service.Id == default) //new service
                context.Entry(service).State = EntityState.Added;
            else
                context.Entry(service).State = EntityState.Modified;

            context.SaveChanges();
        }

        /// <summary>
        /// Delete a particular service item by its ID.
        /// </summary>
        /// <param name="id">Guid unique id</param>
        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem { Id = id });
            context.SaveChanges();
        }
    }
}
