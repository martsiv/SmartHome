using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class RoomService : IRoomService
	{
		private readonly IMapper mapper;
		private readonly IRepository<Room> roomsRepo;
        public RoomService(IMapper mapper,
						IRepository<Room> roomsRepo)
        {
            this.mapper = mapper;
			this.roomsRepo = roomsRepo;
        }

		public void AddRoom(RoomDto room)
		{
			var entity = mapper.Map<Room>(room);
			roomsRepo.Insert(entity);
			roomsRepo.Save();
		}

		public async Task AddRoomAsync(RoomDto room)
		{
			var entity = mapper.Map<Room>(room);
			await roomsRepo.InsertAsync(entity);
			await roomsRepo.SaveAsync();
		}

		public IEnumerable<RoomDto> GetAllRooms()
		{
			var rooms = roomsRepo.GetAll();
			return mapper.Map<IEnumerable<RoomDto>>(rooms);
		}

		public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
		{
			var rooms = await roomsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<RoomDto>>(rooms);
		}

		public RoomDto? GetRoomById(int roomId)
		{
			var entity = roomsRepo.GetByID(roomId);
			if (entity == null) return null;
			return mapper.Map<RoomDto>(entity);
		}

		public async Task<RoomDto?> GetRoomByIdAsync(int roomId)
		{
			var entity = await roomsRepo.GetByIDAsync(roomId);
			if (entity == null) return null;
			return mapper.Map<RoomDto>(entity);
		}

		public void RemoveRoom(int roomId)
		{
			var room = roomsRepo.GetByID(roomId);
			if (room != null)
			{
				roomsRepo.Delete(roomId);
				roomsRepo.Save();
			}
		}

		public async Task RemoveRoomAsync(int roomId)
		{
			var room = await roomsRepo.GetByIDAsync(roomId);
			if (room != null)
			{
				await roomsRepo.DeleteAsync(roomId);
				await roomsRepo.SaveAsync();
			}
		}

		public void UpdateRoom(int roomId, RoomDto room)
		{
			var existingRoom = roomsRepo.GetByID(roomId);
			if (existingRoom != null)
			{
				mapper.Map(room, existingRoom);
				roomsRepo.Update(existingRoom);
				roomsRepo.Save();
			}
		}

		public async Task UpdateRoomAsync(int roomId, RoomDto room)
		{
			var existingRoom = await roomsRepo.GetByIDAsync(roomId);
			if (existingRoom != null)
			{
				mapper.Map(room, existingRoom);
				roomsRepo.Update(existingRoom);
				await roomsRepo.SaveAsync();
			}
		}
	}
}
