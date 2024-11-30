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
    public class TareaRepository : ITareaRepository
    {
        private readonly MySQLConfiguration _configuration;

        public TareaRepository(MySQLConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        public async Task<bool> actualizarTarea(Tarea tarea)
        {
           var db = dbConnection();
            var sql = @"UPDATE TAREA
                        SET TITULO = @Nombre, DESCRIPCION = @Descripcion, IDUSUSARIO= @IdUsuario, FECHA = @Fecha, IDESTADO = @IdEstado
                        WHERE ID = @Id";
            var result = await db.ExecuteAsync(sql, new { TITULO = tarea.Titulo, DESCRIPCION = tarea.Descripcion, IDUSUSARIO = tarea.IdUsuario, FECHA = tarea.Fecha, IDESTADO = tarea.IdEstado, Id = tarea.Id });

            return result > 0;
        }

        public async Task<bool> crearTarea(Tarea tarea)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO TAREA(TITULO, DESCRIPCION, IDUSUARIO, FECHA, IDESTADO) VALUES(@Titulo, @Descripcion, @IdUsuario, @Fecha, @IdEstado)";
            var result = db.Execute(sql, new { Titulo = tarea.Titulo, Descripcion = tarea.Descripcion, IdUsuario = tarea.IdUsuario, Fecha = tarea.Fecha, IdEstado = tarea.IdEstado });

            return result > 0;
        }

        public async Task<bool> eliminarTarea(Tarea tarea)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM TAREA
                        WHERE ID = @Id";
            var result = db.Execute(sql, new { Id = tarea.Id });
            return result > 0;
        }

        public Task<Tarea> obtenerTareaPorId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM TAREA
                        WHERE ID = @Id";
            return db.QueryFirstOrDefaultAsync<Tarea>(sql, new { Id = id });
        }

        public Task<IEnumerable<Tarea>> obtenerTareas()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM TAREA";
            return db.QueryAsync<Tarea>(sql, new { });
        }
    }
}
