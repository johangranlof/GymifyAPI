using api.Dtos.WorkoutExercise;
using api.Models;

namespace api.Dtos.Workout
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public List<WorkoutExerciseDto> WorkoutExercises { get; set; }
    }
}
