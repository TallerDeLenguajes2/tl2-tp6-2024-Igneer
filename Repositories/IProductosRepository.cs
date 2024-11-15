interface IProductoRepository
{
    public void InsertProducto(string Descripcion, int precio);

    public void UpdateProducto(int id, string Descripcion, int precio);

    public List<Producto> GetProductos();

    public Producto GetProducto(int id);

    public void DeleteProducto(int id);
}