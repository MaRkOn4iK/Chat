namespace BLL.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public ICollection<int> MessagesIds { get; set; }
    }
}
