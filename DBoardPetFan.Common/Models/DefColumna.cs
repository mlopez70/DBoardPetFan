using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBoardPetFan.Common.Models
{
    public class DefColumna
    {
        public enum Alineacion { Derecha, Izquierda, Centro}
        public String TituloCabecera { get; set; }
        public String Dato { get; set; }
        public String Formato { get; set; }
        public Alineacion Alinea { get; set; }
        public Decimal Acumulado { get; set; }
        public Boolean Acumula { get; set; }
        public String FormatoTotal { get; set; }
    }
}
