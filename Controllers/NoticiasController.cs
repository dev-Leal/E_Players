using System;
using EPlayers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayers.Controllers
{
    public class NoticiasController : Controller
    {
        /// <summary>
        /// Aponta para a Index da View
        /// </summary>
        /// <returns>View</returns>
        Noticias noticiasModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        /// <summary>
        /// Publica as informações inseridas
        /// </summary>
        /// <param name="form">Entrada de informações</param>
        /// <returns>Redireciona para a mesma pagina</returns>
        
        public IActionResult Publicar (IFormCollection form)
        {
            Noticias noticias       = new Noticias();
            noticias.IdNoticia      = Int32.Parse( form["IdNoticia"]);
            noticias.Titulo         = form["Titulo"];
            noticias.Texto          = form["Texto"];
        }
    }

}