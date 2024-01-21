using Microsoft.AspNetCore.Mvc;
using SafeCampus.Models;
using SafeCampus.Services;

[ApiController]
[Route("api/[controller]")]
public class LaptopController : ControllerBase
{
    private readonly LaptopService _laptopService;

    public LaptopController(LaptopService laptopService)
    {
        _laptopService = laptopService;
    }

    // GET: api/laptop
    [HttpGet]
    public async Task<ActionResult<List<Laptop>>> GetAsync()
    {
        var laptops = await _laptopService.GetAsync();

        return Ok(laptops);
    }

    // GET: api/laptop/{id}
    [HttpGet("{id:length(24)}", Name = "GetLaptop")]
    public async Task<ActionResult<Laptop>> GetAsync(string id)
    {
        var laptop = await _laptopService.GetAsync(id);

        if (laptop == null)
        {
            return NotFound();
        }

        return Ok(laptop);
    }

    // POST: api/laptop
    [HttpPost]
    public async Task<ActionResult<Laptop>> CreateAsync([FromBody] Laptop newLaptop)
{
    try
    {
        await _laptopService.CreateAsync(newLaptop);
        return CreatedAtRoute("GetLaptop", new { id = newLaptop.Id }, newLaptop);
    }
    catch (Exception ex)
    {
        // Log the exception
        Console.WriteLine($"Error creating laptop: {ex.Message}");
        return StatusCode(500, "Internal server error");
    }
}


    // PUT: api/laptop/{id}
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] Laptop updatedLaptop)
    {
        var existingLaptop = await _laptopService.GetAsync(id);

        if (existingLaptop == null)
        {
            return NotFound();
        }

        await _laptopService.UpdateAsync(id, updatedLaptop);
        return NoContent();
    }

    // DELETE: api/laptop/{id}
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> RemoveAsync(string id)
    {
        var laptop = await _laptopService.GetAsync(id);

        if (laptop == null)
        {
            return NotFound();
        }

        await _laptopService.RemoveAsync(id);
        return NoContent();
    }
}
