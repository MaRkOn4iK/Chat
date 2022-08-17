namespace BLL.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreatedDate { get; set; }

        public int SenderId { get; set; }

        public int? RecipientId { get; set; } // can be null because can be send to group

        public int? GroupId { get; set; } // can be null because can be send to person

        public int? ParentMessageId { get; set; } // this prop for check if this obj is answer for other message can be null

        public bool IsDeleted { get; set; } // prop true if delete for sender ( if deleted for all users just remove from db)
    }
}
