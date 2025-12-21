using Dapper;
using F1Simulator.CompetitionService.Repositories.Interfaces;
using F1Simulator.Models.DTOs.CompetitionService.Response;
using F1Simulator.Models.Models;
using F1Simulator.Utils.DatabaseConnectionFactory;
using Microsoft.Data.SqlClient;

namespace F1Simulator.CompetitionService.Repositories
{
    public class CircuitRepository : ICircuitRepository
    {

  
        private readonly SqlConnection _connection;

        public CircuitRepository( IDatabaseConnection<SqlConnection> connection)
        {          
            _connection = connection.Connect();
        }


        public async Task CreateCircuitAsync(Circuit createCircuit)
        {
            try
            {
                var query = "INSERT INTO Circuits (Id, Name, Country, LapsNumber, IsActive) " +
                             "VALUES (@Id, @Name, @Country, @LapsNumber, @IsActive)";

                await _connection.ExecuteAsync(query, new
                    {
                        createCircuit.Id,
                        createCircuit.Name,
                        createCircuit.Country,
                        createCircuit.LapsNumber,
                        createCircuit.IsActive
                    } 
                );
            }
            catch (SqlException ex)
            {
               
                throw;
            }
        }

        public async Task<bool> CircuitExistsAsync(string name)
        {
            try
            {
                var query = "SELECT COUNT(1) FROM Circuits WHERE Name = @Name";
                var result = (int)await _connection.ExecuteScalarAsync<int>(query, new { Name = name});
                return result > 0;

            }
            catch (SqlException ex)
            {
               
                throw;
            }
        }

        public async Task<int> CircuitsActivatesAsync()
        {
            try
            {
                var query = "SELECT COUNT(1) FROM Circuits;";

                return (int)await _connection.ExecuteScalarAsync<int>(query);

            }
            catch (SqlException ex)
            {
                
                throw;
            }
        }
        public async Task<CreateCircuitResponseDTO?> GetCircuitByIdAsync(Guid id)
        {
            try {

                var select = @"SELECT Id, Name, Country, LapsNumber, IsActive
                           FROM Circuits
                           WHERE Id = @Id";

                return  await _connection.QuerySingleOrDefaultAsync<CreateCircuitResponseDTO>(select, new { Id = id });

            }
            catch (SqlException ex)
            {
              
                throw;
            }
            
        }


        public async Task<List<CreateCircuitResponseDTO>> GetAllCircuitsAsync()
        {
            try
            {
                var select = @"SELECT Id, Name, Country, LapsNumber, IsActive
                           FROM Circuits;";

                var circuits = await _connection.QueryAsync<CreateCircuitResponseDTO>(select);
                return circuits.ToList();
            }
            catch (SqlException ex)
            {
               
                throw;
            }
        }

        public async Task<List<CreateCircuitResponseDTO>> GetAllCircuitsActiveAsync()
        {
            try
            {
                var select = @"SELECT Id, Name, Country, LapsNumber, IsActive
                           FROM Circuits
                           WHERE IsActive = 1;";

                var circuits = await _connection.QueryAsync<CreateCircuitResponseDTO>(select);
                return circuits.ToList();
            }
            catch (SqlException ex)
            {
               
                throw;
            }
        }


        public async Task<bool> DeleteCircuitAsync(Guid id)
        {
            try
            {
                var query = @"DELETE
                           FROM Circuits
                           WHERE Id = @Id;";

                int rows = await _connection.ExecuteAsync(query, new { Id = id });

                return rows > 0 ? true : false;
            }
            catch (SqlException ex)
            {
               
                throw;
            }
        }

        public async Task<bool> UpdateCircuitAsync(Guid id, List<string> updates, DynamicParameters parameters)
        {
            try
            {
                var sql = $"UPDATE Circuits SET {string.Join(", ", updates)} WHERE Id = @Id";
                var rows = await _connection.ExecuteAsync(sql, parameters);

                return rows > 0 ? true : false;
            }
            catch (SqlException ex)
            {
                
                throw;
            }
        }
    }
}
