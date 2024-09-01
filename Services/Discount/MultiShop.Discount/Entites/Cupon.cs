namespace MultiShop.Discount.Entites
{
    public class Cupon
    {
        public int CuponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
