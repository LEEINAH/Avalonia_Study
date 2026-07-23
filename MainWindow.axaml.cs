using Avalonia.Controls;
using Avalonia.Controls.Shapes; // 도형(Rectangle, Line 등) 사용에 필수
using Avalonia.Interactivity;
using Avalonia.Media;           // Brushes 색상 사용에 필수
using SkiaSharp;

namespace AvaloniaTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAddRectangleClick(object? sender, RoutedEventArgs e)
        {
            // 사각형 객체 생성
            var rect = new Rectangle
            {
                Width = 100,
                Height = 60,
                Fill = Brushes.DodgerBlue,  // 채우기 색상
                Stroke = Brushes.White,     // 테두리 색상
                StrokeThickness = 2         // 테두리 두께
            };

            // Canvas 상의 위치 설정 (X: 50, Y: 50)
            Canvas.SetLeft(rect, 50);
            Canvas.SetTop(rect, 50);

            // Canvas 자식 목록에 추가하여 화면에 그리기
            MyCanvas.Children.Add(rect);    
        }
    }
}