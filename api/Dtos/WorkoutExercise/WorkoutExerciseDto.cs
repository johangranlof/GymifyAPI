using api.Dtos.Exercise;

namespace api.Dtos.WorkoutExercise
{
    public class WorkoutExerciseDto
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }

        public ExerciseDto Exercise { get; set; }

    }
}
