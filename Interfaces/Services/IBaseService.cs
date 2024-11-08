using System.Runtime.CompilerServices;

namespace CinemaApp.Interfaces.Services
{
    public interface IBaseService<TDto, TModel>
    {
        public Task<List<TDto>> GetAll();

        public Task<TDto> FindOne(int id);

        public Task<AsyncVoidMethodBuilder> CreateAsync(TModel data);

        public Task<AsyncVoidMethodBuilder> UpdateAsync(int id, TModel data);

        public Task<bool> Delete(int id);
    }
}
