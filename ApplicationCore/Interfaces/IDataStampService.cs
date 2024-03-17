using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Interfaces
{
	public interface IDataStampService
	{
		void AddDataStamp(CreateDataStampModel createDataStamp);
		IEnumerable<GetDataStampModel> GetAllDataStamps();
		IEnumerable<GetDataStampModel> GetAllDataStampsBySensor(int sensorId);
		IEnumerable<GetDataStampModel> GetAllDataStampsByDate(DateTime dateTime);
		GetDataStampModel? GetLastDataStampByDate(DateTime dateTime);
		GetDataStampModel? GetDataStampById(int id);
		Task AddDataStampAsync(CreateDataStampModel createDataStamp);
		Task<IEnumerable<GetDataStampModel>> GetAllDataStampsAsync();
		Task<IEnumerable<GetDataStampModel>> GetAllDataStampsBySensorAsync(int sensorId);
		Task<IEnumerable<GetDataStampModel>> GetAllDataStampsByDateAsync(DateTime dateTime);
		Task<GetDataStampModel?> GetLastDataStampByDateAsync(DateTime dateTime);
		Task<GetDataStampModel?> GetDataStampByIdAsync(int id);
	}
}
