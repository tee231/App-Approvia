using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approovia.Data.Entities
{
    [BsonCollection("Customers")] //Customers is displayed as tb name in db
    public class Customer : Entities
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
       
    }
}
