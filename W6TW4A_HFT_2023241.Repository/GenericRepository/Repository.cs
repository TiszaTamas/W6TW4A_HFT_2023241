using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W6TW4A_HFT_2023241.Repository.Database;
using W6TW4A_HFT_2023241.Repository.Interfaces;

namespace W6TW4A_HFT_2023241.Repository.GenericRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected AdventurerGuildDbContext agcx;
        public Repository(AdventurerGuildDbContext agcx)
        {
            this.agcx = agcx;
        }
        public void Create(T item)
        {
            agcx.Set<T>().Add(item);
            agcx.SaveChanges();
        }
        public IQueryable<T> ReadAll()
        {
            return agcx.Set<T>();
        }
        public void Delete(int id)
        {
            agcx.Set<T>().Remove(Read(id));
            agcx.SaveChanges();
        }
        public abstract T Read(int id);
        public abstract void Update(T item);

    }
}
