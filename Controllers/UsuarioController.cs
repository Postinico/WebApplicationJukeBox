using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Models.nUsuarios;
using WebApplicationJukebox.Repositories.doUsuario;
using WebApplicationJukebox.Repositories.nUsuario;
using WebApplicationJukebox.ViewModels.nUsuario;
using WebApplicationJukeBox.ViewModels;
using WebApplicationJukeBox.ViewModels.nnUsuario;
using WebApplicationJukeBox.ViewModels.nUsuario;

namespace WebApplicationJukeBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _repository;
        private readonly PerfilRepository _perfilRepository;
        public UsuarioController(UsuarioRepository repository)
        {
            _repository = repository;
        }

        [Route("v1")]
        [HttpGet]
        public IEnumerable<UsuarioListView> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public UsuarioListView Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1")]
        [HttpPost]
        public ResultViewModel Post([FromBody]UsuarioPostView usuarioJson)
        {
            usuarioJson.Validate();
            if (usuarioJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar usuário.",
                    Data = usuarioJson.Notifications
                };

            var usuario = new Usuario();
            usuario.Email = usuarioJson.Email;
            usuario.Senha = usuarioJson.Senha;
            usuario.Imagem = usuarioJson.Imagem;
            usuario.PerfilId = usuarioJson.PerfilId;

            StoreDataContext context = new StoreDataContext();
            var perfil = context.Perfils.Find(usuarioJson.PerfilId);

            if (perfil == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de perfil não existe.",
                    Data = usuarioJson.Notifications
                };
            }
            _repository.Save(usuario);

            return new ResultViewModel
            {
                Success = true,
                Message = "Usuário cadastrado com sucesso!",
                Data = usuario
            };
        }

        [Route("v1")]
        [HttpPut]
        public ResultViewModel Put([FromBody]UsuarioPutView usuarioJson)
        {
            usuarioJson.Validate();
            if (usuarioJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar usuário.",
                    Data = usuarioJson.Notifications
                };

            var usuario = _repository.Search(usuarioJson.Id);
            if (usuario == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de usuário não existe.",
                    Data = usuarioJson.Notifications
                };
            }

            usuario.Email = usuarioJson.Email;
            usuario.Senha = usuarioJson.Senha;
            usuario.Imagem = usuarioJson.Imagem;
            usuario.PerfilId = usuarioJson.PerfilId;

            _repository.Update(usuario);

            return new ResultViewModel
            {
                Success = true,
                Message = "Usuário alterado com sucesso!",
                Data = usuario
            };
        }

        [Route("v1")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]UsuarioDeletView usuarioJson)
        {
            usuarioJson.Validate();
            if (usuarioJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível deletar usuário.",
                    Data = usuarioJson.Notifications
                };

            var usuario = _repository.Search(usuarioJson.Id);
            if (usuario == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de usuário não existe.",
                    Data = usuarioJson.Notifications
                };
            }

            _repository.Delete(usuario);
            return new ResultViewModel
            {
                Success = true,
                Message = "Usuário excluido com sucesso!",
                Data = usuario
            };

        }
    }
}