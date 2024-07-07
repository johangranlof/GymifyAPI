using api.Dtos.WorkoutExercise;
using api.Models;

namespace api.Interfaces
{
    public interface IWorkoutExerciseRepository
    {
        Task<IEnumerable<WorkoutExercise>> GetAllAsync();
        Task<WorkoutExercise> GetByIdAsync(int id);
        Task CreateAsync(WorkoutExercise workoutExercise);
        Task<WorkoutExercise> UpdateAsync(int id, UpdateWorkoutExerciseRequestDto workoutExerciseDto);
        Task<WorkoutExercise> DeleteAsync(int id);
    }
}
