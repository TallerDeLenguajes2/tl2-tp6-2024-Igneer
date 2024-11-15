public class Presupuesto
{
    private List<PresupuestoDetalle> detalle;
    public int IdPresupuesto{get; set;}
    public string NombreDestinatario{get; set;}
    public DateOnly FechaCreacion{get; set;}
    public List<PresupuestoDetalle> Detalle { get => detalle;}

    public Presupuesto()
    {
        detalle = new List<PresupuestoDetalle>();
    }
    public void agregarProducto(Producto prod, int Cantidad)
    {
        PresupuestoDetalle pd = new PresupuestoDetalle();
        pd.agregarProducto(prod);
        pd.Cantidad = Cantidad;

        detalle.Add(pd);
    }

    public List<PresupuestoDetalle> getListaDetalle()
    {
        return detalle;
    }
    
    public int montoPresupuesto()
    {
        int total = 0;
        foreach (PresupuestoDetalle d in detalle)
        {
            total += d.Cantidad * d.Producto.Precio;
        }

        return total;
    }

    public double montoPresupuestoConIVA()
    {
        return montoPresupuesto() * 1.21;
    }
}