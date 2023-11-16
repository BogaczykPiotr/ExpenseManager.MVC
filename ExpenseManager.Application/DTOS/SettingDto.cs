namespace ExpenseManager.Application.DTOS
{
    public class SettingDto
    {
        public string? Currency { get; set; }
        public string? Language { get; set; }
        public int NumberOfDisplayedActions { get; set; } 
    }
}
