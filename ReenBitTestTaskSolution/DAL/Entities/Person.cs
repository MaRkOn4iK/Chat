namespace DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
