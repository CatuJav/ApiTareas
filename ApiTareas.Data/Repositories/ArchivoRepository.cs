using ApiTareas.Model;
using Dapper;
using IronPdf.Signing;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.DirectoryServices;

using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Http;

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


        public async Task<bool> firmarPDF(int idArchivo,string rutaArchivos, string contrasena, string rutaFirma)
        {
            try
            {
                var db = dbConnection();
                var sql = @"select * from archivos WHERE ID=@Id";
                var archivo = await db.QueryFirstOrDefaultAsync<Archivo>(sql, new { Id = idArchivo });

                string nombreArchivo = archivo.Nombre;
                byte[] datosPdf = archivo.Datos;
                string rutaCompleta = Path.Combine(rutaArchivos, nombreArchivo);
                File.WriteAllBytes(rutaCompleta, datosPdf);

                //string rutaFirma = GetCertificadoAD(usuario, contrasena, ruta + "\\certif.pfx");

                string pdfPath = rutaCompleta;
                string p12Path = rutaFirma;
                string password = contrasena;
                string outputPath = rutaArchivos + "\\signed_"+archivo.Nombre;
                // Rutas de los archivos
                var pdf = new PdfDocument(pdfPath);
                var cert = new X509Certificate2(p12Path);
                var signarture = new PdfSignature(cert);

              
                pdf.Sign(signarture);

                pdf.SaveAs(outputPath);

                //Actualizar pdf firmado en la base
                byte[] datosPdfFirmado = File.ReadAllBytes(outputPath);


                var sqlUpdate = @"UPDATE ARCHIVOS SET DATOS=@Datos WHERE ID=@Id";
                var result = db.Execute(sqlUpdate, new { Datos = datosPdfFirmado, Id = idArchivo });



                Console.WriteLine("PDF firmado exitosamente en: ");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al firmar el PDF: " + ex.Message);
                return false;
            }
        }

        public   string subirFirma(IFormFile file)
        {
            try
            {
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

                // Crear la carpeta si no existe
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Ruta completa del archivo
                string filePath = Path.Combine(uploadPath, file.FileName);

                // Guardar el archivo en el servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyToAsync(stream);
                }

                return  filePath;

            }
            catch (Exception e)
            {

                return null;
            }
        }


        public string GetCertificadoAD(string usuario, string password, string rutaCertificado)
        {
            try
            {
                // Ruta LDAP para conectar al AD
                string ldapPath = $"LDAP://192.168.0.103";

                // Crear conexión al directorio
                using (System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(ldapPath, usuario, password))
                {
                    // Configurar el buscador
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        // Filtrar por el nombre del usuario
                        searcher.Filter = $"(&(objectClass=user)(sAMAccountName={usuario}))";

                        // Solicitar solo el atributo del certificado
                        searcher.PropertiesToLoad.Add("userCertificate");

                        // Ejecutar búsqueda
                        SearchResult result = searcher.FindOne();
                        if (result != null && result.Properties.Contains("userCertificate"))
                        {
                            // Obtener el certificado (puede haber varios, tomamos el primero)
                            byte[] certBytes = (byte[])result.Properties["userCertificate"][0];

                            X509Certificate2 certificado = new X509Certificate2(certBytes, password);

                            // Guardar el certificado
                            System.IO.File.WriteAllBytes(rutaCertificado, certificado.Export(X509ContentType.Pfx));
                            // Crear y retornar el certificado
                            return rutaCertificado;

                        }
                        else
                        {
                            Console.WriteLine($"No se encontró el certificado para el usuario {usuario}.");
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el certificado: {ex.Message}");
                return null;
            }
        }
    }
    }
