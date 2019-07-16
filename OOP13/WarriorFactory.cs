using System.Windows;
using static OOP13.MainWindow;

namespace OOP13
{
    public class WarriorFactory : UnitFactory
    {
        private static readonly Size Size = new Size(20, 20);

        public WarriorFactory(Army army) : base(army) { }

        public override Unit CreateUnit()
        {
            double x = Random.NextDoubleInRange(Army.SpawnRect.Left, Army.SpawnRect.Right - Size.Width);
            double y = Random.NextDoubleInRange(Army.SpawnRect.Top, Army.SpawnRect.Bottom - Size.Height);
            double velocityX = Random.NextDouble() < 0.5 ? Random.NextDoubleInRange(-2, -1) : Random.NextDoubleInRange(1, 2);
            double velocityY = Random.NextDouble() < 0.5 ? Random.NextDoubleInRange(-2, -1) : Random.NextDoubleInRange(1, 2);
            return new Warrior(Army, new Vector(velocityX, velocityY), new Rect(new Point(x, y), Size), 500, 3, 0.3);
        }
    }
}