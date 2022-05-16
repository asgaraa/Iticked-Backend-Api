using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Event:BaseEntity
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
