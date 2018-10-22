using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetHameau.Model
{
    class FACTURE
    {
        [PrimaryKey, AutoIncrement]
        public int NUM_FAC { get; set; }
        public string LIB_FAC { get; set; }
        public float MNT_FAC { get; set; }
        public string DAT_FAC { get; set; }
        public float MNT_PAI { get; set; }
        public string DAT_PAI { get; set; }
        public string COD_PAI { get; set; }

        [ForeignKey("CREANCIER")]
        public int NUM_CRE { get; set; }
    }
}
