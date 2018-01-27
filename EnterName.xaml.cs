using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace _2048
{
    /// <summary>
    /// Interaction logic for EnterNamexaml.xaml
    /// </summary>

    public partial class EnterNamexaml : Window
    {
        private string Name1;

        public string GetName()
        {
            return this.Name1;
        }

        public EnterNamexaml()
        {
            InitializeComponent();
        }

        private void textBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
                Name.Text = "Enter your name";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Name1 = Name.Text;
            this.Close();
        }
    }
}
