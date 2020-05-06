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
    /// Interaction logic for TeacherScreen.xaml
    /// </summary>
    public partial class TeacherScreen : Window
    {
        public TeacherScreen()
        {
            InitializeComponent();

        }

        private void TeacherSchedule_Click(object sender, RoutedEventArgs e)
        {
            TeacherScheduleScreen TscheduleScreen = new TeacherScheduleScreen();
            TscheduleScreen.Show();
        }

        private void TeacherGrade_Click(object sender, RoutedEventArgs e)
        {
            TeacherGrade GradeScreen = new TeacherGrade();
            GradeScreen.Show();
        }
    }
}
