using ControleDeEsportes.Models;
using ControleDeEsportes.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEsportes.Controllers
{
    public class EspacoController : Controller
    {
        private readonly IEspacoRepositorio _espacoRepositorio; 
        public EspacoController(IEspacoRepositorio espacoRepositorio)
        {
                _espacoRepositorio = espacoRepositorio;
        }
        public IActionResult Index()
        {
           List<EspacoModel> espacos = _espacoRepositorio.BuscarTodos();


            return View(espacos);
        }

        public IActionResult Criar(EspacoModel espaco)
        {
            if (ModelState.IsValid) 
            {
                _espacoRepositorio.Adicionar(espaco);
                return RedirectToAction("Index");
            }
            return View(espaco);
        }

        public IActionResult Editar(int id)
        {
           EspacoModel espaco =  _espacoRepositorio.ListarPorId(id);
            return View(espaco);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            EspacoModel espaco = _espacoRepositorio.ListarPorId(id);
            return View(espaco);
        }
        public IActionResult Apagar(int id)
        {
            _espacoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(EspacoModel espaco)
        {
            if(ModelState.IsValid) { 
                _espacoRepositorio.Atualizar(espaco);
                return RedirectToAction("Index");
            }
            return View("Editar", espaco);
        }
    }
}
