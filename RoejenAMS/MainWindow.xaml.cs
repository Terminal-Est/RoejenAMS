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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoejenAMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button();
        }

        private void Button()
        {
            string hello= "";
            DataAccess db = new DataAccess();
            hello = db.SelectQuery();
            B1.Content = hello;
        }

        private void B1_OnClick(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            db.CreateTable();
        }

        private void B2_OnClick(object sender, RoutedEventArgs e)
        {
            string textOne = T1.Text;
            string textTwo = T2.Text;
            DataAccess db = new DataAccess();
            db.InsertIntoTab(textOne, textTwo);
        }

    }
}
