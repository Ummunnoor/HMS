using HMS.Entities;
using HMS.Models.DTOs;
using HMS.Repositories;

namespace HMS.Services
{
    public class RoomService
    {
        private readonly RoomRepository _repository;

        public RoomService(RoomRepository repository)
        {
            _repository = repository;
        }

        public void Create(CreateRoomDto createRoomDto)
        {
            var room = new Room()
            {
                Type = createRoomDto.Type,
                Number = createRoomDto.Number,
                Price = createRoomDto.Price,
                isAvailable = createRoomDto.isAvailable,
            };
            var response = _repository.Create(room);
            if (response)
            {
                Console.WriteLine("Room Created Successfully");
            }
            else
            {
                Console.WriteLine("Room Create Failed");
            }
        }

        public void Update(int roomNumber, UpdateRoomDto updateRoomDto)
        {
            var room = _repository.GetByRoomNumber(roomNumber);
            if (room == null)
            {
                Console.WriteLine("Room not found");
            }
            else
            {
                room.Type = updateRoomDto.Type;
                room.Price = updateRoomDto.Price;
                var response = _repository.Update(room);
                if (response)
                {
                    Console.WriteLine("Update Succcessful");
                }
                else
                {
                    Console.WriteLine("Update Unsucccessful");
                }
                
            }
        }

        public void GenerateRooms(int numberOfRooms, GenerateRoomsDto generateRoomsDto)
        {
            var room = new List<Room>();
            var lastRoomNumber = _repository.GetLastRoomNumber();
            for(int roomNumber = lastRoomNumber + 1; roomNumber <= (numberOfRooms + lastRoomNumber); roomNumber++)
            {
                room.Add(new Room()
                {
                    Number = roomNumber,
                    isAvailable = true,
                    Price = generateRoomsDto.Price,
                    Type = generateRoomsDto.Type,
                });
            }
            var response = _repository.CreateRooms(room);
            if (response)
            {
                Console.WriteLine("Rooms Generated Successfully");
            }
            else
            {
                Console.WriteLine("Generation Unsuccessful");
            }
        }

        public List<GetRoomDto> GetAll()
        {
            var rooms = _repository.List();
            return rooms.Select(room => new GetRoomDto
            {
                Type = room.Type,
                Number = room.Number,
                isAvailable = room.isAvailable,
                Price = room.Price,
            }).ToList();

        }

        public GetRoomDto Find(int roomNumber)
        {
            var room = _repository.GetByRoomNumber(roomNumber);
            return new GetRoomDto
            {
                Type = room.Type,
                Number = room.Number,
                isAvailable = room.isAvailable,
                Price = room.Price,
            };
        }
    }
}
