using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

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
