namespace webapifinal.Models
{
    public class Venta
    {
        private long _id;
        private string _comentarios;
        private long _idUsuario;

        

        public long Id { get => _id; set => _id = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }
        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        public Venta() { }

        public Venta(long idUsuario)
        {
            IdUsuario = idUsuario;
            Comentarios = " ";
        }

        public override string ToString()
        {
            return $"ID: {_id}\t Comentarios: {_comentarios}\t Stock: {_idUsuario}";
        }
    }
}
