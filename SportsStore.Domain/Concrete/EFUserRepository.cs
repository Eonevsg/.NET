using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.Id == 0)
            {
                context.Users.Add(user);
            }
            else
            {
                User dbEntry = context.Users.Find(user.Id);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = user.FirstName;
                    dbEntry.LastName = user.LastName;
                    dbEntry.Username = user.Username;
                    dbEntry.Password = user.Password;
                    dbEntry.Email = user.Email;
                    dbEntry.RetypeEmail = user.RetypeEmail;
                    dbEntry.Phone = user.Phone;
                    dbEntry.Age = user.Age;
                    dbEntry.City = user.City;
                    dbEntry.Address = user.Address;
                    dbEntry.DateOfBirth = user.DateOfBirth;
                    
                }
            }
            context.SaveChanges();
        }
    }
}
