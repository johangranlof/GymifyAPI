using api.Dtos.Workout;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/workout")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutRepository _workoutRepo;

        public WorkoutController(IWorkoutRepository workoutRepo)
        {
            _workoutRepo = workoutRepo;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserID([FromRoute] int id)
        {
            var workouts = await _workoutRepo.GetByUserIdAsync(id);
            var workoutDtos = workouts.Select(w => w.ToWorkoutDto());
            return Ok(workoutDtos);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workouts = await _workoutRepo.GetAllAsync();
            var workoutDtos = workouts.Select(w => w.ToWorkoutDto());
            return Ok(workoutDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var workout = await _workoutRepo.GetByIdAsync(id);
            if (workout == null)
            {
                return NotFound();
            }
            return Ok(workout.ToWorkoutDto());
        }

        [HttpGet("user/{id}/exercises")]
        public async Task<IActionResult> GetExercisesWithStats([FromRoute] int id)
        {
            var exerciseStats = await _workoutRepo.GetExercisesWithStatsAsync(id);
            return Ok(exerciseStats);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkoutRequestDto workoutDto)
        {
            var workoutModel = new Workout
            {
                UserId = workoutDto.UserId,
                Date = workoutDto.Date,
                Time = workoutDto.Time,
                Notes = workoutDto.Notes,
                WorkoutExercises = workoutDto.WorkoutExercises.Select(we => new WorkoutExercise
                {
                    ExerciseId = we.ExerciseId,
                    Sets = we.Sets,
                    Reps = we.Reps,
                    Weight = we.Weight
                }).ToList()
            };

            await _workoutRepo.CreateAsync(workoutModel);
            return CreatedAtAction(nameof(GetById), new { id = workoutModel.Id }, workoutModel.ToWorkoutDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateWorkoutRequestDto updateDto)
        {
            var workoutModel = await _workoutRepo.UpdateAsync(id, updateDto);
            if (workoutModel == null)
            {
                return NotFound();
            }
            return Ok(workoutModel.ToWorkoutDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var workoutModel = await _workoutRepo.DeleteAsync(id);
            if (workoutModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
