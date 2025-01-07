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
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly MySQLConfiguration _configuration;

        public ComentarioRepository(MySQLConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }
        public async Task<int> crearComentario(ComentarioME comentario)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tareas.comentario (comentario,idUsuario,idTarea) VALUES (@comentario,@idUsuario,@idTarea);";
            var result = db.Execute(sql, new { comentario = comentario.comentario, idUsuario = comentario.idUsuario, idTarea = comentario.idTarea});

            //last inserted id
            var id = db.Query<int>("SELECT LAST_INSERT_ID()").Single();         


            return result > 0 ? id : 0;
        }

        public async Task<IEnumerable<ComentarioMS>> obtenerComentarioPorIdTarea(int idTarea)
        {
            var db = dbConnection();
            var sql = @"select c.id, c.comentario , c.idUsuario , u.USUARIOAD , c.idTarea , t.TITULO , t.DESCRIPCION , c.fecha 
                from comentario c inner join tarea t on c.idTarea = t.ID 
                inner join usuario u ON u.ID = c.idUsuario 
                where c.idTarea =@Id
                order by c.fecha desc";
            return await db.QueryAsync<ComentarioMS>(sql, new { Id = idTarea });
        }

        public async Task<IEnumerable<ComentarioMS>> obtenerComentarioPorIdUsuario(int idUsuario)
        {
            var db = dbConnection();
            var sql = @"select c.id, c.comentario , c.idUsuario , u.USUARIOAD , c.idTarea , t.TITULO , t.DESCRIPCION , c.fecha 
                from comentario c inner join tarea t on c.idTarea = t.ID 
                inner join usuario u ON u.ID = c.idUsuario 
                where c.idUsuario =@Id
                order by c.fecha desc
                ";
            return await db.QueryAsync<ComentarioMS>(sql, new { Id = idUsuario });
        }

        public async Task<IEnumerable<ComentarioMS>> obtenerComentarios()
        {
            var db = dbConnection();
            var sql = @"select c.id, c.comentario , c.idUsuario , u.USUARIOAD , c.idTarea , t.TITULO , t.DESCRIPCION , c.fecha 
                from comentario c inner join tarea t on c.idTarea = t.ID 
                inner join usuario u ON u.ID = c.idUsuario
                order by c.fecha desc
                ";
            return await db.QueryAsync<ComentarioMS>(sql, new { });
        }
    }
}
