using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<Group> GroupRepository { get; }
        Task SaveAsync();
    }

}
