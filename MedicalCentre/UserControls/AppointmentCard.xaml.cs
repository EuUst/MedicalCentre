﻿using MaterialDesignThemes.Wpf;
using MedicalCentre.Models;
using MedicalCentre.UserControls.ViewModels;
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

namespace MedicalCentre.UserControls
{
    public partial class AppointmentCard : UserControl
    {
        public AppointmentCard(Appointment appointment)
        {
            InitializeComponent();
            DataContext = new AppointmentCardViewModel(this, appointment);
        }
    }
}