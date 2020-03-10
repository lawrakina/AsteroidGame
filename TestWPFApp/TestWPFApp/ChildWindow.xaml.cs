using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWPFApp
{
    /// <summary>
    /// Логика взаимодействия для ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        public ChildWindow()
        {
            InitializeComponent();
        }
        public Employee employee { get; set; }
        public Departament departament { get; set; }

        private void buttonSaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            employee.Age = Int32.Parse(textBoxAge.Text);
            employee.Name = textBoxName.Text;
            Close();
        }

        private void comboBoxDepartaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            departament = (Departament)comboBox.SelectedItem;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
