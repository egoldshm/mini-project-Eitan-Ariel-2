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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddLessonToTrainee.xaml
    /// </summary>
    public partial class AddLessonToTrainee : UserControl
    {
        public AddLessonToTrainee()
        {
            InitializeComponent();
        }

        private void trainee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addLesson.Content = trainee.SelectionBoxItem 
        }
    }
}
