using Alcohol.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Alcohol.Controllers
{
    /* Nombre de la escuela: Universidad Tecnologica Metropolitana
    Asignatura: Aplicaciones Web Orientadas a Objetos
    Nombre del Maestro: Chuc Uc Joel Ivan
    Nombre de la actividad: Actividad 2 Ejercicio 2 – Cálculo del nivel del alcohol en la sangre (alcoholemia)
    Nombre del alumno: Rafael Salazar Perera
    Cuatrimestre: 4
    Grupo: A
    Parcial: 2
    */
    [ApiController]
    [Route("api/[controller]")]
    public class Alcolizadocontroller : ControllerBase
    {
        [HttpGet]
        [Route("Calcular")]
        
        public IActionResult CalcularAlcohol(string _bebida,int cantidad, int peso)
        {
            
            var Alcohol = new Bebidas();
            Alcohol.Alcoholconsumido(_bebida,cantidad);
            if(_bebida.ToLower()!= "cerveza" && _bebida.ToLower()!="vino" && _bebida.ToLower()!="cava" &&_bebida.ToLower()!="vermu" && _bebida.ToLower()!="licor" && _bebida.ToLower()!="brandy")
            {
                return Ok("ERROR: La bebida que ingreso es incorrecta, intente de nuevo.");
            }
            Alcohol.PasaAlasangre(peso);
            if (peso <0)
            {
                return Ok("ERROR: El peso que ingreso es incorrecto, intente de nuevo.");
            }
            return Ok(Alcohol.Resultado());
        }
    }
}