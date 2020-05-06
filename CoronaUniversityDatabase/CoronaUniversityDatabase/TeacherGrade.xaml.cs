using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

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
             " where teacher.idTeacher = @teacherID AND teacher.idTeacher = teaches.ID AND student.idstudent = takes.ID" +
             " AND takes.SectionNumber = teaches.SectionNumber AND teaches.SectionNumber = has.SectionNumber" +
             " AND has.CourseID = course.courseID", connection);

            cmd.Parameters.AddWithValue("@teacherID", user.id);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            StudentGrades.DataContext = dt;
           
        }
        public DataTable dt = new DataTable();
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE TAKES SET GRADE = @newgrade WHERE TAKES.ID = @idstudent", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idstudent", StudentID.Text);
            cmd.Parameters.AddWithValue("@newgrade", newgrade.Text);
            cmd.ExecuteReader();
            MessageBox.Show( "Grade has been changed!");
            connection.Close();
        }
    }
}
