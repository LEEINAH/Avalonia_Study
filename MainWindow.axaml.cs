using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // XAML에서 지정한 Click="OnButtonClick" 함수
        private void OnButtonClick(object? sender, RoutedEventArgs e)
        {
            // x:Name="MyTexlBlock"으로 지정한 컨트롤의 속성을 직접 변경!
            MyTextBlock.Text = "버튼이 클릭되었습니다!";
        }
    }
}