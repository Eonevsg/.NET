using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}