interface IPresupuestoRepository
{
    public void InsertPresupuesto(Presupuesto p);
    public List<Presupuesto> GetPresupuestos();
    public Presupuesto GetDetallesPresupuesto(int id);
    public void DeletePresupuesto(int id);
    public void AgregarProductoAPresupuesto(int idPresupuesto, int idProducto, int cantidad);
}