using System.Windows;
using static OOP13.MainWindow;

namespace OOP13
{
    public class BanditFactory : UnitFactory
    {
        private static readonly Size Size = new Size(14, 14);

        public BanditFactory(Army army) : base(army) { }

        public override Unit CreateUnit()
        {
            double x = Random.NextDoubleInRange(Army.SpawnRect.Left, Army.SpawnRect.Right - Size.Width);
            double y = Random.NextDoubleInRange(Army.SpawnRect.Top, Army.SpawnRect.Bottom - Size.Height);
            double velocityX = Random.NextDouble() < 0.5 ? Random.NextDoubleInRange(-4, -3) : Random.NextDoubleInRange(3, 4);
            double velocityY = Random.NextDouble() < 0.5 ? Random.NextDoubleInRange(-4, -3) : Random.NextDoubleInRange(3, 4);
            return new Bandit(Army, new Vector(velocityX, velocityY), new Rect(new Point(x, y), Size), 300, 2, 0.9);
        }
    }
}