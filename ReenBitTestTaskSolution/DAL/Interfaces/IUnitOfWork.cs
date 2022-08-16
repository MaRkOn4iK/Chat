using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IUnitOfWork
    {
        IRepository<Person> PersonRepository { get; }
        IRepository<Message> MessageRepository { get; }
        IRepository<Group> GroupRepository { get; }
        Task SaveAsync();
    }

}
