﻿namespace ApplicationCore.Entities
{
	public class Subscription
	{
        public int Id { get; set; }
        public int TelegramChatId { get; set; }
        public TelegramChatEntity? TelegramChat { get; set; }
        public int SensorId { get; set; }
        public Sensor? Sensor { get; set; }
    }
}
