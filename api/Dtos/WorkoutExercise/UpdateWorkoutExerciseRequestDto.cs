namespace api.Dtos.WorkoutExercise
{
    public class UpdateWorkoutExerciseRequestDto
    {
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
    }
}
