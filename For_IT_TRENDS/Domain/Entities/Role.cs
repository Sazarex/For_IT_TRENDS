namespace For_IT_TRENDS.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; }
    }
}
