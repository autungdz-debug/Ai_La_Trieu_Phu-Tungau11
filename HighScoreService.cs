using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AiLaTrieuPhu.Models;

namespace AiLaTrieuPhu.Services
{
    public class HighScoreService
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "highscores.json");

        public static List<HighScore> LoadHighScores()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    var list = JsonSerializer.Deserialize<List<HighScore>>(json);
                    if (list != null)
                    {
                        return list.OrderByDescending(x => x.PrizeMoney).ThenByDescending(x => x.QuestionsAnswered).Take(10).ToList();
                    }
                }
            }
            catch { }
            var defaults = new List<HighScore>
            {
                new HighScore { PlayerName = "Âu Nguyễn Quang Tùng", PrizeMoney = 150000000, QuestionsAnswered = 15, DateAchieved = DateTime.Now.AddDays(-5) },
                new HighScore { PlayerName = "Trịnh Bách Tuấn", PrizeMoney = 40000000, QuestionsAnswered = 12, DateAchieved = DateTime.Now.AddDays(-3) },
                new HighScore { PlayerName = "Lê Hoàng Minh", PrizeMoney = 22000000, QuestionsAnswered = 10, DateAchieved = DateTime.Now.AddDays(-2) },
                new HighScore { PlayerName = "Phạm Thu Trang", PrizeMoney = 10000000, QuestionsAnswered = 8, DateAchieved = DateTime.Now.AddDays(-1) },
                new HighScore { PlayerName = "Đỗ Hải Đăng", PrizeMoney = 2000000, QuestionsAnswered = 5, DateAchieved = DateTime.Now }
            };
            SaveHighScores(defaults);
            return defaults;
        }

        public static void SaveHighScores(List<HighScore> scores)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(scores, options);
                File.WriteAllText(FilePath, json);
            }
            catch { }
        }

        public static void AddScore(string playerName, long prizeMoney, int questionsAnswered)
        {
            var scores = LoadHighScores();
            scores.Add(new HighScore
            {
                PlayerName = string.IsNullOrWhiteSpace(playerName) ? "Người chơi" : playerName.Trim(),
                PrizeMoney = prizeMoney,
                QuestionsAnswered = questionsAnswered,
                DateAchieved = DateTime.Now
            });

            var topScores = scores.OrderByDescending(x => x.PrizeMoney)
                                  .ThenByDescending(x => x.QuestionsAnswered)
                                  .Take(10)
                                  .ToList();
            SaveHighScores(topScores);
        }
    }
}