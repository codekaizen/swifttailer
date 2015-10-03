﻿using System.Collections.Generic;
using System.Windows;
using SwiftTailer.Wpf.Commands;
using SwiftTailer.Wpf.Models.Observable;
using SwiftTailer.Wpf.ViewModels;

namespace SwiftTailer.Wpf.Pages
{
    /// <summary>
    /// Interaction logic for ViewSelectionWindow.xaml
    /// </summary>
    public partial class ViewSelectionWindow : Window
    {
        public ViewSelectionWindow(IEnumerable<LogLine> logLines)
        {
            InitializeComponent();

            var vm = new ViewSelectionViewModel();
            DataContext = vm;

            vm.LogLines = logLines;
        }

        private void CompareClipboard_Click(object sender, RoutedEventArgs e)
        {
            StaticCommands.CompareToClipboardCommand.Execute(ContentBox);
        }

        private void PingIpAddress_Click(object sender, RoutedEventArgs e)
        {
            StaticCommands.PingSelectionCommand.Execute(ContentBox);
        }
    }
}