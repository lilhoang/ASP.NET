using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldCupCRUD.Models
{
    public class Matchs
    {
        public int ID { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Score { get; set; }
        public string UrlHinhAnh { get; set; }

        public string UrlHinhAnh2 { get; set; }
    }
}