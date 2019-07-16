using System.Windows;

namespace OOP13
{
    /// <summary>
    /// Логика взаимодействия для UnitWindow.xaml
    /// </summary>
    public partial class UnitWindow : Window
    {
        private Army Army { get; set; }

        public UnitWindow(Army army)
        {
            InitializeComponent();
            Army = army;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UnitFactory unitFactory = Army.UnitFactories[ComboBox.SelectedIndex];
            for (int i = 0; i < Slider.Value; i++)
            {
                Army.Units.Add(unitFactory.CreateUnit());
            }
            Close();
        }
    }
}