using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplicationJukebox.Data;
using WebApplicationJukebox.Models;
using WebApplicationJukebox.Repositories;
using WebApplicationJukebox.ViewModels.Album;
using WebApplicationJukeBox.ViewModels;

namespace WebApplicationJukebox.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {


        private readonly AlbumRepository _repository;
        private readonly GeneroRepository _generoRepository;
        public AlbumController(AlbumRepository repository)
        {
            _repository = repository;
        }


        [Route("v1")]
        [HttpGet]
        public IEnumerable<AlbumListView> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public AlbumListView Get(int id)
        {
            return _repository.Get(id);
        }
                    
        [Route("v1")]
        [HttpPost]
        public ResultViewModel Post([FromBody]AlbumPostView albumJson)
        {
            albumJson.Validate();
            if (albumJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível cadastrar Album.",
                    Data = albumJson.Notifications
                };

            var album = new Album();
            album.Titulo = albumJson.Titulo;
            album.Descricao = albumJson.Descricao;
            album.Imagem = albumJson.Imagem;
            album.GeneroId = albumJson.GeneroId;
            StoreDataContext context = new StoreDataContext();
            var genero = context.Generos.Find(albumJson.GeneroId);

            if (genero == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de genero não existe.",
                    Data = albumJson.Notifications
                };
            }
            _repository.Save(album);

            return new ResultViewModel
            {
                Success = true,
                Message = "Album cadastrado com sucesso!",
                Data = album
            };
        }

        [Route("v1")]
        [HttpPut]
        public ResultViewModel Put([FromBody]AlbumPutView albumJson)
        {
            albumJson.Validate();
            if (albumJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar album.",
                    Data = albumJson.Notifications
                };

            var album = _repository.Search(albumJson.id);
            if (album == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de album não existe.",
                    Data = albumJson.Notifications
                };
            }

            album.Titulo = albumJson.Titulo;
            album.Descricao = albumJson.Descricao;
            album.Imagem = albumJson.Imagem;
            album.GeneroId = albumJson.GeneroId;

            _repository.Update(album);

            return new ResultViewModel
            {
                Success = true,
                Message = "Album alterado com sucesso!",
                Data = album
            };
        }

        [Route("v1")]
        [HttpDelete]
        public ResultViewModel Delete([FromBody]AlbumDeletView albumJson)
        {
            albumJson.Validate();
            if (albumJson.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível deletar o album.",
                    Data = albumJson.Notifications
                };

            var album = _repository.Search(albumJson.Id);
            if (album == null)
            {
                return new ResultViewModel
                {
                    Success = false,
                    Message = "ID de album não existe.",
                    Data = albumJson.Notifications
                };
            }

            _repository.Delete(album);
            return new ResultViewModel
            {
                Success = true,
                Message = "Album excluido com sucesso!",
                Data = album
            };

        }


    }

}