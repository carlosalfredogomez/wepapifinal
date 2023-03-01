namespace webapifinal.Models
{
    public class Producto
    {
        private long _id;
        private string _descripcion;
        private decimal _costo;
        private decimal _precioVenta;
        private int _stock;
        private long _idUsuario;

        

        public long Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public decimal Costo { get => _costo; set => _costo = value; }
        public decimal PrecioVenta { get => _precioVenta; set => _precioVenta = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public long IdUsuario { get => _idUsuario; set => _idUsuario = value; }


        public override string ToString()
        {
            return $" ID: {_id}\t Descripcion: {_descripcion}\t Costo: {_costo}\t Precio de Venta: {_precioVenta}\t Stock: {_stock}\t Cargado por usuario: {_idUsuario}";
        }
    }
}
