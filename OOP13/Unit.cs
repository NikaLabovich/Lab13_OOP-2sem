//определяют интерфейс для классов, объекты которых будут создаваться в программе
using System.Windows;
using System.Windows.Media;

namespace OOP13
{
    public abstract class Unit
    {
        public Rect Rect { get; set; }
        public bool Damaged { get; set; }
        public double Health { get; set; }
        public Vector Velocity { get; set; }
        public double Strength { get; private set; }
        public double Agility { get; private set; }
        public Army Army { get; private set; }

        public Unit(Army army, Vector velocity, Rect rect, double health, double strength, double agility)
        {
            Army = army;
            Rect = rect;
            Health = health;
            Velocity = velocity;
            Strength = strength;
            Agility = agility;
        }

        public abstract void Draw(DrawingContext drawingContext);
    }
}