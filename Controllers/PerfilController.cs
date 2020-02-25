using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationJukebox.Models.nUsuarios;
using WebApplicationJukebox.Repositories.nUsuario;
using WebApplicationJukebox.ViewModels.nUsuario;
using WebApplicationJukeBox.ViewModels;

namespace WebApplicationJukebx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : Controller
    {
        private readonly PerfilRepository _repository;

        public PerfilController(PerfilRepository repository)
        {
            _repository = repository;
        }

        [Route("v1")]
        [HttpGet]
        public IEnumerable<PerfilListView> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public Perfil Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1")]
        [HttpPost]
        public ResultViewModel Post([FromBody]PerfilPostView perfilJson)
        {
            perfilJson.Validate();
            if (perfilJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o perfil de usuário.",
                    Data = perfilJson.Notifications
                };

            var perfil = new Perfil();
            perfil.Descricao = perfilJson.Descricao;
            _repository.Save(perfil);

            return new ResultViewModel
            {
                Success = true,
                Message = "Perfil de usuário cadastrado com sucesso!",
                Data = perfil
            };
        }

        [Route("v1")]
        [HttpPut]
        public ResultViewModel Put([FromBody]PerfilPutView perfilJson)
        {
            perfilJson.Validate();
            if (perfilJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o Perfil.",
                    Data = perfilJson.Notifications
                };

            var perfil = _repository.Get(perfilJson.Id);
            if (perfil == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de perfil não existe.",
                    Data = perfilJson.Notifications
                };
            }
            perfil.Descricao = perfilJson.Descricao;
            _repository.Update(perfil);

            return new ResultViewModel
            {
                Success = true,
                Message = "Perfil alterado com sucesso!",
                Data = perfil
            };
        }


        [Route("v1")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]PerfilDeleteView perfilJson)
        {
            perfilJson.Validate();
            if (perfilJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível deletar perfil.",
                    Data = perfilJson.Notifications
                };

            var perfil = _repository.Get(perfilJson.Id);
            if (perfil == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de perfil não existe.",
                    Data = perfilJson.Notifications
                };
            }

            _repository.Delete(perfil);
            return new ResultViewModel
            {
                Success = true,
                Message = "Perfil excluido com sucesso!",
                Data = perfil
            };

        }

    }
}