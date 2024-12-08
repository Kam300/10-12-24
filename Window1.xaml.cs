using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes; //Rectangle

namespace WpfApp3
{
    public partial class Window1 : Window
    {
        private bool isDragging = false;
        private Point clickPosition;
        private UIElement draggingElement;

        public Window1()
        {
            InitializeComponent();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Нач перетас
            if (e.OriginalSource is Rectangle rectangle)
            {
                isDragging = true;
                draggingElement = rectangle;
                clickPosition = e.GetPosition(rectangle);
                Mouse.Capture(rectangle); // Захват мышь
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggingElement != null)
            {
                // Перемещение 
                Point mousePosition = e.GetPosition(canvas);
                double left = mousePosition.X - clickPosition.X;
                double top = mousePosition.Y - clickPosition.Y;

                // Ограничение 
                if (left < 0) left = 0;
                if (top < 0) top = 0;
                if (left + ((Rectangle)draggingElement).Width > canvas.ActualWidth)
                    left = canvas.ActualWidth - ((Rectangle)draggingElement).Width;
                if (top + ((Rectangle)draggingElement).Height > canvas.ActualHeight)
                    top = canvas.ActualHeight - ((Rectangle)draggingElement).Height;

                Canvas.SetLeft(draggingElement, left);
                Canvas.SetTop(draggingElement, top);
            }
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // конец перетаскивание
            if (isDragging)
            {
                isDragging = false;
                draggingElement = null;
                Mouse.Capture(null); // Освоб захв мыши
            }
        }
    }
}
