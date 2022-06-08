using Microsoft.AspNetCore.Mvc;
using CRUDCOREEVALUACION.Datos;
using CRUDCOREEVALUACION.Models;

namespace CRUDCOREEVALUACION.Controllers
{
    public class MantenedorController : Controller
    {

        ContactoDatos _ContactoDatos = new ContactoDatos();
        public IActionResult Listar()
        {
            //la vista va a mostrar una lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //devuelve solamente la vista formulario html
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //recibir objeto y guardarlo en la bd
            if (!ModelState.IsValid)
                return View();
             
            var respuesta = _ContactoDatos.Guardar(oContacto);

            if(respuesta)
                return RedirectToAction("Listar");
            else
            return View();
        }
     
    }
}
