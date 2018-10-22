using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    class TYP_PART
    {
        [PrimaryKey, AutoIncrement]
        public int COD_PART { get; set; }
        public string LIB_PART { get; set; }
    }
}
