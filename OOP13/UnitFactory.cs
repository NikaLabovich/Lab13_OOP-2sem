//Паттерн "Абстрактная фабрика" (Abstract Factory) предоставляет интерфейс
//для создания семейств взаимосвязанных объектоdв
//с определенными интерфейсами без указания конкретных типов данных объектов
namespace OOP13
{
    public abstract class UnitFactory
    {
        public Army Army { get; private set; }

        public UnitFactory(Army army)
        {
            Army = army;
        }

        public abstract Unit CreateUnit();
    }
}