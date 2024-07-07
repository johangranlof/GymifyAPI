using api.Data;
using api.Dtos.Exercise;
using api.Dtos.Workout;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApplicationDBContext _context;

        public ExerciseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Exercise> CreateAsync(Exercise exerciseModel)
        {
            await _context.Exercises.AddAsync(exerciseModel);
            await _context.SaveChangesAsync();
            return exerciseModel;
        }

        public async Task<Exercise?> DeleteAsync(int id)
        {
            var exerciseModel = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
            if (exerciseModel == null)
            {
                return null;
            }

            _context.Exercises.Remove(exerciseModel);
            await _context.SaveChangesAsync();
            return exerciseModel;
        }

        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise?> UpdateAsync(int id, UpdateExerciseRequestDto exerciseDto)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);

            if (exercise == null)
            {
                return null;
            }

            exercise.UpdateExerciseFromDto(exerciseDto);
            await _context.SaveChangesAsync();

            return exercise;
        }
    }
}
