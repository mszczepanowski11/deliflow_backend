

public class Delivery
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Address { get; set; }
    public DateOnly DateOfDelivery { get; set; }
    public Courier Courier { get; set; }
}


