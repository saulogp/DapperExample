using Dapper;
using Dapper.Contrib.Extensions;
using ExemploDapper.Domain.Entities;
using ExemploDapper.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ExemploDapper.Infra.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public PetRepository(ISqlConnectionFactory connection)
        {
            _connectionFactory = connection;
        }

        //Add
        public async Task AddAsync(Pet pet)
        {
            using var connection = _connectionFactory.Connection();
            connection.Open();
            await connection.InsertAsync(pet);
        }

        public async Task<IEnumerable<Pet>> GetAsync()
        {
            
            using var connection = _connectionFactory.Connection();
            var pets = await connection.GetAllAsync<Pet>();

            return pets;
        }

        public async Task<Pet> PutAsync(Pet pet)
        {
            using var connection = _connectionFactory.Connection();
            await connection.UpdateAsync(pet);
            return pet;
        }
        //GetByID
        public async Task<Pet> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Pet WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using var connection = _connectionFactory.Connection();

            var pet = await connection.QuerySingleOrDefaultAsync<Pet>(sql, parameters, commandType: CommandType.Text);

            return pet;
        }

        public async Task<Pet> DeleteAsync(Guid id)
        {
            var pet = await GetByIdAsync(id);

            using var connection = _connectionFactory.Connection();

            bool response = await connection.DeleteAsync(pet);
           
            return response ? pet : null;
        }
    }
}
