using Microsoft.EntityFrameworkCore;

public class DeliflowDbContext : DbContext
{
    public DeliflowDbContext(DbContextOptions<DeliflowDbContext> options) : base(options) {}
    

    public DbSet<Forwarder>       Forwarders { get; set; }
    public DbSet<Courier>         Couriers { get; set; }
    public DbSet<Delivery>        Deliveries { get; set; }
    public DbSet<Route>           Routes {get;set;}
    public DbSet<RouteDeliveries> RouteDeliveries {get;set;}
    
}