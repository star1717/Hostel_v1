using Host_v1.ViewModel;
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

namespace Host_v1.View
{
    /// <summary>
    /// Логика взаимодействия для NumbersView.xaml
    /// </summary>
    public partial class NumbersView : Window
    {
        public NumbersView(Model1 db)
        {
            InitializeComponent();
            DataContext = new NumbersViewModel(db);
        }
    }
}
