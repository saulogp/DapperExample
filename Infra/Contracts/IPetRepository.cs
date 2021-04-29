using ExemploDapper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExemploDapper.Infra.Contracts
{
    public interface IPetRepository
    {
        Task AddAsync(Pet pet);
        Task<Pet> GetByIdAsync(Guid id);
        Task<IEnumerable<Pet>> GetAsync();
        Task<Pet> PutAsync(Pet pet);
        Task<Pet> DeleteAsync(Guid id);
    }
}
