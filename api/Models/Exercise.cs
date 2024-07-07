using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string MuscleGroup { get; set; } = string.Empty;
    }

}