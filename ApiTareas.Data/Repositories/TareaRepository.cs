using ApiTareas.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public async Task<bool> actualizarTarea(TareaME tarea)
        {
           var db = dbConnection();
            var sql = @"UPDATE TAREA
                        SET TITULO = @Nombre, DESCRIPCION = @Descripcion, HORA= @Hora, FECHA = @Fecha, IDESTADO = @IdEstado
                        WHERE ID = @Id";
            var result = await db.ExecuteAsync(sql, new { TITULO = tarea.Titulo, DESCRIPCION = tarea.Descripcion, HORA = tarea.Hora, FECHA = tarea.Fecha, IDESTADO = tarea.IdEstado, Id = tarea.Id });

            //Insertar los usuarios asignados a la tarea
            if (tarea.IdUsuarios != null)
            {
                foreach (var idUsuario in tarea.IdUsuarios)
                {
                    var sqlUsuario = @"INSERT INTO TAREAUSUARIO(IDTAREA, IDUSUARIO) VALUES(@IdTarea, @IdUsuario)";
                    var resultUsuario = await db.ExecuteAsync(sqlUsuario, new { IdTarea = tarea.Id, IdUsuario = idUsuario });
                }
            }

            db.Close();
            return result > 0;
        }

        public async Task<bool> crearTarea(TareaME tarea)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO TAREA(TITULO, DESCRIPCION, HORA, FECHA, IDESTADO) VALUES(@Titulo, @Descripcion, @Hora, @Fecha, @IdEstado)";
            var result = db.ExecuteReader(sql, new { Titulo = tarea.Titulo, Descripcion = tarea.Descripcion, HORA = tarea.Hora, Fecha = tarea.Fecha, IdEstado = tarea.IdEstado });

            //int id = db.

            //Insertar los usuarios asignados a la tarea
            if (tarea.IdUsuarios != null)
            {
                foreach (var idUsuario in tarea.IdUsuarios)
                {
                    var sqlUsuario = @"INSERT INTO TAREAUSUARIO(IDTAREA, IDUSUARIO) VALUES(@IdTarea, @IdUsuario)";
                    var resultUsuario = db.Execute(sqlUsuario, new { IdTarea = tarea.Id, IdUsuario = idUsuario });
                }
            }


            return result != null;
        }

        public async Task<bool> eliminarTarea(TareaME tarea)
        {
            var db = dbConnection();

            //Eliminar los usuarios asignados a la tarea
            var sqlUsuario = @"DELETE FROM TAREAUSUARIO WHERE IDTAREA = @Id";
            var resultUsuario = await db.ExecuteAsync(sqlUsuario, new { Id = tarea.Id });



            var sql = @"DELETE FROM TAREA
                        WHERE ID = @Id";
            var result = db.Execute(sql, new { Id = tarea.Id });
            return result > 0;
        }

        public Task<TareaMS> obtenerTareaPorId(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM TAREA
                        WHERE ID = @Id";
            return db.QueryFirstOrDefaultAsync<TareaMS>(sql, new { Id = id });
        }

        public Task<IEnumerable<TareaMS>> obtenerTareas()
        {
            var db = dbConnection();
            var sql = @"SELECT * FROM TAREA";
            return db.QueryAsync<TareaMS>(sql, new { });
        }
    }
}
