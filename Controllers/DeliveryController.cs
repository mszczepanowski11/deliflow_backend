using DeliflowRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DeliveryController : ControllerBase
{
    private readonly IDeliveryService _deliveries;
    public DeliveryController(IDeliveryService deliveries)
    {
        _deliveries = deliveries;
    }

    [HttpGet("deliveries")]
    // [Authorize]
    public async Task<IEnumerable<Delivery>>GetAll(int? courierId, string? dateOfDelivery)
    {
        return await _deliveries.GetMultipleAsync(courierId,dateOfDelivery);
    }

    [HttpPost("deliveries")]
    public async Task<Delivery> AddAsync([FromBody] DeliveryRequest delivery)
    { 
        var result  =  await _deliveries.AddAsync(delivery);
        return result; 
    }
}