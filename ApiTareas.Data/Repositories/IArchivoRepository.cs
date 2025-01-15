using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public interface IArchivoRepository
    {
        Task<bool> subir(Archivo archivo);
        Task<bool> firmarPDF(int idArchivo, string ruta, string contrasena, string rutaFirma);
        string GetCertificadoAD(string usuario, string password, string rutaCertificado);
        string subirFirma(IFormFile file);
    }
}
