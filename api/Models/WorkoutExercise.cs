using api.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class WorkoutExercise
{
    public int Id { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }

    [ForeignKey("WorkoutId")]
    public int? WorkoutId { get; set; }
    public Workout? Workout { get; set; }

    [ForeignKey("ExerciseId")]
    public int? ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Weight { get; set; }
}
