using System.Data.SqlClient;
using webapifinal.Models;

namespace webapifinal.Repository
{
    public static class UsuarioHandler
    {

        public static string connectionString = "Data Source=QT5\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Cargar nuevo usuario
        public static int CargarUsuario(Usuario nuevoUsuario)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES(@nombre,@apellido,@nombreUsuario,@contraseña,@mail)", connection);

                comando.Parameters.AddWithValue("@nombre", nuevoUsuario.Nombre);
                comando.Parameters.AddWithValue("@apellido", nuevoUsuario.Apellido);
                comando.Parameters.AddWithValue("@nombreUsuario", nuevoUsuario.NombreUsuario);
                comando.Parameters.AddWithValue("@contraseña", nuevoUsuario.Contraseña);
                comando.Parameters.AddWithValue("@mail", nuevoUsuario.Mail);
                connection.Open();

                return comando.ExecuteNonQuery();
            }
        }

        /// Modificar Usuario

        public static int ModificarUsuario(Usuario nuevoUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand($"UPDATE Usuario SET Nombre=@nombre ,Apellido=@apellido ,NombreUsuario=@nombreUsuario,Contraseña=@contraseña,Mail=@mail WHERE Id=@id", connection);

                    comando.Parameters.AddWithValue("@id", nuevoUsuario.Id);
                    comando.Parameters.AddWithValue("@nombre", nuevoUsuario.Nombre);
                    comando.Parameters.AddWithValue("@apellido", nuevoUsuario.Apellido);
                    comando.Parameters.AddWithValue("@nombreUsuario", nuevoUsuario.NombreUsuario);
                    comando.Parameters.AddWithValue("@contraseña", nuevoUsuario.Contraseña);
                    comando.Parameters.AddWithValue("@mail", nuevoUsuario.Mail);
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

        /// Trae el usuario con el ID indicado
        public static Usuario buscarUsuarioPorId(long idUsuario)
        {
            Usuario buscado = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE Id =@idUsuario", connection);

                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    buscado.Id = reader.GetInt64(0);
                    buscado.Nombre = reader.GetString(1);
                    buscado.Apellido = reader.GetString(2);
                    buscado.NombreUsuario = reader.GetString(3);
                    buscado.Contraseña = reader.GetString(4);
                    buscado.Mail = reader.GetString(5);

                }
                return buscado;
            }
        }

        /// Trae el usuario con el nombre indicado
        public static Usuario buscarUsuario(string usuario)
        {
            Usuario buscado = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario =@usuario", connection);

                comando.Parameters.AddWithValue("@usuario", usuario);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    buscado.Id = reader.GetInt64(0);
                    buscado.Nombre = reader.GetString(1);
                    buscado.Apellido = reader.GetString(2);
                    buscado.NombreUsuario = reader.GetString(3);
                    buscado.Contraseña = reader.GetString(4);
                    buscado.Mail = reader.GetString(5);

                }
                return buscado;
            }
        }

        // Inicio Sesion 
        public static Usuario InicioSesion(string usuario, string contraseña)
        {
            Usuario buscado = new Usuario();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario = @usuario AND Contraseña = @contraseña", connection);

                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contraseña", contraseña);
                connection.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    buscado.Id = reader.GetInt64(0);
                    buscado.Nombre = reader.GetString(1);
                    buscado.Apellido = reader.GetString(2);
                    buscado.NombreUsuario = reader.GetString(3);
                    buscado.Contraseña = reader.GetString(4);
                    buscado.Mail = reader.GetString(5);

                }
                return buscado;
            }
        }

        /// Eliminar Usuario
        public static int EliminarUsuario(long idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand($"DELETE FROM Usuario WHERE Id= @idUsuario", connection);

                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
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
    }
}
