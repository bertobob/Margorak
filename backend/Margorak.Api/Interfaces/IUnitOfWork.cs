namespace Margorak.Api.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
