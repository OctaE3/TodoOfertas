using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOOFERTAS.Dominio
{
    public class Audith
    {
        private int _aId;
        private int _cedula;
        private string _desc;
        private DateTime _fecha;

        public int AId { get => _aId; set => _aId = value; }
        public int Cedula { get => _cedula; set => _cedula = value; }
        public string Desc { get => _desc; set => _desc = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }


        public Audith() { }

        public Audith(int paId, int pcedula, string pdesc, DateTime pfecha)
        {
            AId = paId;
            Cedula = pcedula;
            Desc = pdesc;
            Fecha = pfecha;
        }

    }
}
