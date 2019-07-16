using System.Windows;
using static OOP13.MainWindow;

namespace OOP13
{
    public class KingFactory : UnitFactory
    {
        private static readonly Size Size = new Size(30, 30);

        public KingFactory(Army army) : base(army) { }

        public override Unit CreateUnit()
        {
            double x = Random.NextDoubleInRange(Army.SpawnRect.Left, Army.SpawnRect.Right - Size.Width);
            double y = Random.NextDoubleInRange(Army.SpawnRect.Top, Army.SpawnRect.Bottom - Size.Height);
            double velocityX = Random.NextDouble() < 0.5 ? Random.NextDoubleInRange(-3, -2) : Random.NextDoubleInRange(2, 3);
            double velocityY = Random.NextDouble() < 0.5 ? Random.NextDoubleInRange(-3, -2) : Random.NextDoubleInRange(2, 3);
            return new King(Army, new Vector(velocityX, velocityY), new Rect(new Point(x, y), Size), 1000, 5, 0.5);
        }
    }
}