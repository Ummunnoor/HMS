using HMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    public class Room: BaseEntity
    {
        public int Number { get; set; }
        public decimal Price { get; set; }
        public RoomType Type { get; set; }
        public bool isAvailable { get; set; }
    }
}
