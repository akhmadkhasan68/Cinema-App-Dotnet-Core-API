namespace CinemaApp.Interfaces.Repositories
{
    public interface IBaseRepository<TDto, TModel>
    {
        Task<List<TDto>> GetAll();

        Task<TDto> FindOne(int id);

        Task<TDto> Create(TModel data);

        Task<TDto> Update(int id, TModel data);

        Task<bool> Delete(int id);
    }
}
