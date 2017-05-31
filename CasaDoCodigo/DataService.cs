using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;
        public DataService(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public List<ItemPedido> GetItensPedido()
        {
            return this._contexto.ItensPedido.Include(item => item.Produto).ToList();
        }

        public List<Produto> GetProdutos()
        {
            return this._contexto.Produtos.ToList();
        }

        public void InicializaDB()
        {
            this._contexto.Database.EnsureCreated();
            if (this._contexto.Produtos.Count() == 0)
            {
                List<Produto> produtos = new List<Produto> {
                        new Produto ("Sleep not found", 59.9m),
                        new Produto ("May the code be with you", 59.9m),
                        new Produto ("Rollback", 59.9m),
                        new Produto ("REST", 69.90m),
                        new Produto ("Design Patterns com Java", 69.90m),
                        new Produto ("Vire o jogo com Spring", 69.9m),
                        new Produto ("Test Driven Development", 69.9m),
                        new Produto ("iOS", 69.9m),
                        new Produto ("Desenvolvimento de Jogos para Android", 69.9m),
                };
                foreach (var produto in produtos)
                {
                    this._contexto.Produtos.Add(produto);
                    this._contexto.ItensPedido.Add(new ItemPedido(produto, 1));
                }
                this._contexto.SaveChanges();
            }
        }
    }
}
