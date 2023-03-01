using System.Data.SqlClient;
using webapifinal.Models;

namespace webapifinal.Repository
{
    public static class ProductoHandler
    {
        public static string connectionString = "Data Source=QT5\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        
        public static int CargarProducto(Producto nuevoProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES(@descripcion,@costo,@precioVenta,@stock,@idUsuario)", connection);

                comando.Parameters.AddWithValue("@descripcion", nuevoProducto.Descripcion);
                comando.Parameters.AddWithValue("@costo", nuevoProducto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", nuevoProducto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", nuevoProducto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", nuevoProducto.IdUsuario);
                connection.Open();

                return comando.ExecuteNonQuery();
            }
        }

        

        public static int ModificarProducto(Producto aModificar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"UPDATE Producto SET Descripciones=@descripcion,Costo=@costo,PrecioVenta=@precioVenta,Stock=@stock,IdUsuario=@idUsuario WHERE Id=@idProducto", connection);

                comando.Parameters.AddWithValue("@idProducto", aModificar.Id);
                comando.Parameters.AddWithValue("@descripcion", aModificar.Descripcion);
                comando.Parameters.AddWithValue("@costo", aModificar.Costo);
                comando.Parameters.AddWithValue("@precioVenta", aModificar.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", aModificar.Stock);
                comando.Parameters.AddWithValue("@idUsuario", aModificar.IdUsuario);
                connection.Open();

                return comando.ExecuteNonQuery();
            }
        }

        

        public static Producto obtenerProductoPorId(long id)
        {
            Producto productoAuxiliar = new Producto();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE Id=@id", connection);
                comando.Parameters.AddWithValue("@id", id);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    productoAuxiliar.Id = id;
                    productoAuxiliar.Descripcion = reader.GetString(1);
                    productoAuxiliar.Costo = reader.GetDecimal(2);
                    productoAuxiliar.PrecioVenta = reader.GetDecimal(3);
                    productoAuxiliar.Stock = reader.GetInt32(4);
                    productoAuxiliar.IdUsuario = reader.GetInt64(5);

                }
                return productoAuxiliar;
            }
        }

        
        public static List<Producto> obtenerTodosProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto", connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoAuxiliar = new Producto();
                        productoAuxiliar.Id = reader.GetInt64(0);
                        productoAuxiliar.Descripcion = reader.GetString(1);
                        productoAuxiliar.Costo = reader.GetDecimal(2);
                        productoAuxiliar.PrecioVenta = reader.GetDecimal(3);
                        productoAuxiliar.Stock = reader.GetInt32(4);
                        productoAuxiliar.IdUsuario = reader.GetInt64(5);

                        productos.Add(productoAuxiliar);
                    }
                }
                return productos;
            }
        }

        
        public static List<Producto> obtenerProductosPorUsuario(long idUsuario)
        {
            List<Producto> productosUsuario = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Producto WHERE IdUsuario = {idUsuario}", connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto productoAuxiliar = new Producto();
                        productoAuxiliar.Id = reader.GetInt64(0);
                        productoAuxiliar.Descripcion = reader.GetString(1);
                        productoAuxiliar.Costo = reader.GetDecimal(2);
                        productoAuxiliar.PrecioVenta = reader.GetDecimal(3);
                        productoAuxiliar.Stock = reader.GetInt32(4);
                        productoAuxiliar.IdUsuario = reader.GetInt64(5);

                        productosUsuario.Add(productoAuxiliar);
                    }
                }
                return productosUsuario;
            }
        }

        
        public static int EliminarProducto(long id)
        {
            ProductoVendidoHandler.EliminarProductoVendido(id);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand($"DELETE FROM Producto WHERE Id= @id", connection);

                    comando.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    return comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(" " + ex.Message);
                    return -1;
                }

            }
        }

        public static int ActualizarStockProductos(long id, int cantVendidos)
        {
            Producto producto = ProductoHandler.obtenerProductoPorId(id);
            producto.Stock = producto.Stock - cantVendidos;
            return ProductoHandler.ModificarProducto(producto);
        }

    }
}
