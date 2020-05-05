using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for GradesScreen.xaml
    /// </summary>
    public partial class GradesScreen : Window
    {
        public GradesScreen()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select course.Name, takes.SectionNumber, takes.Grade" +
               " from course, takes, student, section, has where  student.idstudent=@studentID AND takes.ID = student.idstudent AND " +
               " takes.SectionNumber=section.SectionNumber AND takes.SectionNumber = has.SectionNumber AND has.CourseID = course.courseID", connection);
            cmd.Parameters.AddWithValue("@studentID", user.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            grades.DataContext = dt;
        }

    }
}
