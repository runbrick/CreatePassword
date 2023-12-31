﻿using System;
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

namespace CreatePassword
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击生成密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string charactersCheckText = string.Empty;
            if (excludeCharactersCheck.IsChecked == true)
            {
                charactersCheckText = CharactersCheckText.Text;
            }
            string v = PasswordGenerator.GeneratePassword(
                Int32.Parse(PasswordCount.Text),
                charactersCheckText, 
                LowerCaseCheck.IsChecked == true,
                UpperCaseCheck.IsChecked == true,
                DigitsCheck.IsChecked == true,
                SpecialCharactersCheck.IsChecked == true
                );
            PasswordResult.Text = v;
        }
    }
}
