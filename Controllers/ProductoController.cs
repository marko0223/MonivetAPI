using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonivetAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace MonivetAPI.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        public readonly MonivetContext _monivetContext;

        public ProductoController(MonivetContext _monivet)
        {
            _monivetContext = _monivet;
        }
        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<TbProducto> lista = new List<TbProducto>();
            try
            {
                lista = _monivetContext.TbProductos.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Listar Productos", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] TbProducto objeto)
        {
            try
            {
                _monivetContext.TbProductos.Add(objeto);
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
        public IActionResult Editar([FromBody] TbProducto objeto)
        {
            TbProducto tbProducto = _monivetContext.TbProductos.Find(objeto.CodPro);
            if (tbProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                objeto.CodPro = objeto.CodPro is null ? objeto.CodPro : objeto.CodPro;
                objeto.DesPro = objeto.DesPro is null ? objeto.DesPro : objeto.DesPro;
                objeto.PrePro = objeto.PrePro;
                objeto.StkAct = objeto.StkAct;
                objeto.StkMin = objeto.StkMin;
                objeto.UniMed = objeto.UniMed is null ? objeto.UniMed : objeto.UniMed;
                objeto.LinPro = objeto.LinPro is null ? objeto.LinPro : objeto.LinPro;
                objeto.Importado = objeto.Importado is null ? objeto.Importado : objeto.Importado;

                _monivetContext.TbProductos.Update(objeto);
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
            TbProducto tbProducto = _monivetContext.TbProductos.Find(codigo);
            if (tbProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }
            try
            {
                _monivetContext.TbProductos.Remove(tbProducto);
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
