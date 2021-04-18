using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Web_Api.Model;

namespace Web_Api.Controllers
{
    public class TamuController : ApiController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        
        [HttpPost]
        [Route("api/login")]
        public TamuModel login([FromBody]TamuModel tamu)
        {
            try
            {
                connection = new SqlConnection(ConnectionModel.connectionString);
                connection.Open();

                string email = tamu.email;
                string password = EncryptionModel.encryption(tamu.password);

                command = new SqlCommand("SELECT * FROM tamu WHERE email = '" + email + "' AND password LIKE '" + password + "'", connection);
                reader = command.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    tamu.id = Convert.ToInt32(reader[0]);
                    tamu.nik = Convert.ToString(reader[1]);
                    tamu.nama = Convert.ToString(reader[2]);
                    tamu.email = Convert.ToString(reader[3]);
                    tamu.nohp = Convert.ToString(reader[4]);
                    tamu.alamat = Convert.ToString(reader[5]);
                    tamu.password = Convert.ToString(reader[6]);

                    connection.Close();

                    return tamu;
                }
                else
                {
                    connection.Close();
                    return null;
                }               
            } catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("api/password")]
        public string changePassword([FromBody]TamuModel tamu)
        {
            try
            {
                connection = new SqlConnection(ConnectionModel.connectionString);
                connection.Open();

                string email = tamu.email;
                string password = EncryptionModel.encryption(tamu.password);
                string passwordRepeat = EncryptionModel.encryption(tamu.confirm);

                command = new SqlCommand("SELECT * FROM tamu WHERE email = '" + email + "' AND password LIKE '" + password + "'", connection);
                reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows) {
                    reader.Close();

                    command = new SqlCommand("UPDATE tamu SET password = '" + passwordRepeat + "' WHERE email = '" + email + "' AND password LIKE '" + password + "'", connection);
                    command.ExecuteReader();
                    connection.Close();

                    return "Success";
                } else
                {
                    reader.Close();
                    connection.Close();
                    return "Fail";
                }
            } catch (Exception)
            {
                return "Fail";
            }
        }
    }
}