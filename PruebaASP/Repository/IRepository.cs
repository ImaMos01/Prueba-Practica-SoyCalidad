namespace PruebaASP.Repository
{
    public interface IRepository<T1,T2>
    {
        Task<IEnumerable<T1>> GetCampo();
        Task<IEnumerable<T2>> GetByIdCampo(int id);
    }
}
