using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class ProcesosClass
    {
        public string id, nombre, desc, cpu, memoria, usuario, prioridad;

        public string Memoria
        {
            get { return memoria; }
            set { memoria = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Cpu
        {
            get { return cpu; }
            set { cpu = value; }
        }

        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
