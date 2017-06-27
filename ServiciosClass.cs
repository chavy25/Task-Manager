using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    //la clase se declara para incluir todos los objetos del sistema en un solo formato
    class ServiciosClass
    {
        private string usuario;
        private string id;
        private string nombre;
        private string desc;

        //se crean los metodos de acceso importantes para accesar datos
        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Desc { get => desc; set => desc = value; }
        public string Usuario { get => usuario; set => usuario = value; }

        public ServiciosClass() { }
    }
}
