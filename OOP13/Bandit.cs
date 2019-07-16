using System.Windows;
using System.Windows.Media;

namespace OOP13
{
    public class Bandit : Unit
    {
        public Bandit(Army army, Vector velocity, Rect rect, double health, double strength, double agility) : base(army, velocity, rect, health, strength, agility) { }

        public override void Draw(DrawingContext drawingContext)
        {
            double radiusX = Rect.Width / 2.0;
            double radiusY = Rect.Height / 2.0;
            double centerX = Rect.X + radiusX;
            double centerY = Rect.Y + radiusY;
            Point center = new Point(centerX, centerY);
            drawingContext.DrawEllipse(Damaged ? Brushes.Red : Army.BanditBrush, Army.UnitPen, center, radiusX, radiusY);
        }
    }
}