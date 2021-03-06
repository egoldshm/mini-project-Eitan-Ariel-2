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
using System.Windows.Shapes;
using Ibl;
using BE;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for TraineeMainWindow.xaml
    /// </summary>
    public partial class TraineeMainWindow : Window
    {
        Ibl.IBL bl = factoryBL.FactoryBL.GetBL();
        Trainee trainee;
        public TraineeMainWindow(User user)
        {
            InitializeComponent();
            if (user.role == User.RoleTypes.Admin)
            {
                trainee = user.ConnectTo as Trainee;
                title.user = user;
                if (trainee == null)
                {
                    throw new Exception("worng user sended to trainee");
                }
            }
            else if (user.role != User.RoleTypes.Trainee || !(user.ConnectTo is Trainee))
            {
                throw new Exception("worng user sended to trainee");
            }
            else
                trainee = new Trainee(user.ConnectTo as Trainee);

            details.DataContext = trainee;
            updateTrainee_uc.Trainee = trainee;
            updateTrainee_uc.idTextBox.IsEnabled = false;
            updateTrainee_uc.button.Click += updateTrainee_click;

            //set view tests only for this tester
            var list = new List<Trainee>(); list.Add(trainee);
            viewTests_uc.setTraineeExist = list;
            viewTests_uc.trainee.SelectedValue = trainee;
            viewTests_uc.trainee.IsEnabled = false;

            //set trainee for add lesson
            AddLessonToTrainee_uc.setTrainee(trainee);

            setTestModeAndThUsercontrol();

            title.user = user;
        }

        private void setTestModeAndThUsercontrol()
        {
            if (bl.GetAllTraineesByLicense(true).Exists(_trainee => _trainee.Id == trainee.Id))
            {
                testFuture.Content = "view the test you passed";
                viewTest_uc.Test = bl.GetTestsByTrainee(trainee).Last();
                addTest_uc.Visibility = Visibility.Hidden;
                viewTests_uc.Visibility = Visibility.Visible;
            }
            else
            {
                if (bl.GetTestsByTrainee(trainee).Count == 0 || bl.isTestFinished(bl.GetTestsByTrainee(trainee).Last()))
                {
                    testFuture.Header = "Add test";
                    addTest_uc.Visibility = Visibility.Visible;
                    viewTest_uc.Visibility = Visibility.Hidden;
                    addTest_uc.setTrainee(trainee);
                }
                else
                {
                    testFuture.Header = "View your test";
                    addTest_uc.Visibility = Visibility.Hidden;
                    viewTest_uc.Visibility = Visibility.Visible;
                    viewTest_uc.Test = bl.GetTestsByTrainee(trainee).Last();
                }

            }
        }

        private void updateTrainee_click(object sender, RoutedEventArgs e)
        {
            trainee = bl.GetTraineeById(trainee.Id);
            details.DataContext = trainee;
            updateTrainee_uc.Trainee = trainee;
            MessageBox.Show("trainee updated successfully");
        }

        private void viewTest(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void viewTestYouPassed(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void addTestToTrainee(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
