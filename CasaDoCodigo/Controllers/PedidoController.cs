using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {

        private readonly IDataService _dataService;

        public PedidoController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        // GET: /<controller>/
        public IActionResult Carrossel()
        {            
            return View(this._dataService.GetProdutos());
        }

        public IActionResult Carrinho()
        {
            return View(GetCarrinhoViewModel());
        }

        public IActionResult Resumo()
        {
            return View(GetCarrinhoViewModel());
        }

        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            var itensCarrinho = this._dataService.GetItensPedido();
            return new CarrinhoViewModel(itensCarrinho);
        }
    }
}
