using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Model
{
    public class CheckBookingModel
    {
        public int id { get; set; }
        public string tgl_booking { get; set; }
        public string tgl_check_in { get; set; }
        public string tgl_check_out { get; set; }
        public int total { get; set; }
        public int nomor { get; set; }
        public string jenis { get; set; }
        public string nama { get; set; }
        public string email { get; set; }
    }
}