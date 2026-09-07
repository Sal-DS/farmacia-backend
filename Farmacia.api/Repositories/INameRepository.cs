using Farmacia.api.Models;

public interface INameRepository
{
    Task<bool> ExistName(string name, string manufacturer);    
}