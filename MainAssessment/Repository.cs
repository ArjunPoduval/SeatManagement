using MainAssessment.Interface;

namespace MainAssessment
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ManagementContext _context;

        public Repository(ManagementContext context)
        {
            this._context = context;

        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
         
        }

    }
}
