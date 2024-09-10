using api.Data;
using api.Dtos.Exercise;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepo;
        private readonly ApplicationDBContext _context;

        public ExerciseController(ApplicationDBContext context, IExerciseRepository exerciseRepo)
        {
            _exerciseRepo = exerciseRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseRepo.GetAllAsync();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var exercise = await _exerciseRepo.GetByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise.ToExerciseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExerciseRequestDto exerciseDto)
        {
            var existingExercise = await _context.Exercises
                .FirstOrDefaultAsync(e => e.Name == exerciseDto.Name && e.MuscleGroup == exerciseDto.MuscleGroup);

            if (existingExercise != null)
            {
                return Ok(existingExercise.ToExerciseDto());
            }

            var exerciseModel = exerciseDto.ToExerciseFromCreateDto();
            await _exerciseRepo.CreateAsync(exerciseModel);

            return CreatedAtAction(nameof(GetById), new { id = exerciseModel.Id }, exerciseModel.ToExerciseDto());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task <IActionResult> Update([FromRoute] int id, [FromBody] UpdateExerciseRequestDto updateDto)
        {
            var exerciseModel = await _exerciseRepo.UpdateAsync(id, updateDto);

            if (exerciseModel == null)
            {
                return NotFound();
            }

            return Ok(exerciseModel.ToExerciseDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
            var exerciseModel = await _exerciseRepo.DeleteAsync(id);

            if(exerciseModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
