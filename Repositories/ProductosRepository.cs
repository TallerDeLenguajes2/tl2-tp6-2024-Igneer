using Microsoft.Data.Sqlite;

public class ProductosRepositorySQL : IProductoRepository
{
    string connectionString = "Data Source=Tienda.db;Cache=Shared";

    public void InsertProducto(string descripcion, int precio)
    {
        string queryString = @"INSERT INTO Productos (Descripcion, Precio) VALUES (@Descripcion, @Precio)";
        
         using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("@Descripcion", descripcion);
            command.Parameters.AddWithValue("@Precio", precio);

            command.ExecuteNonQuery();

            connection.Close();

        }

    }

    public void UpdateProducto(int id, string descripcion, int precio)
    {
        string queryString = @"UPDATE Productos SET Descripcion = @descripcion, Precio = @precio WHERE idProducto = @id";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@descripcion", descripcion);
            command.Parameters.AddWithValue("@precio", precio);

            command.ExecuteNonQuery();

            connection.Close();

        }
    }
    public List<Producto> GetProductos()
    {
        List<Producto> productos = new List<Producto>();
        string queryString = @"SELECT * FROM Productos";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(queryString, connection);
            
            using(SqliteDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Producto p = new Producto();
                    p.IdProducto = Convert.ToInt32(reader["idProducto"]); //en vez de poner 0, 1, etc conviene poner el nombre del atributo y todo se tiene que convertir
                    p.Descripcion = reader["Descripcion"].ToString();
                    p.Precio = Convert.ToInt32(reader["Precio"]);

                    productos.Add(p);
                }
            }
            connection.Close();

        }

        return productos;
    }

    public Producto GetProducto(int id)
    {
        Producto p = new Producto();
        string queryString = @"SELECT * FROM Productos WHERE idProducto = @id";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(queryString, connection);

            command.Parameters.AddWithValue("@id", id);
            
            using(SqliteDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                p.IdProducto = Convert.ToInt32(reader["idProducto"]); 
                p.Descripcion = reader["Descripcion"].ToString();
                p.Precio = Convert.ToInt32(reader["Precio"]);
            }
            connection.Close();
        }

        return p;
    }

    public void DeleteProducto(int id)
    {
        string queryString = @"DELETE FROM Productos WHERE idProducto = @id";
        
        using(SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(queryString, connection);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            
            connection.Close();
        }

    }
}