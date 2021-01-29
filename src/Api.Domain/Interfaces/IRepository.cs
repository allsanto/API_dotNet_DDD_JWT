using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    // A interface 
    public interface IRepository<T> where T : BaseEntity // O T pode ser qualquer Letra ou Palavra
    {
        // Vamos fazer o CRUD
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync(); // Como vou retornar uma lista utilizo um IEnumerable. Não tem parametro
        Task<bool> ExistAsync(Guid id);
    }
}
