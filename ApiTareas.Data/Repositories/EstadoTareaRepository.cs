using ApiTareas.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public class EstadoTareaRepository : IEstadoTareaRepository
    {
        private readonly MySQLConfiguration _configuration;

        public EstadoTareaRepository(MySQLConfiguration mySQLConfiguration)
        {
            _configuration = mySQLConfiguration;
        }

        public async Task<bool> actualizarEstadoTarea(EstadoTarea estado)
        {
            var db = dbConnection();
            var sql = @"UPDATE ESTADOTAREA
                        SET ESTADO = @Estado
                        WHERE ID = @Id"
            ;
            var result = await db.ExecuteAsync(sql, new { Nombre = estado.Estado, Id = estado.Id });
            return result > 0;
        }

        public async Task<bool> crearEstadoTarea(EstadoTarea estado)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO ESTADOTAREA(ESTADO) VALUES(@Estado)";
            var result = db.Execute(sql, new { Estado = estado.Estado });
            return result > 0;
        }

        public async Task<bool> eliminarEstadoTarea(EstadoTarea estado)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM ESTADOTAREA
                        WHERE ID = @Id";
            var result = db.Execute(sql, new { Id = estado.Id });
            return result > 0;
        }

        public Task<EstadoTarea> obtenerEstadoTareaPorId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM ESTADOTAREA
                        WHERE ID = @Id";
            return db.QueryFirstOrDefaultAsync<EstadoTarea>(sql, new { Id = id });

        }

        public Task<IEnumerable<EstadoTarea>> obtenerEstadoTareas()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM ESTADOTAREA";
            return db.QueryAsync<EstadoTarea>(sql, new { });
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

      

      
    }
}
