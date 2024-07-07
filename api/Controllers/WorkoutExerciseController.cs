using api.Dtos.WorkoutExercise;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/workoutexercise")]
    [ApiController]
    public class WorkoutExerciseController : ControllerBase
    {
        private readonly IWorkoutExerciseRepository _workoutExerciseRepo;

        public WorkoutExerciseController(IWorkoutExerciseRepository workoutExerciseRepo)
        {
            _workoutExerciseRepo = workoutExerciseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workoutExercises = await _workoutExerciseRepo.GetAllAsync();
            var workoutExerciseDtos = workoutExercises.Select(we => we.ToWorkoutExerciseDto());
            return Ok(workoutExerciseDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var workoutExercise = await _workoutExerciseRepo.GetByIdAsync(id);
            if (workoutExercise == null)
            {
                return NotFound();
            }
            return Ok(workoutExercise.ToWorkoutExerciseDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkoutExerciseRequestDto workoutExerciseDto)
        {
            var workoutExerciseModel = workoutExerciseDto.ToWorkoutExerciseFromCreateDto();
            await _workoutExerciseRepo.CreateAsync(workoutExerciseModel);
            return CreatedAtAction(nameof(GetById), new { id = workoutExerciseModel.Id }, workoutExerciseModel.ToWorkoutExerciseDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateWorkoutExerciseRequestDto updateDto)
        {
            var workoutExerciseModel = await _workoutExerciseRepo.UpdateAsync(id, updateDto);
            if (workoutExerciseModel == null)
            {
                return NotFound();
            }
            return Ok(workoutExerciseModel.ToWorkoutExerciseDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var workoutExerciseModel = await _workoutExerciseRepo.DeleteAsync(id);
            if (workoutExerciseModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
