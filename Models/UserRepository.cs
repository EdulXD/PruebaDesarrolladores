using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDEduardo.Models
{
    public class UserRepository : IUserRepository
    {
        private List<Elements> usuarios = new List<Elements>();
        private int _nextId = 1;

        public UserRepository()
        {

            //Elementos para pruebas
            Add(new Elements { Name = "Antonio", LastName = "Garcia", Address = "Su casa, 1" });
            Add(new Elements { Name = "Ana", LastName = "Martinez", Address = "Su casa, 2" });
            Add(new Elements { Name = "Bea", LastName = "Garcia", Address = "Su casa, 3" });
        }

        //Devuelve un usuario dada su id
        public Elements Get(int id)
        {
            return usuarios.Find(u => u.Id == id);
        }

        //Devuelve todos los usuarios
        public IEnumerable<Elements> GetAll()
        {
            return usuarios;
        }

        //Crea Usuario
        public Elements Add(Elements usuario)
        {
            if(usuario == null)
            {
                throw new ArgumentNullException("usuario");
            }
            usuario.Id = _nextId++;
            usuario.CreateDate = DateTime.Now;
            usuario.UpdateDate = DateTime.Now;
            usuarios.Add(usuario);
            return usuario;
        }

        //Elimina Usuario
        public void Remove(int id)
        {
            usuarios.RemoveAll(u => u.Id == id);
        }

        //Actualiza datos Usuario
        //No se controla lo recibido
        public bool Update(Elements usuario)
        {
            if(usuario == null)
            {
                throw new ArgumentNullException("usuario");
            }
            int indice = usuarios.FindIndex(u => u.Id == usuario.Id);
            if(indice == -1)
            {
                return false;
            }
            usuarios.RemoveAt(indice);
            usuario.UpdateDate = DateTime.Now;
            usuarios.Add(usuario);
            return true;
        }
    }
}