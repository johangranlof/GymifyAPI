using api.Dtos.WorkoutExercise;

namespace api.Dtos.Workout
{
    public class CreateWorkoutRequestDto
    {
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public List<CreateWorkoutExerciseRequestDto> WorkoutExercises { get; set; }

    }
}
