using System.Windows;
using System.Windows.Media;

namespace OOP13
{
    public class King : Unit
    {
        public King(Army army, Vector velocity, Rect rect, double health, double strength, double agility) : base(army, velocity, rect, health, strength, agility) { }

        public override void Draw(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(Damaged ? Brushes.Red : Army.KingBrush, Army.UnitPen, Rect);
        }
    }
}