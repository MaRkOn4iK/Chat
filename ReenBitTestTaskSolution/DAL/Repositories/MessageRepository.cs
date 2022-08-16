using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class MessageRepository : IRepository<Message>
    {
        private ChatDbContext context;
        public MessageRepository(ChatDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Message entity)
        {
            await this.context.Messages.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var tmp = await this.context.Messages.FirstOrDefaultAsync(c => c.Id == id);
            if (tmp != null)
            {
                this.context.Messages.Remove(tmp);
            }
        }

        public IEnumerable<Message> GetAll()
        {
            return context.Messages;
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await context.Messages.FindAsync(id) ?? throw new NullReferenceException($"Model with id = {id} is not exist");
        }

        public void Update(Message model)
        {
            context.Entry(model).State = EntityState.Modified;
        }
    }
}
