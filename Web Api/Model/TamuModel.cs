using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Api.Model
{
    public class TamuModel
    {
        public int id { get; set; }
        public string nik { get; set; }
        public string nama { get; set; }
        public string email { get; set; }
        public string nohp { get; set; }
        public string alamat { get; set; }
        public string password { get; set; }
        public string confirm { get; set; }
    }
}