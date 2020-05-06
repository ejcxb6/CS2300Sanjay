using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for DropCourseScreen.xaml
    /// </summary>
    public partial class DropCourseScreen : Window
    {
        #region //INotifyPropertyChanged handler
        //INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        private int courseIndex;
        public int CourseIndex
        {
            get { return courseIndex; }
            set
            {
                if (int.Equals(value, courseIndex))
                    return;
                courseIndex = value;
                OnPropertyChanged("CourseIndex");
            }
        }
        public DataTable dt = new DataTable();
        public DropCourseScreen()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select course.courseID, course.Department, section.Date, section.Time, section.SectionNumber, course.Name" +
            " FROM student,takes,section,has,course where student.idstudent =@studentID AND" +
            " student.idstudent = takes.ID AND takes.SectionNumber = section.SectionNumber AND" +
            " section.SectionNumber = has.SectionNumber AND course.courseID = has.CourseID", connection);
            cmd.Parameters.AddWithValue("@studentID", user.id);
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            drop.DataContext = dt;

        }

        private void drop_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(" DELETE FROM Takes WHERE SectionNumber=@SectionNumber AND ID=@studentID", connection);
            MySqlCommand cmd2 = new MySqlCommand("UPDATE section SET section.ClassSize = section.ClassSize - 1" +
           " WHERE section.SectionNumber = @SectionNumber2", connection);
            cmd.Parameters.AddWithValue("@SectionNumber", dt.Rows[CourseIndex][4].ToString());
            cmd.Parameters.AddWithValue("@studentID", user.id);
            cmd2.Parameters.AddWithValue("@SectionNumber2", dt.Rows[CourseIndex][4].ToString());
            cmd.ExecuteReader();
            connection.Close();
            connection.Open();
            cmd2.ExecuteReader();
            MessageBox.Show(dt.Rows[CourseIndex][0].ToString() + " has been dropped from your schedule!");
            connection.Close();
        }
    }
}
