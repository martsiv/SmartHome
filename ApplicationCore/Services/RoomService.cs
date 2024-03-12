using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
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
		public async Task AddRoomAsync(RoomDto room)
		{
			var entity = mapper.Map<Room>(room);
			await roomsRepo.InsertAsync(entity);
			await roomsRepo.SaveAsync();
		}

		public async Task<IEnumerable<RoomDto>> GetAllRoomsAsync()
		{
			var rooms = await roomsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<RoomDto>>(rooms);
		}

		public async Task<RoomDto> GetRoomByIdAsync(int roomId)
		{
			var room = await roomsRepo.GetByIDAsync(roomId);
			return mapper.Map<RoomDto>(room);
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
