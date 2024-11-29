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
    public class RolRepository : IRolRepository
    {
        private readonly MySQLConfiguration _configuration;

        public RolRepository(MySQLConfiguration mySQLConfiguration)
        {
            _configuration = mySQLConfiguration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        public async Task<bool> actualizarRol(Rol role)
        {
            var db = dbConnection();
            var sql = @"UPDATE ROL
                        SET NOMBRE = @Nombre
                        WHERE ID = @Id";
            var result = await db.ExecuteAsync(sql, new { Nombre = role.Nombre, Id= role.Id });

            return result > 0;
        }

        public async Task<bool> crearRol(Rol role)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO ROL(NOMBRE) VALUES(@Nombre)";
            var result = await  db.ExecuteAsync(sql, new { Nombre = role.Nombre });

            return result > 0;
        }

        public async Task<bool> eliminarRol(Rol role)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM ROL
                        WHERE ID = @Id";
            var result = await db.ExecuteAsync(sql, new {Id = role.Id });

            return result > 0;
        }

        public Task<IEnumerable<Rol>> obtenerRoles()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM ROL";
            return db.QueryAsync<Rol>(sql, new {});
        }

        public Task<Rol> obtenerRolesPorId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM ROL WHERE id = @Id";
            return db.QueryFirstOrDefaultAsync<Rol>(sql, new {Id=id });
        }
    }
}
