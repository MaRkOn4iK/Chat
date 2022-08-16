using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    internal class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
