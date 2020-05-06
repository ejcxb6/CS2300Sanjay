using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Windows;

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for AddCourseWindow.xaml
    /// </summary>
    public partial class AddCourseWindow : Window
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

        public AddCourseWindow()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("select course.courseID, course.Department, course.creditHours," +
                " course.Name, section.SectionNumber, section.ClassSize, section.Date, section.Time FROM" +
                " course,has,section where course.courseID = has.CourseID AND has.SectionNumber= section.SectionNumber" +
                " AND course.courseID not in (select course.courseID FROM student, takes, section, has, course" +
                " where student.idstudent = @studentID AND " +
                " student.idstudent = takes.ID AND takes.SectionNumber = section.SectionNumber AND" +
                " section.SectionNumber = has.SectionNumber AND course.courseID = has.CourseID)", connection);
            cmd.Parameters.AddWithValue("@studentID", user.id);
            dt.Load(cmd.ExecuteReader());
            connection.Close(); 
            dtGrid.DataContext = dt;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Takes(SectionNumber, ID, grade) Values(@SectionNumber, @studentID,'NA')", connection);
            MySqlCommand cmd2 = new MySqlCommand("UPDATE section SET section.ClassSize = section.ClassSize + 1" +
            " WHERE section.SectionNumber = @SectionNumber2", connection);
            cmd.Parameters.AddWithValue("@SectionNumber", dt.Rows[CourseIndex][4].ToString());
            cmd.Parameters.AddWithValue("@studentID", user.id);
            cmd2.Parameters.AddWithValue("@SectionNumber2", dt.Rows[CourseIndex][4].ToString());
            cmd.ExecuteReader();
            connection.Close();
            connection.Open();
            cmd2.ExecuteReader();
            MessageBox.Show(dt.Rows[CourseIndex][0].ToString() + " has been added to your schedule!");
            connection.Close();
        }
    }
}
