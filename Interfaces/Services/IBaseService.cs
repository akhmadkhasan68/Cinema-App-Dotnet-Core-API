using System.Runtime.CompilerServices;
using CinemaApp.Dtos.Pagination;

namespace CinemaApp.Interfaces.Services
{
    public interface IBaseService<TDto, TModel>
    {
        public Task<List<TDto>> GetAll(PaginationRequestDto paginationRequestDto);

        public Task<TDto> FindOne(int id);

        public Task<AsyncVoidMethodBuilder> CreateAsync(TModel data);

        public Task<AsyncVoidMethodBuilder> UpdateAsync(int id, TModel data);

        public Task<bool> Delete(int id);
    }
}
