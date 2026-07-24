using Avalonia.Controls;
using Avalonia.Controls.Shapes; // 도형(Rectangle, Line 등) 사용에 필수
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;           // Brushes 색상 사용에 필수
using SkiaSharp;
using System;
using Avalonia;

namespace AvaloniaTest
{
    public partial class MainWindow : Window
    {
        private bool _isDrawing;
        private Point _startPoint;
        private Rectangle? _currentRect;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCanvasPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            _isDrawing = true;
            _startPoint = e.GetPosition(MyCanvas);

            // 1. 마우스를 누르는 순간 미리 사각형을 생성해서 Canvas에 추가
            _currentRect = new Rectangle
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Colors.Red, 0.2),
                Width = 0,
                Height = 0
            };

            Canvas.SetLeft(_currentRect, _startPoint.X);
            Canvas.SetTop(_currentRect, _startPoint.Y);

            MyCanvas.Children.Add(_currentRect);

            e.Pointer.Capture(MyCanvas);
        }

        private void OnCanvasPointerMoved(object? sender, PointerEventArgs e)
        {
            // 드로잉 중이 아니거나 생성된 사각형이 없으면 무시
            if (!_isDrawing || _currentRect == null) return;

            var currentPoint = e.GetPosition(MyCanvas);

            // 2. 마우스 이동에 따라 좌표 및 크기 실시간 업데이트
            double left = Math.Min(_startPoint.X, currentPoint.X);
            double top = Math.Min(_startPoint.Y, currentPoint.Y);
            double width = Math.Abs(currentPoint.X - _startPoint.X);
            double height = Math.Abs(currentPoint.Y - _startPoint.Y);

            _currentRect.Width = width;
            _currentRect.Height = height;

            Canvas.SetLeft(_currentRect, left);
            Canvas.SetTop(_currentRect, top);
        }

        private void OnCanvasPointerReleased(object? sender, PointerReleasedEventArgs e)
        {
            if (!_isDrawing) return;

            _isDrawing = false;
            e.Pointer.Capture(null);

            // 3. 드래그 거리가 너무 작으면(단순 클릭) 생성했던 사각형 삭제
            if (_currentRect != null)
            {
                if (_currentRect.Width < 3 || _currentRect.Height < 3)
                {
                    MyCanvas.Children.Remove(_currentRect);
                }
            }

            _currentRect = null; // 참조 초기화
        }
    }
}
