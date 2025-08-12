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

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for TaskAddWindow.xaml
    /// </summary>
    public partial class TaskAddWindow : Window
    {
        Task taskToAdd;

        string Header {  get; set; }
        string Descripton { get; set; }
        int Priority {  get; set; }

        public TaskAddWindow(Task taskparam)
        {
            InitializeComponent();

            taskToAdd = taskparam;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (Header != null)
            {
                taskToAdd.TaskHeader = Header;
                taskToAdd.Priority = Priority;
                taskToAdd.Description = Descripton;

                this.Close();
            } else 
            {
                MessageBox.Show("Please add a header to your task");
            }
        }

        private void HeaderInput_LostFocus(object sender, RoutedEventArgs e)
        {
            Header = HeaderInput.Text;
        }

        private void PriorityInput_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void PriorityInput_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
               bool valid = validPriorityInputCheck(PriorityInput.Text);

                if (valid) 
                {
                    Priority = Int32.Parse(PriorityInput.Text);
                }
                else { }
            } catch 
            {
                MessageBox.Show("Sorry an error occured");
            }
        }

        public bool validPriorityInputCheck(string input) 
        {
            try 
            {
                int test = Int32.Parse(input);

                if(test <= 0) 
                {
                    throw new Exception("Invalid Integer allowed");
                }

                return true;
            } catch 
            {
                MessageBox.Show("Sorry you need to input a valid integer in the priority box 1 and up please!");

                PriorityInput.Text = string.Empty;
                return false;
            }
        }

        private void DescriptionInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DescriptionInput_LostFocus(object sender, RoutedEventArgs e)
        {
            Descripton = DescriptionInput.Text;
        }
    }
}
