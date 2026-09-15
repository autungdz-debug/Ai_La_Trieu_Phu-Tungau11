using System;

namespace AiLaTrieuPhu.Models
{
    public class HighScore
    {
        public string PlayerName { get; set; } = "Người chơi";
        public long PrizeMoney { get; set; }
        public int QuestionsAnswered { get; set; }
        public DateTime DateAchieved { get; set; } = DateTime.Now;
        public string PrizeFormatted => $"{PrizeMoney:N0} VNĐ";
        public string DateFormatted => DateAchieved.ToString("dd/MM/yyyy HH:mm");
    }
}