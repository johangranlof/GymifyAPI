namespace api.Dtos.Workout
{
    public class UpdateWorkoutRequestDto
    {
        public DateTime Date { get; set; }
        public string Time { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
