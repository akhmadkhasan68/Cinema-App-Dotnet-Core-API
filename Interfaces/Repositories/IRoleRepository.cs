namespace CinemaApp.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        public Task<bool> IsExist(int id);
    }
}
