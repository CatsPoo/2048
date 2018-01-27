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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System;

namespace _2048
{
    public partial class HighScores : Window
    {

        public HighScores()
        {
            InitializeComponent();
            try
            {
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
     
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
