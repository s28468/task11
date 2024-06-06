using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController(AnimalClinicContext context) : ControllerBase
    {
        private readonly AnimalClinicContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAnimalDTO>>> GetAnimals(string orderBy = "Name")
        {
            try
            {
                
                if (orderBy is not "Name" or "Description")
                { return BadRequest("Change your orderBy parameter. You can write only 'Name' or 'Description'"); }

                var animals = await context.Animals
                    .Include(a => a.AnimalType)
                    .ToListAsync();

                var sortedAnimals = orderBy.ToLower() switch
                {
                    "description" => animals.OrderBy(a => a.Description).ToList(),
                    _ => animals.OrderBy(a => a.Name).ToList()
                };

                return sortedAnimals.Select(newAnimals).ToList();
            }
            catch (Exception e)
            {
                var errorResponse = new ErrorResponse
                { Message = "Error when you trying to get animals.",
                    Details = e.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        public class ErrorResponse
        {
            public string Message { get; set; }
            public string Details { get; set; }
        }
        private static GetAnimalDTO newAnimals(Animal animal)
        {
            return new GetAnimalDTO
            { Id = animal.Id,
                Name = animal.Name,
                Description = animal.Description,
                AnimalType = animal.AnimalType.Name };
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAnimalDTO>> GetAnimal(int id)
        {
            try
            {
                var animal = await _context.Animals
                    .Include(a => a.AnimalType)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (animal == null)
                { return NotFound(new { message = "Can not find animal with this id", id }); }

                return Ok(newAnimals(animal));
            }
            catch (Exception e)
            {
                var errorResponse = new ErrorResponse
                { Message = "Error when you trying to get animals.",
                    Details = e.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
        
        private static GetAnimalDTO MapToAnimalDtoWithoutId(Animal animal)
        {
            return new GetAnimalDTO
            { Name = animal.Name,
                Description = animal.Description,
                AnimalType = animal.AnimalType.Name
            }; }
        
        [HttpPost]
        public async Task<ActionResult<Animal>> AddAnimal(AddAnimalDTO addAnimalDto)
        {
            try
            {
                var animalType = await _context.AnimalTypes
                    .FirstOrDefaultAsync(at => at.Name.ToLower() == addAnimalDto.AnimalType.ToLower());

                if (animalType == null)
                { return BadRequest(new { message = "Can not find animal with this type", animalType }); }

                var animal = ToAnimal(addAnimalDto, animalType.Id);
                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, newAnimals(animal));
            }
            catch (Exception e)
            {
                var errorResponse = new ErrorResponse
                { Message = "Error when you trying to get animals.",
                    Details = e.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        private static Animal ToAnimal(AddAnimalDTO addAnimal, int Id)
        {
            return new Animal
            { Name = addAnimal.Name,
                Description = string.IsNullOrEmpty(addAnimal.Description) ? null : addAnimal.Description,
                AnimalTypesId = Id };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnimal(int id, UpdateAnimalDTO updateAnimalDto)
        {
            try
            {
                var animal = await _context.Animals.Include(a => a.AnimalType).FirstOrDefaultAsync(a => a.Id == id);

                if (animal == null)
                { return NotFound(new { message ="Can not find animal with this id", id }); }

                animal.Name = updateAnimalDto.Name;
                animal.Description = string.IsNullOrEmpty(updateAnimalDto.Description) ? null : updateAnimalDto.Description;

                _context.Animals.Update(animal);

                try
                { await _context.SaveChangesAsync();
                    return Ok(newAnimals(animal)); }
                catch (DbUpdateConcurrencyException)
                { return Conflict(new { message = "somebody modified this animal." }); }
            }
            catch (Exception e)
            {
                var errorResponse = new ErrorResponse
                { Message = "Error when you trying to get animals.",
                    Details = e.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            try
            {
                var animal = await _context.Animals.FindAsync(id);

                if (animal == null)
                { return NotFound(new { message = "Can not find animal with this id", id  }); }

                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Deleted animal with this id", id  });
            }
            catch (Exception e)
            {
                var errorResponse = new ErrorResponse
                { Message = "Error when you trying to delet animals",
                    Details = e.Message };

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

    }

}