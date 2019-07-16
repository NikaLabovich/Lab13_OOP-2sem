using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace OOP13
{
    public class Army
    {
        public static readonly Pen UnitPen = new Pen(Brushes.Black, 2);

        public Brush KingBrush { get; private set; }
        public Brush WarriorBrush { get; private set; }
        public Brush BanditBrush { get; private set; }
        public UnitFactory[] UnitFactories { get; private set; }
        public List<Unit> Units { get; private set; } = new List<Unit>();
        public Rect SpawnRect { get; set; }

        public Army(Brush kingBrush, Brush warriorBrush, Brush banditBrush, Rect spawnRect)
        {
            UnitPen.Freeze();
            kingBrush.Freeze();
            warriorBrush.Freeze();
            banditBrush.Freeze();
            KingBrush = kingBrush;
            WarriorBrush = warriorBrush;
            BanditBrush = banditBrush;
            SpawnRect = spawnRect;
            UnitFactories = new UnitFactory[]
            {
                new WarriorFactory(this),
                new BanditFactory(this)
            };
            KingFactory kingFactory = new KingFactory(this);
            Units.Add(kingFactory.CreateUnit());
        }
    }
}