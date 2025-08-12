using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoList
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

        bool userDoneTyping = false;

        private void TaskInput_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if(TaskInput.Text != "" ||  TaskInput.Text != string.Empty || TaskInput.Text != null) 
            {
                var taskBeingAdded = new Task(TaskInput.Text);

                TasksList.Items.Add(taskBeingAdded);
            }
        }

        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}