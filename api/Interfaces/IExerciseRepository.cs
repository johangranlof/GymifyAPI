using api.Dtos.Exercise;
using api.Models;

namespace api.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllAsync();
        Task<Exercise?> GetByIdAsync(int id);
        Task<Exercise> CreateAsync(Exercise exerciseModel);
        Task<Exercise?> UpdateAsync(int id, UpdateExerciseRequestDto exerciseDto);
        Task<Exercise?> DeleteAsync(int id);
    }
}
