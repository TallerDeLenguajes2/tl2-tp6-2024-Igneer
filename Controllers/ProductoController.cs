using Microsoft.AspNetCore.Mvc;
namespace tl2_tp6_2024_Igneer.Controllers;

public class ProductoController : Controller
{
    ProductosRepositorySQL prSQL = new ProductosRepositorySQL();
    
    [HttpGet]
    public IActionResult Productos()
    {
        List<Producto> productos = prSQL.GetProductos();
    
        return View(productos);
    }
    
    [HttpGet]
    public IActionResult AltaProducto()
    {
        return View();
    } 

    [HttpPost]
    public IActionResult InsertProducto(Producto producto)
    {
        prSQL.InsertProducto(producto.Descripcion, producto.Precio);

        return RedirectToAction("Productos");
    }

    [HttpGet]
    public IActionResult ModificarProducto(int id)
    {
        Producto p = new Producto();

        p = prSQL.GetProducto(id);

        return View(p);
    } 

    [HttpPost]
    public IActionResult UpdateProducto(int idProducto, string descripcion, int precio)
    {
        prSQL.UpdateProducto(idProducto, descripcion, precio);

        return RedirectToAction("Productos");
    }

    [HttpPost]
    public IActionResult DeleteProducto(int id)
    {
        prSQL.DeleteProducto(id);

        return RedirectToAction("Productos");
    }

}