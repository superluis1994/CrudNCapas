using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common.Attributes
{
    public class AttributesUsuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo_electronico;
        private DateTime fecha_nacimiento;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo_electronico { get => correo_electronico; set => correo_electronico = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
    }
}
