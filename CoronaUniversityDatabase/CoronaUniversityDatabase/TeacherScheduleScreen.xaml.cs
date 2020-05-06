using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for TeacherScheduleScreen.xaml
    /// </summary>
    public partial class TeacherScheduleScreen : Window
    {
        public TeacherScheduleScreen()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select course.courseID, course.Department, section.Date, section.Time, course.Name" +
            " FROM teacher,teaches,section,has,course where teacher.idTeacher =@teacherID AND" +
            " teacher.idTeacher = teaches.ID AND teaches.SectionNumber = section.SectionNumber AND" +
            " section.SectionNumber = has.SectionNumber AND course.courseID = has.CourseID", connection);



            cmd.Parameters.AddWithValue("@teacherID", user.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            schedule.DataContext = dt;
        }
    }
}
