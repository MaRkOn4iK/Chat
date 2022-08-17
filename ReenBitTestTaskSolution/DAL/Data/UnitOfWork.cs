using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatDbContext _context;
        private IRepository<Person> _personRepository;
        private IRepository<Message> _messageRepository;
        private IRepository<Group> _groupRepository;
        public IRepository<Person> PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new PersonRepository(_context);
                }

                return _personRepository;
            }
        }

        public IRepository<Message> MessageRepository
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(_context);
                }

                return _messageRepository;
            }
        }

        public IRepository<Group> GroupRepository
        {
            get
            {
                if (_groupRepository == null)
                {
                    _groupRepository = new GroupRepository(_context);
                }

                return _groupRepository;
            }
        }

        public UnitOfWork(ChatDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            _ = await _context.SaveChangesAsync();
        }
    }
}
