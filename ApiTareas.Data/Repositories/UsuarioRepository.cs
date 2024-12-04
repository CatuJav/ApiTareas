using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiTareas.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiTareas.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MySQLConfiguration _configuration;

        public UsuarioRepository(MySQLConfiguration mySQLConfiguration)
        {
            _configuration = mySQLConfiguration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        public async Task<bool> actualizarUsuario(UsuarioME usuario)
        {
            var db = dbConnection();
            var sql = @"UPDATE USUARIO
                        SET USUARIOAD = @UsuarioAD, IDROL = @IdRol, IDDEPARTAMENTO = @IdDepartamento
                        WHERE ID = @Id";
            var result = await db.ExecuteAsync(sql, new { UsuarioAD = usuario.UsuarioAD, IdRol = usuario.IdRol, Id = usuario.Id, IDDEPARTAMENTO= usuario.IdDepartamento });

            return result > 0;

            
        }

        public async Task<bool> crearUsuario(UsuarioME usuario)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO USUARIO(USUARIOAD, IDROL, IDDEPARTAMENTO) VALUES(@UsuarioAD, @IdRol, @IdDepartamento)";
            var result = await db.ExecuteAsync(sql, new { USUARIOAD = usuario.UsuarioAD, IDROL = usuario.IdRol, IDDEPARTAMENTO = usuario.IdDepartamento });

            return result > 0;
        }

        public async Task<bool> eliminarUsuario(UsuarioME usuario)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM USUARIO
                        WHERE ID = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = usuario.Id });

            return result > 0;
        }

        public async Task<IEnumerable<UsuarioMS>> obtenerUsuarios()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM USUARIO";
            return await db.QueryAsync<UsuarioMS>(sql, new { });
        }

        public async Task<UsuarioMS> obtenerUsuariosPorId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM USUARIO WHERE id = @Id";
            return await db.QueryFirstOrDefaultAsync<UsuarioMS>(sql, new { Id = id });
        }
    }
}
