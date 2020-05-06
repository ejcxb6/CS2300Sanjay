using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for ScheduleScreen.xaml
    /// </summary>
    public partial class ScheduleScreen : Window
    {
        public ScheduleScreen()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select course.courseID, course.Department, section.Date, section.Time, course.Name" +
            " FROM student,takes,section,has,course where student.idstudent =@studentID AND" +
            " student.idstudent = takes.ID AND takes.SectionNumber = section.SectionNumber AND" +
            " section.SectionNumber = has.SectionNumber AND course.courseID = has.CourseID", connection);



            cmd.Parameters.AddWithValue("@studentID", user.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            schedule.DataContext = dt;
        }
    }
}
