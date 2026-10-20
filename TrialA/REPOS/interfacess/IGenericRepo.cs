namespace TrialA.REPOS.interfacess
{
    public interface IGenericRepo<T> where T : class
    {
        Task Create(T obj);
        void Delete(T  obj);
        void Update(T obj);
        Task<T> GetbyId(int id);
        Task<IEnumerable<T>> GetAll();

    }
}
