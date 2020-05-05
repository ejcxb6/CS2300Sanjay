using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for AddCourseWindow.xaml
    /// </summary>
    public partial class AddCourseWindow : Window
    {
        public AddCourseWindow()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select distinct * FROM course where course.courseID" +
                " not in (select course.courseID FROM student, takes, section, has, course" +
                " where student.idstudent = 12510114 AND" +
                " student.idstudent = takes.ID AND takes.SectionNumber = section.SectionNumber AND" +
                " section.SectionNumber = has.SectionNumber AND course.courseID = has.CourseID)", connection);
            cmd.Parameters.AddWithValue("@studentID", user.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close(); 
            dtGrid.DataContext = dt;
        }
    }
}
