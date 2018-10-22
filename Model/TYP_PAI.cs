using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    class TYP_PAI
    {
        [PrimaryKey, AutoIncrement]
        public int ID_PAI { get; set;  }
        public string COD_PAI { get; set; }
        public string LIB_PAI { get; set; }
    }
}
