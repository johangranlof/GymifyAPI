namespace api.Dtos.WorkoutExercise
{
    public class CreateWorkoutExerciseRequestDto
    {
        public int ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}
