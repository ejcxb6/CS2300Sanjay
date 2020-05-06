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
    /// Interaction logic for TeacherGrade.xaml
    /// </summary>
    public partial class TeacherGrade : Window
    {
        public TeacherGrade()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select student.idstudent, course.Name, teaches.SectionNumber, takes.grade" +
             " from student, course, has, takes, teaches, section, teacher" +
             " where teacher.idTeacher = '@teacherID' AND teacher.idTeacher = teaches.ID AND student.idstudent = takes.ID" +
             " AND takes.SectionNumber = teaches.SectionNumber AND teaches.SectionNumber = has.SectionNumber" +
             " AND has.CourseID = course.courseID", connection);

            cmd.Parameters.AddWithValue("@teacherID", user.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            StudentGrades.DataContext = dt;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
