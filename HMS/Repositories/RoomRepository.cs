using HMS.Context;
using HMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repositories
{
    public class RoomRepository
    {
        private readonly HMSDbContext _context;

        public RoomRepository(HMSDbContext dbContext)
        {
            _context = dbContext;
        }

        public bool Create(Room room)
        {
            if (room == null)
            {
                Console.WriteLine("Room Not Available");
                return false;
            }
            else
                _context.Rooms.Add(room);
                _context.SaveChanges();
                return true;
        }

        public bool CreateRooms(List<Room> rooms)
        {
            _context.Rooms.AddRange(rooms);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Room updatedRoom)
        {
            _context.Update(updatedRoom);
            _context.SaveChanges();
            return true;
        }
        public Room GetById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }
        public bool Delete(int roomId)
        {
            var room = _context.Rooms.Where(x => x.Id == roomId).SingleOrDefault();
            if(room == null)
            {
                Console.WriteLine("Room Not Found");
                return false;
            }
            else
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
                return true;
            }
        }
        public bool ChangeRoomStatus(bool isAvailable, int number)
        {
            var room = _context.Rooms.Where(c => c.Number == number).SingleOrDefault();
            if (room == null)
            {
                return false;
                Console.WriteLine("Room  Not Found");
            }
            room.isAvailable = isAvailable;
            _context.Rooms.Update(room);
            _context.SaveChanges();
           return isAvailable;
        }
        public List<Room> List()
        {
            return _context.Rooms.ToList();
        }
        public List<Room> GetByRoomStatus(bool isAvailable)
        {
             return _context.Rooms.Where(x => x.isAvailable == isAvailable).ToList();
        }
        public Room GetByRoomNumber(int number)
        {
            return _context.Rooms.Find(number);
        }
        public int GetLastRoomNumber()
        {
            return _context.Rooms.OrderBy(r => r.Number).Select(r => r.Number).LastOrDefault();
        }
    }
}
