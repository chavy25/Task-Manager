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
        private string id;
        private string nombre;
        private string desc;
        private string usuario;
        private string estado;

        //se crean los metodos de acceso importantes para accesar datos

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        public string UsuarioServicio
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}