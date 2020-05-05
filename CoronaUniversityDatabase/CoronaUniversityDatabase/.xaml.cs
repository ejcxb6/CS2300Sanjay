using System.Windows;
using System.Data;
using System;
using MySql.Data.MySqlClient;
namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(1) FROM teacher,user WHERE idTeacher = @idTeacher AND idTeacher = idUser AND nameUser=@nameUser", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idTeacher", PWD_TEXT.Text);
            cmd.Parameters.AddWithValue("@nameUser", USER_TEXT.Text);
            user.id = PWD_TEXT.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                TeacherScreen teacherWindow = new TeacherScreen();
                teacherWindow.Show();
                this.Close();
            }
            else
            {
                MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(1) FROM student,user WHERE idstudent = @idstudent AND idUser=idstudent AND nameUser = @nameUser", connection);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@idstudent", PWD_TEXT.Text);
                cmd2.Parameters.AddWithValue("@nameUser", USER_TEXT.Text);
                int count2 = Convert.ToInt32(cmd2.ExecuteScalar());
                if (count2 == 1)
                {

                    StudentScreen studentWindow = new StudentScreen();
                    studentWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
            connection.Close();
        }

    }
}
