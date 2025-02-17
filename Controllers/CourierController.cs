using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CourierController : ControllerBase
{
    private readonly ICourierService _couriers;
    public CourierController(ICourierService couriers)
    {
        _couriers = couriers;
    }

    [HttpGet("couriers")]
    [Authorize]
    public async Task<IEnumerable<Courier>>GetAll()
    {
        return await _couriers.GetMultipleAsync();
    }
    
}
