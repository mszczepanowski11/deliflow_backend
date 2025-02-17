public class Courier
{
    public int Id {get;set;}
    public string Name{get;set;}
    public string Surname {get;set;}
    public List<Delivery> Deliveries {get;} = new();
}

