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

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for StudentScreen.xaml
    /// </summary>
    public partial class StudentScreen : Window
    {
        public StudentScreen()
        {
            InitializeComponent();
        }

        private void Add_Course_Click(object sender, RoutedEventArgs e)
        {
            AddCourseWindow addWindow = new AddCourseWindow();
            addWindow.Show();
        }

        private void Drop_Course_Click(object sender, RoutedEventArgs e)
        {
            AddCourseWindow addWindow = new AddCourseWindow();
            addWindow.Show();
        }

        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            GradesScreen gradesScreen = new GradesScreen();
            gradesScreen.Show();
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            ScheduleScreen scheduleScreen = new ScheduleScreen();
            scheduleScreen.Show();
        }
    }
}
