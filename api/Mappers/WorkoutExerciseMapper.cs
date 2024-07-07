using api.Dtos.WorkoutExercise;
using api.Models;

namespace api.Mappers
{
    public static class WorkoutExerciseMapper
    {
        public static WorkoutExerciseDto ToWorkoutExerciseDto(this WorkoutExercise workoutExercise)
        {
            return new WorkoutExerciseDto
            {
                Id = workoutExercise.Id,
                Sets = workoutExercise.Sets,
                Reps = workoutExercise.Reps,
                Weight = workoutExercise.Weight,
                Exercise = workoutExercise.Exercise?.ToExerciseDto()
            };
        }

        public static WorkoutExercise ToWorkoutExerciseFromCreateDto(this CreateWorkoutExerciseRequestDto dto)
        {
            return new WorkoutExercise
            {
                ExerciseId = dto.ExerciseId,
                Sets = dto.Sets,
                Reps = dto.Reps,
                Weight = dto.Weight
            };
        }

        public static void UpdateWorkoutExerciseFromDto(this WorkoutExercise workoutExercise, UpdateWorkoutExerciseRequestDto dto)
        {
            workoutExercise.Sets = dto.Sets;
            workoutExercise.Reps = dto.Reps;
            workoutExercise.Weight = dto.Weight;
        }
    }
}
