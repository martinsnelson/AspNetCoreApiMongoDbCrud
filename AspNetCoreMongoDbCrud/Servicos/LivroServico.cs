using AspNetCoreMongoDbCrud.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMongoDbCrud.Servicos
{
    public class LivroServico
    {
        private readonly IMongoCollection<Livro> _livros;

        public LivroServico(IConfiguration config)
        {
            var cliente = new MongoClient(config.GetConnectionString("LojaLivroDb"));
            var database = cliente.GetDatabase("LojaLivroDb");
            _livros = database.GetCollection<Livro>("Livros");
        }

        // GET: api/livro/
        public List<Livro> Gets()
        {
            return _livros.Find(livro => true).ToList();
        }

        // GET: api/livro/1
        public Livro Get(string id)
        {
            return _livros.Find<Livro>(livro => livro.Id == id).FirstOrDefault();
        }

        // POST: api/livro/
        public Livro Post(Livro livro)
        {
            _livros.InsertOne(livro);
            return livro;
        }

        // PUT:
        public void Update(string id, Livro livroEm)
        {
            _livros.ReplaceOne(livro => livro.Id == id, livroEm);
        }

        public void Remover(Livro livroEm)
        {
            _livros.DeleteOne(livro => livro.Id == livroEm.Id);
        }

        public void Remover(string id)
        {
            _livros.DeleteOne(livro => livro.Id == id);
        }
    }
}
