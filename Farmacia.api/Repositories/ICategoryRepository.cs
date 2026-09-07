public interface ICategoryRepository
{
    Task<bool> ExistAsync(int id);
}