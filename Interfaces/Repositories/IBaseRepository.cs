namespace CinemaApp.Interfaces.Repositories
{
    public interface IBaseRepository<TResponse, TParamData>
    {
        Task<List<TResponse>> GetAll();

        Task<TResponse> FindOne(int id);

        Task<TResponse> Create(TParamData data);

        Task<TResponse> Update(int id, TParamData data);

        Task<bool> Delete(int id);
    }
}
