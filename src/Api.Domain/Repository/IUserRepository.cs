using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity> // Ao definir uma IRepository eu preciso passar uma entidade <>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
