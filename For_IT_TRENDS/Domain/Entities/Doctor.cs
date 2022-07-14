namespace For_IT_TRENDS.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public ICollection<Specialization> Specializations { get; set; }
        public ICollection<Polyclinic> Polyclinics { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public string Desc { get; set; }
        public string FullDesc { get; set; }

    }
}
