using ApiTareas.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public class DepartamentoRepository: IDepartamentoRepository
    {
        private readonly MySQLConfiguration _configuration;
        public DepartamentoRepository(MySQLConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> actualizarDepartamento(Departamento estado)
        {
            var db = dbConnection();
            var sql = @"UPDATE DEPARTAMENTO
                        SET NOMBRE = @Nombre
                        WHERE ID = @Id";
            var result = db.Execute(sql, new { Nombre = estado.Nombre, Id = estado.Id });
            return result > 0;
        }

        public async Task<bool> crearDepartamento(Departamento estado)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO DEPARTAMENTO(NOMBRE) VALUES(@Nombre)";
            var result = db.Execute(sql, new { Nombre = estado.Nombre });
            return result > 0;

        }

        public async  Task<bool> eliminarDepartamento(Departamento estado)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM DEPARTAMENTO
                        WHERE ID = @Id";
            var result = db.Execute(sql, new { Id = estado.Id });
            return result > 0;

        }

        public Task<Departamento> obtenerDepartamentoPorId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM DEPARTAMENTO
                        WHERE ID = @Id";
            return db.QueryFirstOrDefaultAsync<Departamento>(sql, new { Id = id });

        }

        public Task<IEnumerable<Departamento>> obtenerDepartamentos()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM DEPARTAMENTO";
            return db.QueryAsync<Departamento>(sql, new { });

        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }



    }
}
