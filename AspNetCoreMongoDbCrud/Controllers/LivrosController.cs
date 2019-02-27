using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMongoDbCrud.Models;
using AspNetCoreMongoDbCrud.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMongoDbCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivroServico _livroServico;

        public LivrosController(LivroServico livroServico)
        {
            _livroServico = livroServico;
        }

        // GET:
        [HttpGet]
        public ActionResult<List<Livro>> Gets()
        {
            return _livroServico.Gets();
        }

        // GET/api/Livros/1
        [HttpGet("{id:length(24)}", Name = "GetLivro")]
        public ActionResult<Livro> Get(string id)
        {
            var livro = _livroServico.Get(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        [HttpPost]
        public ActionResult<Livro> Criar(Livro livro)
        {
            _livroServico.Post(livro);
            return CreatedAtRoute("GetLivro", new { id = livro.Id.ToString() }, livro);
            //return CreatedAtRoute(nameof(Get), new { id = livro.Id.ToString() }, livro);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Livro livroEm)
        {
            var livro = _livroServico.Get(id);

            if (livro == null)
            {
                return NotFound();
            }

            _livroServico.Update(id, livroEm);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var livro = _livroServico.Get(id);

            if (livro == null)
            {
                return NotFound();
            }

            _livroServico.Remover(livro.Id);

            return NoContent();
        }
    }
}