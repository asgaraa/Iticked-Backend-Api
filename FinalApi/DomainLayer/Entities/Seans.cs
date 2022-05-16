using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Seans : BaseEntity
    {
        public DateTime Morning { get; set; }
        public DateTime Afternoon { get; set; }
        public DateTime Night { get; set; }


    }
}
