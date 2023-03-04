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
using MedicalCentre.Models;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Services;

namespace MedicalCentre.Forms
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        public EditEmployee()
        {
            InitializeComponent();
        }

        public async void Edit(object sendet, RoutedEventArgs e)
        {
            try
            {
                uint accountId = uint.Parse(AccountId.Text.ToString());
                string password = Password.Password;

                ContextRepository<Account> accDb = new ContextRepository<Account>();
                ContextRepository<Employee> empDb = new ContextRepository<Employee>();
                Account currentAccount = await accDb.GetItemByIdAsync(accountId);
                Employee currentEmployee = empDb.GetItemById(currentAccount.EmployeeAccountId);

                currentAccount.Password = password;

                currentEmployee.Name = Name.Text;
                currentEmployee.Surname = Surname.Text;
                currentEmployee.Patronymic = Patronymic.Text;
                currentEmployee.Salary = double.Parse(Salary.Text);
                currentEmployee.RoleId = uint.Parse(RoleId.Text.ToString());
                currentEmployee.Specialization = Specialization.Text;

                await empDb.UpdateItemAsync(currentEmployee);
                await accDb.UpdateItemAsync(currentAccount);

                LoggerService.CreateLog($"Account {accountId} with Employee {currentEmployee.Id} was edit.", true);
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Что-то пошло не так. Ошибка в данных или сбой на стороне сервера, попробуйте позже и обратитесь к сис.админу.");
                LoggerService.CreateLog($"{ex.Message}", false);
            }
            Close();
        }
    }
}
