using api.Dtos.Workout;
using api.Dtos.WorkoutExercise;
using api.Models;

namespace api.Mappers
{
    public static class WorkoutMapper
    {
        public static WorkoutDto ToWorkoutDto(this Workout workout)
        {
            return new WorkoutDto
            {
                Id = workout.Id,
                UserId = workout.UserId,
                Date = workout.Date,
                Time = workout.Time,
                Notes = workout.Notes,
                WorkoutExercises = workout.WorkoutExercises?.Select(we => we.ToWorkoutExerciseDto()).ToList() ?? new List<WorkoutExerciseDto>()
            };
        }

        public static Workout ToWorkoutFromCreateDto(this CreateWorkoutRequestDto dto)
        {
            return new Workout
            {
                UserId = dto.UserId,
                Date = dto.Date,
                Time = dto.Time,
                Notes = dto.Notes,
                WorkoutExercises = dto.WorkoutExercises.Select(weDto => new WorkoutExercise
                {
                    ExerciseId = weDto.ExerciseId,
                    Sets = weDto.Sets,
                    Reps = weDto.Reps,
                    Weight = weDto.Weight
                }).ToList()
            };
        }

        public static void UpdateWorkoutFromDto(this Workout workout, UpdateWorkoutRequestDto dto)
        {
            workout.Date = dto.Date;
            workout.Time = dto.Time;
            workout.Notes = dto.Notes;
        }
    }
}

