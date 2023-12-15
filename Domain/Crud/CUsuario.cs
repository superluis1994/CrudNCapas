using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Entities;
using common.Attributes;

namespace Domain.Crud
{
    public class CUsuario
    {
       Usuario usuario = new Usuario();
        public DataTable Mostrar()
        {
            DataTable td = new DataTable();
            td = usuario.Mostrar();
            return td;
        }
        public void Insertar(AttributesUsuario obj) 
        {
            usuario.Insertar(obj);
        }
        public void Modificar(AttributesUsuario obj)
        {
            usuario.Modificar(obj);
        }
        public void Eliminar(AttributesUsuario obj)
        {
            usuario.Eliminar(obj);
        }
        public DataTable Buscar(string Buscar)
        {
            DataTable td = new DataTable();
            td = usuario.Buscar(Buscar);
            return td;
        }
    }
}
