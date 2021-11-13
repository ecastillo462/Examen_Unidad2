using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Unidad2.Modelos.Entidades
{
    public class Tickets
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string TipoSoporte { get; set; }
        public string EstadoTicket { get; set; }
    }
}
