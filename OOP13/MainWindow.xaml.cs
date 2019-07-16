using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OOP13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly Random Random = new Random();

        private Army[] Armies { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double halfWidth = Border.ActualWidth / 2.0;
            Rect leftRect = new Rect(0, 0, halfWidth, Border.ActualHeight);
            Rect rightRect = new Rect(halfWidth, 0, halfWidth, Border.ActualHeight);
            Armies = new Army[]
            {
                new Army(Brushes.Gold, Brushes.Purple, Brushes.Blue, leftRect),
                new Army(Brushes.Silver, Brushes.Green, Brushes.Pink, rightRect)
            };
            Draw();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int armyIndex = Grid.Children.IndexOf(button);
            UnitWindow unitWindow = new UnitWindow(Armies[armyIndex]) { Owner = this };
            unitWindow.ShowDialog();
            Draw();
        }

        private void Draw()
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)Border.ActualWidth, (int)Border.ActualHeight, 96, 96, PixelFormats.Default);
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                foreach (Army army in Armies)
                {
                    foreach (Unit unit in army.Units)
                    {
                        unit.Draw(drawingContext);
                    }
                }
            }
            bitmap.Render(drawingVisual);
            FieldImage.Source = bitmap;
            bitmap.Freeze();
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            while (true)
            {
                foreach (Army army in Armies)
                {
                    foreach (Unit unit in army.Units)
                    {
                        unit.Damaged = false;
                        Rect rect = unit.Rect;
                        rect.X += unit.Velocity.X;
                        rect.Y += unit.Velocity.Y;
                        if (rect.X < 0 || rect.Right > Border.ActualWidth)
                        {
                            unit.Velocity = new Vector(-unit.Velocity.X, unit.Velocity.Y);
                        }
                        else if (rect.Y < 0 || rect.Bottom > Border.ActualHeight)
                        {
                            unit.Velocity = new Vector(unit.Velocity.X, -unit.Velocity.Y);
                        }
                        else
                        {
                            unit.Rect = rect;
                        }
                    }
                }
                for (int i = 0; i < Armies[0].Units.Count; i++)
                {
                    for (int j = 0; j < Armies[1].Units.Count; j++)
                    {
                        Unit unit1 = Armies[0].Units[i];
                        Unit unit2 = Armies[1].Units[j];
                        if (unit1.Rect.IntersectsWith(unit2.Rect))
                        {
                            bool chance1 = Random.NextDouble() < unit1.Agility;
                            bool chance2 = Random.NextDouble() < unit2.Agility;
                            if (chance1)
                            {
                                unit2.Damaged = true;
                                unit2.Health -= unit1.Strength;
                                if (unit2.Health <= 0)
                                {
                                    Armies[1].Units.Remove(unit2);
                                }
                            }
                            if (chance2)
                            {
                                unit1.Damaged = true;
                                unit1.Health -= unit2.Strength;
                                if (unit1.Health <= 0)
                                {
                                    Armies[0].Units.Remove(unit1);
                                    break;
                                }
                            }
                        }
                    }
                }
                Draw();
                await Task.Delay(1);
            }
        }
    }
}