namespace DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
