using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        public string ClaveEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Departamento Departamento { get; set; }
        public Sueldo Sueldo { get; set; }
        public List<object> Empleados { get; set; }
        public Empleado()
        {
            Departamento = new Departamento();
            Sueldo = new Sueldo();
        }
    }
}
