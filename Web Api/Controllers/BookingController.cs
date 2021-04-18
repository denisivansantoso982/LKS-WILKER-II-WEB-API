using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_Api.Model;

namespace Web_Api.Controllers
{
    public class BookingController : ApiController
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        [HttpPost]
        [Route("api/checkBooking")]
        public List<CheckBookingModel> check(TamuModel tamu)
        {
            try
            {
                List<CheckBookingModel> model = new List<CheckBookingModel>();
                connection = new SqlConnection(ConnectionModel.connectionString);
                connection.Open();
                
                command = new SqlCommand("select detail_booking.id, CONVERT(date, tgl_booking) as tgl_booking, CONVERT(date, tgl_check_in) as tgl_check_in, CONVERT(date, tgl_check_out) as tgl_check_out, total_transaksi, nomor, jenis_kamar.nama, tamu.nama, email from booking inner join detail_booking on booking.id = detail_booking.id_booking inner join kamar_hotel on detail_booking.id_kamar = kamar_hotel.id inner join jenis_kamar on kamar_hotel.id_jenis_kamar = jenis_kamar.id inner join tamu on booking.nik_tamu = tamu.id where email = '" + tamu.email + "' and nik = '" + tamu.nik + "' and tgl_check_in >= convert(date, getdate())", connection);
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    model.Add(new CheckBookingModel
                    {
                        id = Convert.ToInt32(reader[0]),
                        tgl_booking = Convert.ToString(reader[1]),
                        tgl_check_in = Convert.ToString(reader[2]),
                        tgl_check_out = Convert.ToString(reader[3]),
                        total = Convert.ToInt32(reader[4]),
                        nomor = Convert.ToInt32(reader[5]),
                        jenis = Convert.ToString(reader[6]),
                        nama = Convert.ToString(reader[7]),
                        email = Convert.ToString(reader[8]),

                    });
                }

                connection.Close();
                return model;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}