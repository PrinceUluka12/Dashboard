namespace Dashboard.Server.Models
{
   public class Order
{
    public int OrderID { get; set; }
    public string CustomerName { get; set; }
    public double TotalAmount { get; set; }
    public string OrderItems { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
    public string StatusBg { get; set; }
    public string ProductImage { get; set; }
}
}