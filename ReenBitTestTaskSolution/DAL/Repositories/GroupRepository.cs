using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class GroupRepository : IRepository<Group>
    {
        private readonly ChatDbContext context;
        public GroupRepository(ChatDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Group entity)
        {
            _ = await context.Groups.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Group? tmp = await context.Groups.FirstOrDefaultAsync(c => c.Id == id);
            if (tmp != null)
            {
                _ = context.Groups.Remove(tmp);
            }
        }

        public IEnumerable<Group> GetAll()
        {
            return context.Groups;
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await context.Groups.FindAsync(id) ?? throw new NullReferenceException($"Model with id = {id} is not exist");
        }

        public void Update(Group model)
        {
            context.Entry(model).State = EntityState.Modified;
        }
    }
}
