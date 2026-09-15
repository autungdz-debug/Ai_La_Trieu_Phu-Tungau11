using System.Windows;
using AiLaTrieuPhu.Services;

namespace AiLaTrieuPhu.Views
{
    public partial class HighScoreWindow : Window
    {
        public HighScoreWindow()
        {
            InitializeComponent();
            LoadScores();
        }

        private void LoadScores()
        {
            var scores = HighScoreService.LoadHighScores();
            dgScores.ItemsSource = scores;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgScores_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}