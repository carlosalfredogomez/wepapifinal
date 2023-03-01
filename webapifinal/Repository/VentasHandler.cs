using System.Data.SqlClient;
using webapifinal.Models;

namespace webapifinal.Repository
{
    public static class VentasHandler
    {
        public static string connectionString = "Data Source=QT5\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Cargar nueva Venta
        public static long InsertarVenta(Venta nuevaVenta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"INSERT INTO Venta (Comentarios,IdUsuario) VALUES(@comentarios,@idUsuario); SELECT @@IDENTITY ", connection);

                comando.Parameters.AddWithValue("@comentarios", nuevaVenta.Comentarios);
                comando.Parameters.AddWithValue("@idUsuario", nuevaVenta.IdUsuario);
                connection.Open();

                return Convert.ToInt64(comando.ExecuteScalar());
            }
        }

        public static void CargarVenta(long idUsuario, List<Producto> productosVendidos)
        {
            Venta nuevaVenta = new Venta(idUsuario);
            long idVenta = VentasHandler.InsertarVenta(nuevaVenta);
            ProductoVendido nuevoVendido = new ProductoVendido(idVenta);

            foreach (Producto producto in productosVendidos)
            {
                nuevoVendido.IdProducto = producto.Id;
                nuevoVendido.Stock = producto.Stock;
                ProductoVendidoHandler.CargarProductoVendido(nuevoVendido);

                ProductoHandler.ActualizarStockProductos(producto.Id, producto.Stock);

            }

        }

        /// Trae toda la lista de ventas (no estaba pedido en la entrega)
        public static List<Venta> ObtenerTodasLasVentas()
        {
            List<Venta> listaVentas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta", connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta ventaAuxiliar = new Venta();
                        ventaAuxiliar.Id = reader.GetInt64(0);
                        ventaAuxiliar.Comentarios = reader.GetString(1);
                        ventaAuxiliar.Id = reader.GetInt64(2);

                        listaVentas.Add(ventaAuxiliar);
                    }
                }
                return listaVentas;
            }
        }

        // Trae la lista de ventas realizadas por el usuario indicado
        public static List<Venta> ObtenerVentasPorUsuario(long idUsuario)
        {
            List<Venta> ventasPorUsuario = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Venta WHERE IdUsuario = {idUsuario}", connection);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta ventaAuxiliar = new Venta();
                        ventaAuxiliar.Id = reader.GetInt64(0);
                        ventaAuxiliar.Comentarios = reader.GetString(1);
                        ventaAuxiliar.IdUsuario = reader.GetInt64(2);

                        ventasPorUsuario.Add(ventaAuxiliar);
                    }
                }
                return ventasPorUsuario;
            }
        }
    }
}
