using ApiTareas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiTareas.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {


        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://192.168.0.103/API_AD/api/v1/auth/"),
        };
        public async Task<LoginResp> login(Credenciales credenciales)
        {
            //Consumir sericio de url post pasandole el parametro de usuario y contrasena
            LoginResp login = new LoginResp();
            var response = await sharedClient.PostAsync("ActiveDirectory", new StringContent(JsonSerializer.Serialize(new { username = credenciales.usuario, password = credenciales.contrasena }), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                login = JsonSerializer.Deserialize<LoginResp>(responseStream);
                
                if (login.Principal.Certificates.Length!=0)
                {
                    login.Principal.Status = 200;
                    return login;
                }
                else
                {
                    login.Principal.Status = 401;
                    return login;
                }


            }else
            {
                login.Principal.Status = response.StatusCode.GetHashCode();
                return login;
            }

        }
    }
}
