using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1
{
    class ViewModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Addclient()
        {
            MessageBox.Show("Новый объект добавлен!");
            //try
            //{
            //    Client driver = new Client
            //    {
            //        Kod_driver = Convert.ToInt32(numericUpDown1.Value),
            //        Family_name = textBox2.Text,
            //        Name = textBox3.Text,
            //        Last_name = textBox4.Text
            //    };
            //    Form1.db.Drivers.Add(driver);
            //    Form1.db.SaveChanges();

            //    MessageBox.Show("Новый объект добавлен!");
            //    textBox3.Text = "";
            //    textBox2.Text = "";
            //    textBox4.Text = "";
            //    numericUpDown1.Value = 0;
            //}
            //catch
            //{
            //    MessageBox.Show("Объект не может быть добавлен!");
            //}
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //public CommandID one { get; } = new DelegateCommand(Addclient);
    }
}
