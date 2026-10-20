using Microsoft.EntityFrameworkCore;
using TrialA.DATA;
using TrialA.REPOS.interfacess;

namespace TrialA.REPOS.Implemntion
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly Appdbcontext db;

        public GenericRepo(Appdbcontext db)
        {
            this.db = db;
        }

        public async Task Create(T obj)
        {
          await db.Set<T>().AddAsync(obj);
        }

        public async void Delete(T obj)
        {
            db.Set<T>().Remove(obj);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetbyId(int id)
        {
            var e =await db.Set<T>().FindAsync(id);

            return e;
        }

        public async void Update(T obj)
        {
            db.Set<T>().Update(obj);
        }
    }
}
