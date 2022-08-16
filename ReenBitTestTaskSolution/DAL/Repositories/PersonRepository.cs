using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    internal class PersonRepository : IRepository<Person>
    {
        private readonly ChatDbContext context;
        public PersonRepository(ChatDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(Person entity)
        {
            _ = await context.People.AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Person? tmp = await context.People.FirstOrDefaultAsync(c => c.Id == id);
            if (tmp != null)
            {
                _ = context.People.Remove(tmp);
            }
        }

        public IEnumerable<Person> GetAll()
        {
            return context.People;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await context.People.FindAsync(id) ?? throw new NullReferenceException($"Model with id = {id} is not exist");
        }

        public void Update(Person model)
        {
            context.Entry(model).State = EntityState.Modified;
        }
    }
}
