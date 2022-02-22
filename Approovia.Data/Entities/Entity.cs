using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approovia.Data.Entities
{
    public class Entity<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public T Id { get; set; }
       
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        
    }
}
