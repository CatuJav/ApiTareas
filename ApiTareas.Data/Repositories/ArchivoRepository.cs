using ApiTareas.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public class ArchivoRepository : IArchivoRepository
    {
        private readonly MySQLConfiguration _configuration;
        public ArchivoRepository(MySQLConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_configuration.ConnectionString);
        }

        public async Task<bool> subir(Archivo archivo)
        {

            var db = dbConnection();
            var sql = @"INSERT INTO ARCHIVOS(NOMBRE, TIPO, DATOS, IDTAREA) VALUES(@Nombre, @Tipo, @Datos, @IdTarea)";
            var result = db.Execute(sql, new { Nombre = archivo.Nombre, Tipo = archivo.Tipo, Datos= archivo.Datos, IdTarea = archivo.IdTarea });
            return result > 0;
        }
    }
}
