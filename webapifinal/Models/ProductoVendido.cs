namespace webapifinal.Models
{
    public class ProductoVendido
    {
        

        private long _id;
        private int _stock;
        private long _idProducto;
        private long _idVenta;


        public long Id { get => _id; set => _id = value; }
        public long IdProducto { get => _idProducto; set => _idProducto = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public long IdVenta { get => _idVenta; set => _idVenta = value; }

        public ProductoVendido() { }

        public ProductoVendido(long idVenta)
        {
            _idVenta = idVenta;
        }

        public override string ToString()
        {
            return $" ID: {_id}\t Stock: {_stock}\t ID Producto: {_idProducto}\t ID Venta: {_idVenta}";
        }

    }
}
