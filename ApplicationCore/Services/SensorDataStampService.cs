﻿using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using System;

namespace ApplicationCore.Services
{
	public class SensorDataStampService : ISensorDataStampService
	{
		private readonly IMapper mapper;
		private readonly IRepository<SensorDataStamp> sensorDataStampsRepo;
        public SensorDataStampService(IMapper mapper,
							IRepository<SensorDataStamp> sensorDataStampsRepo)
        {
            this.mapper = mapper;
			this.sensorDataStampsRepo = sensorDataStampsRepo;
        }

		public void AddSensorDataStamp(SensorDataStampDto sensorDataStamp)
		{
			var entity = mapper.Map<SensorDataStamp>(sensorDataStamp);
			sensorDataStampsRepo.Insert(entity);
			sensorDataStampsRepo.Save();
		}

		public async Task AddSensorDataStampAsync(SensorDataStampDto sensorDataStamp)
		{
			var entity = mapper.Map<SensorDataStamp>(sensorDataStamp);
			await sensorDataStampsRepo.InsertAsync(entity);
			await sensorDataStampsRepo.SaveAsync();
		}

		public IEnumerable<SensorDataStampDto> GetAllSensorDataStamps()
		{
			var sensorDataStamps = sensorDataStampsRepo.GetAll();
			return mapper.Map<IEnumerable<SensorDataStampDto>>(sensorDataStamps);
		}

		public async Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsAsync()
		{
			var sensorDataStamps = await sensorDataStampsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SensorDataStampDto>>(sensorDataStamps);
		}

		public IEnumerable<SensorDataStampDto> GetAllSensorDataStampsByDate(DateTime dateTime)
		{
			var sensorDataStamps = sensorDataStampsRepo.GetListBySpec(new SensorDataStampSpecs.ByDate(dateTime));
			return mapper.Map<IEnumerable<SensorDataStampDto>>(sensorDataStamps);
		}

		public async Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsByDateAsync(DateTime dateTime)
		{
			var sensorDataStamps = await sensorDataStampsRepo.GetListBySpecAsync(new SensorDataStampSpecs.ByDate(dateTime));
			return mapper.Map<IEnumerable<SensorDataStampDto>>(sensorDataStamps);
		}

		public IEnumerable<SensorDataStampDto> GetAllSensorDataStampsBySensor(int sensorId)
		{
			var sensorDataStamps = sensorDataStampsRepo.GetListBySpec(new SensorDataStampSpecs.BySensor(sensorId));
			return mapper.Map<IEnumerable<SensorDataStampDto>>(sensorDataStamps);
		}

		public async Task<IEnumerable<SensorDataStampDto>> GetAllSensorDataStampsBySensorAsync(int sensorId)
		{
			var sensorDataStamps = await sensorDataStampsRepo.GetListBySpecAsync(new SensorDataStampSpecs.BySensor(sensorId));
			return mapper.Map<IEnumerable<SensorDataStampDto>>(sensorDataStamps);
		}

		public async Task<HttpResponseMessage> GetNewDataStamsAsync(SensorDto sensor)
		{
			using (var client = new HttpClient())
			{
				string url = $"http://{sensor.SensorIP}/getNewValues";
				HttpResponseMessage response = await client.GetAsync(url);
				return response;
			}
		}

		public SensorDataStampDto? GetLastSensorDataStampByDate(DateTime dateTime)
		{
			var entity = sensorDataStampsRepo.GetItemBySpec(new SensorDataStampSpecs.ByDate(dateTime));
			if (entity == null) return null;
			return mapper.Map<SensorDataStampDto>(entity);
		}

		public async Task<SensorDataStampDto?> GetLastSensorDataStampByDateAsync(DateTime dateTime)
		{
			var entity = await sensorDataStampsRepo.GetItemBySpecAsync(new SensorDataStampSpecs.ByDate(dateTime));
			if (entity == null) return null;
			return mapper.Map<SensorDataStampDto>(entity);
		}

		public SensorDataStampDto? GetSensorDataStampById(int sensorDataStampId)
		{
			var entity = sensorDataStampsRepo.GetByID(sensorDataStampId);
			if (entity == null) return null;
			return mapper.Map<SensorDataStampDto>(entity);
		}

		public async Task<SensorDataStampDto?> GetSensorDataStampByIdAsync(int sensorDataStampId)
		{
			var entity = await sensorDataStampsRepo.GetByIDAsync(sensorDataStampId);
			if (entity == null) return null;
			return mapper.Map<SensorDataStampDto>(entity);
		}

		public void RemoveSensorDataStamp(int sensorDataStampId)
		{
			var entity = sensorDataStampsRepo.GetByID(sensorDataStampId);
			if (entity != null)
			{
				sensorDataStampsRepo.Delete(sensorDataStampId);
				sensorDataStampsRepo.Save();
			}
		}

		public async Task RemoveSensorDataStampAsync(int sensorDataStampId)
		{
			var entity = await sensorDataStampsRepo.GetByIDAsync(sensorDataStampId);
			if (entity != null)
			{
				await sensorDataStampsRepo.DeleteAsync(sensorDataStampId);
				await sensorDataStampsRepo.SaveAsync();
			}
		}

		public void UpdateSensorDataStamp(int sensorDataStampId, SensorDataStampDto sensorDataStampDto)
		{
			var existingEntity = sensorDataStampsRepo.GetByID(sensorDataStampId);
			if (existingEntity != null)
			{
				mapper.Map(sensorDataStampDto, existingEntity);
				sensorDataStampsRepo.Update(existingEntity);
				sensorDataStampsRepo.Save();
			}
		}

		public async Task UpdateSensorDataStampAsync(int sensorDataStampId, SensorDataStampDto sensorDataStampDto)
		{
			var existingEntity = await sensorDataStampsRepo.GetByIDAsync(sensorDataStampId);
			if (existingEntity != null)
			{
				mapper.Map(sensorDataStampDto, existingEntity);
				sensorDataStampsRepo.Update(existingEntity);
				await sensorDataStampsRepo.SaveAsync();
			}
		}
	}
}
