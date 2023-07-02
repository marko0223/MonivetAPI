using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonivetAPI.Models;

namespace MonivetAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        public readonly MonivetContext _monivetContext;

        public ClienteController(MonivetContext _monivet)
        {
            _monivetContext = _monivet;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<TbCliente> lista = new List<TbCliente>();
            try
            {
                lista = _monivetContext.TbClientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al obtener la lista de clientes", error = ex.ToString() });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] TbCliente objeto)
        {
            try
            {
                _monivetContext.TbClientes.Add(objeto);
                _monivetContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Guardado Correctamente" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] TbCliente objeto)
        {
            TbCliente TbCliente = _monivetContext.TbClientes.Find(objeto.CodCli);
            if (TbCliente == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                objeto.CodCli = objeto.CodCli is null ? objeto.CodCli : objeto.CodCli;
                objeto.NomCli = objeto.NomCli is null ? objeto.NomCli : objeto.NomCli;
                objeto.DirCli = objeto.DirCli is null ? objeto.DirCli : objeto.DirCli;
                objeto.TlfCli = objeto.TlfCli is null ? objeto.TlfCli : objeto.TlfCli;
                objeto.DniCli = objeto.DniCli is null ? objeto.DniCli : objeto.DniCli;
                objeto.CodDis = objeto.CodDis is null ? objeto.CodDis : objeto.CodDis;
                objeto.FecReg = objeto.FecReg;
                objeto.TipCli = objeto.TipCli is null ? objeto.TipCli : objeto.TipCli;
                objeto.Contacto = objeto.Contacto is null ? objeto.Contacto : objeto.Contacto;

                _monivetContext.TbClientes.Update(objeto);
                _monivetContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Editado Correctamente" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
        [HttpDelete]
        [Route("Eliminar/{codigo}")]
        public IActionResult Eliminar(string codigo)
        {
            TbCliente TbCliente = _monivetContext.TbClientes.Find(codigo);
            if (TbCliente == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                _monivetContext.TbClientes.Remove(TbCliente);
                _monivetContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Eliminado Correctamente" });


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }
    }
}
