using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();

            var horizontal_binding = new Binding();
            horizontal_binding.ElementName = "HorisontalSlider";
            horizontal_binding.Path = new PropertyPath("Value");

            HorisontalValue.SetBinding(TextBlock.TextProperty, horizontal_binding);

            var vertical_binding = new Binding();
            vertical_binding.ElementName = "VerticalSlider";
            vertical_binding.Path = new PropertyPath("Value");

            VerticalValue.SetBinding(TextBlock.TextProperty, vertical_binding);


        }
        //создано не показано на экране
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }
    }
}
