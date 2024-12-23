namespace MedInsight.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Fever { get; set; } = string.Empty;
        public string Cough { get; set; } = string.Empty;
        public string Fatigue { get; set; } = string.Empty;
        public string DifficultyBreathing { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string BloodPressure { get; set; } = string.Empty;
        public string CholesterolLevel { get; set; } = string.Empty;
        public string DiseasePrediction { get; set; } = string.Empty;
    }
}
