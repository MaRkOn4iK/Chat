namespace BLL.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public ICollection<int> MessagesIds { get; set; }
    }
}
