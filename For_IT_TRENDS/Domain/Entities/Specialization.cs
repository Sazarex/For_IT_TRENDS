namespace For_IT_TRENDS.Domain.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        
    }
}
