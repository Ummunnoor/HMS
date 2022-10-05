using HMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.DTOs
{
    public class CreateRoomDto
    {
        public int Number { get; set; }
        public decimal Price { get; set; }
        public RoomType Type { get; set; }
        public bool isAvailable { get; set; }
    }

    public class GenerateRoomsDto
    {
        public decimal Price { get; set; }
        public RoomType Type { get; set; }
        public bool isAvailable { get; set; }
    }

    public class UpdateRoomDto
    {
        public decimal Price { get; set; }
        public RoomType Type { get; set; }
    }

    public class GetRoomDto
    {
        public int Number { get; set; }
        public decimal Price { get; set; }
        public RoomType Type { get; set; }
        public bool isAvailable { get; set; }
    }
}
