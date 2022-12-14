using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Person")]
        public int SenderId { get; set; }
        public virtual Person Sender { get; set; }

        [ForeignKey("Person")]
        public int? RecipientId { get; set; } // can be null because can be send to group
        public virtual Person Recipient { get; set; }

        [ForeignKey("Group")]
        public int? GroupId { get; set; } // can be null because can be send to person
        public virtual Person Group { get; set; }

        public Message ParentMessage { get; set; } // this prop for check if this obj is answer for other message

        public bool IsDeleted { get; set; } // prop true if delete for sender ( if deleted for all users just remove from db)
    }
}
