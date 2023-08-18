namespace Warehouse.Domain
{
    public class Pallet
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public DateTime? expiration_date { get; set; }

        public List<Box>? Boxes { get; set; }
    }
}
