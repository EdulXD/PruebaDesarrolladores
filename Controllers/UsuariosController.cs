using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDEduardo.Models;

namespace CRUDEduardo.Controllers
{
    public class UsuariosController : ApiController
    {
        
        private IUserRepository _repository;
        public UsuariosController(IUserRepository repository)
        {
            _repository = repository;
        }

        //Busqueda usuarios
        public IEnumerable<Elements> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public Elements GetUsuario(int id)
        {
            Elements usuario = _repository.Get(id);
            
            if(usuario == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return usuario;
        }

        //Creacion
        public Elements AddUser(Elements usuario)
        {
            return _repository.Add(usuario);
        }

        //Actualizacion
        public void PutUser(int id, Elements usuario)
        {
            usuario.Id = id;
            if (!_repository.Update(usuario))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //Eliminadfo
        public void DeleteUser(int id)
        {
            Elements usuario = _repository.Get(id);
            if(usuario == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _repository.Remove(id);
        }
    }
}
