namespace For_IT_TRENDS.Domain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Polyclinic>? Polyclinics { get; set; }
    }
}
