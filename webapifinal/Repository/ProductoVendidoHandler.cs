using System.Data.SqlClient;
using webapifinal.Models;

namespace webapifinal.Repository
{
    public static class ProductoVendidoHandler
    {
        public static string connectionString = "Data Source=QT5\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Cargar nuevo Producto Vendido
        public static int CargarProductoVendido(ProductoVendido nuevoProducto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) VALUES (@stock,@idProducto,@idVenta)", connection);

                comando.Parameters.AddWithValue("@stock", nuevoProducto.Stock);
                comando.Parameters.AddWithValue("@idProducto", nuevoProducto.IdProducto);
                comando.Parameters.AddWithValue("@idVenta", nuevoProducto.IdVenta);

                connection.Open();

                return comando.ExecuteNonQuery();
            }
        }

        /// Trae toda la lista de productos vendidos (no estaba pedido en la entrega)
        public static List<ProductoVendido> obtenerProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM ProductoVendido", connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoAuxiliar = new ProductoVendido();
                        productoAuxiliar.Id = reader.GetInt64(0);
                        productoAuxiliar.IdProducto = reader.GetInt32(1);
                        productoAuxiliar.Stock = reader.GetInt32(2);
                        productoAuxiliar.IdVenta = reader.GetInt64(3);

                        productosVendidos.Add(productoAuxiliar);
                    }
                }
                return productosVendidos;
            }
        }

        // Trae la lista de prodcutos vendidos por el usuario indicado
        public static List<ProductoVendido> obtenerProductosVendidosPorUsuario(long idUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM ProductoVendido WHERE IdVenta = {idUsuario}", connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductoVendido productoAuxiliar = new ProductoVendido();
                        productoAuxiliar.Id = reader.GetInt64(0);
                        productoAuxiliar.Stock = reader.GetInt32(1);
                        productoAuxiliar.IdProducto = reader.GetInt64(2);
                        productoAuxiliar.IdVenta = reader.GetInt64(3);

                        productosVendidos.Add(productoAuxiliar);
                    }
                }
                return productosVendidos;
            }
        }

        //Eliminar Producto Vendido
        public static int EliminarProductoVendido(long idProducto)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"DELETE FROM Producto WHERE Id= @idProducto", connection);

                comando.Parameters.AddWithValue("@idProducto", idProducto);
                connection.Open();

                return comando.ExecuteNonQuery();

            }
        }

    }
}
