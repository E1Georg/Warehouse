namespace Warehouse.Domain
{
    public class Box
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public DateTime expiration_date { get; set; }
        public DateTime production_date { get; set; }

        public Guid PalletID { get; set; }        
        public Pallet Pallet { get; set; }
    }
}
