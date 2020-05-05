using System.Windows;
using System.Data;
using System;
using System.Data.SqlClient;
using MySql.Data;
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
            //MySqlCommand cmd = new MySqlCommand("select from users where idUser=12510114", connection);
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(1) FROM user WHERE nameUser = @nameUser AND idUser = @idUser", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@nameUser", USER_TEXT.Text);
            cmd.Parameters.AddWithValue("@idUser", PWD_TEXT.Text);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                TeacherScreen teacherWindow = new TeacherScreen();
                teacherWindow.Show();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
            connection.Close();
            //SqlConnection connection = new SqlConnection("SERVER=localhost;DATABASE=Phase3; UID=root;PASSWORD=h1NN1hAA*26;");
            ////connection.Open();
            //string nameUser = USER_TEXT.Text;
            //string idUser = PWD_TEXT.Text;
            //SqlCommand cmd = new SqlCommand("SELECT nameUser, idUser FROM User WHERE nameUser = '" + USER_TEXT.Text + "'and idUser = '" + PWD_TEXT.Text + "'", connection);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    TeacherScreen teacherWindow = new TeacherScreen();
            //    teacherWindow.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Login please check username and password");
            //}
            ////connection.Close();
        }

    }
}
