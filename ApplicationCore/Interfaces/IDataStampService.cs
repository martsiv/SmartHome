using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Interfaces
{
	public interface IDataStampService
	{
		Task AddDataStampAsync(CreateDataStampModel createDataStamp);
		Task<IEnumerable<GetDataStampModel>> GetAllDataStampsAsync();
		Task<IEnumerable<GetDataStampModel>> GetAllDataStampsBySensorAsync(int sensorId);
		Task<IEnumerable<GetDataStampModel>> GetAllDataStampsByDateAsync(DateTime dateTime);
	}
}
