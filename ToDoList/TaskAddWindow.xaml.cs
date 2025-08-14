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
using static System.Net.Mime.MediaTypeNames;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for TaskAddWindow.xaml
    /// </summary>
    public partial class TaskAddWindow : Window
    {
        Task taskToAdd;
        List<Task> tasks;

        string Header {  get; set; }
        string Descripton { get; set; }
        int Priority {  get; set; }

        public TaskAddWindow(Task taskparam, List<Task> taskList, bool editing)
        {
            InitializeComponent();

            taskToAdd = taskparam;

            if(editing == true) 
            {
                Header = taskparam.TaskHeader;
                Descripton = taskparam.Description;
                Priority = taskparam.Priority;

                HeaderInput.Text = taskparam.TaskHeader.ToString();
                DescriptionInput.Text = taskparam.Description;
                PriorityInput.Text = taskparam.Priority.ToString();

                AddTask.Visibility = Visibility.Hidden;
            } else 
            {
                EditTask.Visibility = Visibility.Hidden;
            }

                tasks = taskList;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (Header != null && Priority >= 1)
            {
                taskToAdd.TaskHeader = Header;
                taskToAdd.Priority = Priority;
                taskToAdd.Description = Descripton;

                this.Close();
            } else 
            {
                MessageBox.Show("Please add a proper header and/or priority to your task");
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
               bool validParse = validPriorityInputCheck(PriorityInput.Text);

                if (validParse) 
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

                foreach (Task task in tasks)
                {
                    if (test == task.Priority) 
                    {
                        MessageBox.Show("Sorry You already gave a task this priority number.");
                        PriorityInput.Text = "Please put in a valid num";
                        return false;
                    }
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

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            taskToAdd.Priority = Priority;
            taskToAdd.Description = Descripton;
            taskToAdd.TaskHeader = Header;

            this.Close();
        }
    }
}
