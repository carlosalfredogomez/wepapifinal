namespace webapifinal.Models
{
    public class Usuario
    {
        

        private long _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _mail;

        

        public long Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Mail { get => _mail; set => _mail = value; }

        public Usuario() { }

        public Usuario(string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Mail = mail;
        }

        public override string ToString()
        {
            return $" ID: {_id}\t Nombre: {_nombre}\t Apellido: {_apellido}\t Mail: {_mail}";
        }
    }
}
