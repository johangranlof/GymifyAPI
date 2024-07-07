using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public string Time { get; set; }

        public string Notes { get; set; } = string.Empty;

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
    }

}