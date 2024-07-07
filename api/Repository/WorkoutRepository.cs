using api.Data;
using api.Dtos.Exercise;
using api.Dtos.Workout;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace api.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDBContext _context;

        public WorkoutRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Workout> CreateAsync(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
            await _context.SaveChangesAsync();
            return workout;
        }

        public async Task<Workout?> DeleteAsync(int id)
        {
            var workout = await _context.Workouts
                        .Include(w => w.WorkoutExercises)
                        .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return null;
            }

            _context.WorkoutExercises.RemoveRange(workout.WorkoutExercises);

            _context.Workouts.Remove(workout);

            await _context.SaveChangesAsync();

            return workout;
        }

        public async Task<List<Workout>> GetAllAsync()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout?> GetByIdAsync(int id)
        {
            return await _context.Workouts
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<List<Workout>> GetByUserIdAsync(int userId)
        {
            var workouts = await _context.Workouts
                    .Where(w => w.UserId == userId)
                    .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                    .ToListAsync();
            return workouts;
        }

        public async Task<IEnumerable<ExerciseDto>> GetExercisesWithStatsAsync(int userId)
        {
            var workouts = await _context.Workouts
                .Where(w => w.UserId == userId)
                .Include(w => w.WorkoutExercises)
                .ThenInclude(we => we.Exercise)
                .ToListAsync();

            var exerciseStats = workouts
                .SelectMany(w => w.WorkoutExercises
                    .Select(we => new
                    {
                        Id = we.ExerciseId,
                        ExerciseName = we.Exercise.Name,
                        ExerciseMuscleGroup = we.Exercise.MuscleGroup,
                        we.Weight,
                        WorkoutDate = w.Date
                    })
                )
                .GroupBy(we => we.Id)
                .Select(g => new ExerciseDto
                {
                    Id = (int)g.Key,
                    Name = g.FirstOrDefault()?.ExerciseName ?? "Unknown",
                    MuscleGroup = g.FirstOrDefault()?.ExerciseMuscleGroup ?? "Unknown",
                    Latest = g.OrderByDescending(we => we.WorkoutDate).FirstOrDefault()?.Weight ?? 0,
                    PersonalBest = g.Max(we => we.Weight)
                });

            return exerciseStats;
        }

        public async Task<Workout?> UpdateAsync(int id, UpdateWorkoutRequestDto workoutDto)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return null;
            }

            workout.UpdateWorkoutFromDto(workoutDto);
            await _context.SaveChangesAsync();

            return workout;
        }
    }
}
