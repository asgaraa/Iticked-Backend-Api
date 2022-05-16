using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Event
{
    public class EventDto
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CategoryId { get; set; }
      
        public int HallId { get; set; }
     
    }
}
