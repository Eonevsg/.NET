using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFOrderDataRepository : IOrderDataRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<OrderDetail> OrderData
        {
            get { return context.OrderDetails; }
        }

        public void SaveOrderData(OrderDetail order)
        {
            if (order.OrderId == 0)
            {
                context.OrderDetails.Add(order);
            }
            else
            {
                OrderDetail dbEntry = context.OrderDetails.Find(order.OrderId);
                if (dbEntry != null)
                {
                    dbEntry.Name = order.Name;
                    dbEntry.Line1 = order.Line1;
                    dbEntry.Line2 = order.Line2;
                    dbEntry.Line3 = order.Line3;
                    dbEntry.City = order.City;
                    dbEntry.State = order.State;
                    dbEntry.Zip = order.Zip;
                    dbEntry.Country = order.Country;
                    dbEntry.DateTime = order.DateTime;

                }
            }
            context.SaveChanges();
        }
    }
}
