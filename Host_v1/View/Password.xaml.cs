﻿using Host_v1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        [DllImport("user32.dll")]
        static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        private const int GWL_STYLE = -16;

        private const uint WS_SYSMENU = 0x80000;

        protected override void OnSourceInitialized(EventArgs e)
        {
            IntPtr hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE,
                GetWindowLong(hwnd, GWL_STYLE) & (0xFFFFFFFF ^ WS_SYSMENU));

            base.OnSourceInitialized(e);
        }
        public Password()
        {
            InitializeComponent();
           
            PasswordViewModel vm=new PasswordViewModel();
            DataContext = vm;            
        }
    }
}
