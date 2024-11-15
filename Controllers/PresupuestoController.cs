using Microsoft.AspNetCore.Mvc;
public class PresupuestoController : Controller
{
    PresupuestoRepositorySQL presupuestoSQL = new PresupuestoRepositorySQL();
    ProductosRepositorySQL productoSQL = new ProductosRepositorySQL();


    [HttpGet]
    public IActionResult Presupuestos()
    {
        List<Presupuesto> presupuestos = new List<Presupuesto>();
        presupuestos = presupuestoSQL.GetPresupuestos();

        return View(presupuestos);
    }

    [HttpGet]
    public IActionResult AltaPresupuesto()
    {
        return View();
    } 

    [HttpPost]
    public IActionResult InsertPresupuesto(Presupuesto p1)
    {
        Presupuesto p = new Presupuesto
        {
            NombreDestinatario = p1.NombreDestinatario,
            FechaCreacion = DateOnly.FromDateTime(DateTime.Now)
        };

        presupuestoSQL.InsertPresupuesto(p);

        return RedirectToAction("Presupuestos");
    }

    [HttpPost]

    public IActionResult DeletePresupuesto(int idPresupuesto)
    {        
        presupuestoSQL.DeletePresupuesto(idPresupuesto);

        return RedirectToAction("Presupuestos");
    }

    [HttpGet]
    public IActionResult AgregarProducto(int idPresupuesto)
    {       
        Presupuesto p = presupuestoSQL.GetDetallesPresupuesto(idPresupuesto); 
        
        return View(p);
    }

    [HttpPost]

    public IActionResult AgregarProductoAPresupuesto(int idPresupuesto, int idProducto, int cantidad)
    {
        presupuestoSQL.AgregarProductoAPresupuesto(idPresupuesto, idProducto, cantidad);

        return RedirectToAction("Presupuestos");
    } 
    
    [HttpGet]
    public IActionResult Detalles(int id)
    {
        Presupuesto presupuesto = new Presupuesto();
        presupuesto = presupuestoSQL.GetDetallesPresupuesto(id);

        return View(presupuesto);
    }
}