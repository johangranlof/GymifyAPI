using api.Data;
using api.Dtos.WorkoutExercise;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class WorkoutExerciseRepository : IWorkoutExerciseRepository
    {
        private readonly ApplicationDBContext _context;

        public WorkoutExerciseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkoutExercise>> GetAllAsync()
        {
            return await _context.WorkoutExercises.ToListAsync();
        }

        public async Task<WorkoutExercise?> GetByIdAsync(int id)
        {
            return await _context.WorkoutExercises.FindAsync(id);
        }

        public async Task CreateAsync(WorkoutExercise workoutExercise)
        {
            await _context.WorkoutExercises.AddAsync(workoutExercise);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkoutExercise?> UpdateAsync(int id, UpdateWorkoutExerciseRequestDto workoutExerciseDto)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null)
            {
                return null;
            }

            workoutExercise.UpdateWorkoutExerciseFromDto(workoutExerciseDto);
            await _context.SaveChangesAsync();

            return workoutExercise;
        }

        public async Task<WorkoutExercise?> DeleteAsync(int id)
        {
            var workoutExercise = await _context.WorkoutExercises.FindAsync(id);
            if (workoutExercise == null)
            {
                return null;
            }

            _context.WorkoutExercises.Remove(workoutExercise);
            await _context.SaveChangesAsync();

            return workoutExercise;
        }
    }
}
