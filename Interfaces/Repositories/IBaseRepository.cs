using System.Runtime.CompilerServices;

namespace CinemaApp.Interfaces.Repositories
{
    public interface IBaseRepository<TResponse, TParamData>
    {
        Task<List<TResponse>> GetAll();

        Task<TResponse> FindOne(int id);

        Task<AsyncVoidMethodBuilder> CreateAsync(TParamData data);

        Task<AsyncVoidMethodBuilder> UpdateAsync(int id, TParamData data);

        Task<bool> Delete(int id);
    }
}
