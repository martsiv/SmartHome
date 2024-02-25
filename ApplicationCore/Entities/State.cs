namespace ApplicationCore.Entities
{
	public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sensor> Sensors { get; set; } = new HashSet<Sensor>();
    }
}
