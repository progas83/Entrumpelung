using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entrumpelung.Models
{
    public class User
    {
        public User()
        {
            this.City = "Minden";
        }
        public int ID { get; set; }
        public string UnicIdentic { get; set; }
        public string   City { get; set; }
    }
}