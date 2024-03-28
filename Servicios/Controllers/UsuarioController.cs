using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servicios.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("api/Usuario/Add")]
        public ActionResult Add([FromBody] Negocio.Usuario usuario)
        {
            Dictionary<string, object> resultado = Negocio.Usuario.Add(usuario);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado); 
            }
            else
            {

                return BadRequest("Error");
            }
        }
        [HttpPut]
        [Route ("api/Usuario/UpDate")]
        public  ActionResult UpDate([FromBody]Negocio.Usuario usuario)
        {
            Dictionary<string, object> resultado = Negocio.Usuario.UpDate(usuario);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else

            {
                return BadRequest("Error");
            }
        }
        [HttpDelete]
        [Route("api/Usuario/Delete/{IdUsuario}")]
        public ActionResult Delete(int IdUsuario)
        {
            Dictionary<string, object> resultado = Negocio.Usuario.Delete(IdUsuario);
            bool result = (bool)resultado["Resultado"];
            if (result)
            {
                return Ok(resultado);
            }
            else
            {
                return BadRequest((string)resultado["Resultado"]);

            }
        }

    }
}
