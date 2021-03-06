﻿using Host_v1.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Host_v1
{
public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }
      

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
 
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "*.txt";
            saveFileDialog.Filter = "txt|*.txt";
         
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
               
                return true;
            }
            return false;
        }
 
        public void ShowMessage(string message)
        {
           MessageBox.Show(message);
          
        }
        public bool ShowMessageOKCancel(string message)
        {
            MessageBoxResult result = MessageBox.Show(message, "Сообщение", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK) return true; else return false;
        }
    }
}
