namespace CinemaApp.Interfaces.Services
{
    public interface IBaseService<TDto, TModel>
    {
        public Task<List<TDto>> GetAll();

        public Task<TDto> FindOne(int id);

        public Task<TDto> Create(TModel data);

        public Task<TDto> Update(int id, TModel data);

        public Task<bool> Delete(int id);
    }
}
