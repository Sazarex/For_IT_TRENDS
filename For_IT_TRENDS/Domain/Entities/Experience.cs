namespace For_IT_TRENDS.Domain.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        public Specialization Specialization { get; set; }
        public Doctor Doctor{ get; set; }
        public DateTime TimeInSpecialization { get; set; }
    }
}
