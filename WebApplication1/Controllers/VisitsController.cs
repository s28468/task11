namespace WebApplication1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;

using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class VisitsController : ControllerBase
{
    private readonly AnimalClinicContext _context;

    public VisitsController(AnimalClinicContext context)
    { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
    {
        try
        { var visits = await _context.Visits.OrderBy(v => v.Date).ToListAsync();
            return Ok(visits); }
        catch (Exception e)
        {
            var errorResponse = new ErrorResponse
            { Message = "Error when you trying to get visit. ",
                Details = e.Message };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Details { get; set; }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Visit>> GetVisit(int id)
    {
        try
        {
            var visit = await _context.Visits.FindAsync(id);

            if (visit == null)
            { return NotFound(new { message = "Was not found visit with id: ", id }); }

            return Ok(visit);
        }
        catch (Exception e)
        {
            var errorResponse = new ErrorResponse
            { Message = " Error when you trying to get visit.",
                Details = e.Message };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }


    [HttpPost]
    public async Task<ActionResult<Visit>> PostVisit(Visit visit)
    {
        try
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisit), new { id = visit.Id }, visit);
        }
        catch (Exception e)
        {
            var errorResponse = new ErrorResponse
            {
                Message = "Error when you trying to add visit ",
                Details = e.Message
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> PutVisit(int id, Visit visit)
    {
        if (id != visit.Id)
        {
            return BadRequest(new { message = "Visit ID mismatch." });
        }

        _context.Entry(visit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await VisitExistsAsync(id))
            {
                return NotFound(new { message = "Was not found visit with id: ", id });
            }
            else
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Concurrency error occurred while updating visit.",
                    Details = "Somebody was already modified visit."
                };

                return StatusCode(StatusCodes.Status409Conflict, errorResponse);
            }
        }
        catch (Exception e)
        {
            var errorResponse = new ErrorResponse
            {
                Message = "Error when you trying to updating visit.",
                Details = e.Message
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

    private async Task<bool> VisitExistsAsync(int id)
    {
        return await _context.Visits.AnyAsync(e => e.Id == id);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVisit(int id)
    {
        try
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
            {
                return NotFound(new { message = $"Visit was not found." });
            }

            _context.Visits.Remove(visit);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Visit was successfully deleted." });
        }
        catch (Exception e)
        {
            var errorResponse = new ErrorResponse
            {
                Message = "Error when you trying to delete visit.",
                Details = e.Message
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }

}
