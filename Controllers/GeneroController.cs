using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplicationJukebox.Models;
using WebApplicationJukebox.Repositories;
using WebApplicationJukebox.ViewModels;
using WebApplicationJukebox.ViewModels.Genero;
using WebApplicationJukeBox.ViewModels;

namespace WebApplicationJukeBox.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : Controller
    {
        private readonly GeneroRepository _repository;
        public GeneroController(GeneroRepository repository)
        {
            _repository = repository;
        }


        [Route("v1")]
        [HttpGet]
        public IEnumerable<GeneroListaView> Get()
        {
            return _repository.Get();
        }

        [HttpGet("V1/{id}")]
        public Genero Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1")]
        [HttpPost]
        public ResultViewModel Post([FromBody]GeneroPostView generoJson)
        {
            generoJson.Validate();
            if (generoJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o genero.",
                    Data = generoJson.Notifications
                };

            var genero = new Genero();
            genero.Titulo = generoJson.Titulo;
            _repository.Save(genero);

            return new ResultViewModel
            {
                Success = true,
                Message = "Genero cadastrado com sucesso!",
                Data = genero
            };
        }

        [Route("v1")]
        [HttpPut]
        public ResultViewModel Put([FromBody]GeneroPutView generoJson)
        {
            generoJson.Validate();
            if (generoJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o Genero.",
                    Data = generoJson.Notifications
                };

            var genero = _repository.Get(generoJson.Id);
            if (genero == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de Genero não existe.",
                    Data = generoJson.Notifications
                };
            }
            genero.Titulo = generoJson.Titulo;
            _repository.Update(genero);

            return new ResultViewModel
            {
                Success = true,
                Message = "Genero alterado com sucesso!",
                Data = genero
            };
        }

        [Route("v1")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]GeneroDeleteView generoJson)
        {
            generoJson.Validate();
            if (generoJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível deletar genero.",
                    Data = generoJson.Notifications
                };

            var genero = _repository.Get(generoJson.Id);
            if (genero == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de Genero não existe.",
                    Data = generoJson.Notifications
                };
            }

            _repository.Delete(genero);
            return new ResultViewModel
            {
                Success = true,
                Message = "Genero excluido com sucesso!",
                Data = genero
            };

        }
    }
}
