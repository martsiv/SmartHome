namespace ApplicationCore.Entities
{
	public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
    }
}
