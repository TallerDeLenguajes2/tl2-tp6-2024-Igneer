public class PresupuestoDetalle
{
    Producto producto;
    int cantidad;

    public int Cantidad { get => cantidad; set => cantidad = value; }
    public Producto Producto { get => producto; }

    public void agregarProducto(Producto p)
    {
        if(p != null)
        {
            producto = p;
        }
    }
}