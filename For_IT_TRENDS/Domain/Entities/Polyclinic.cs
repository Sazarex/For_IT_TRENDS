namespace For_IT_TRENDS.Domain.Entities
{
    public class Polyclinic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public ICollection<Doctor>? Doctors{ get; set; }
        public City? City { get; set; }
    }
}
