using api.Dtos.Exercise;
using api.Dtos.Workout;
using api.Models;

namespace api.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetAllAsync();
        Task<Workout?> GetByIdAsync(int id);
        Task<Workout> CreateAsync(Workout workoutModel);
        Task<Workout?> UpdateAsync(int id, UpdateWorkoutRequestDto workoutDto);
        Task<Workout?> DeleteAsync(int id);
        Task<List<Workout>> GetByUserIdAsync(int userId);
        Task<IEnumerable<ExerciseDto>> GetExercisesWithStatsAsync(int userId);


    }
}
