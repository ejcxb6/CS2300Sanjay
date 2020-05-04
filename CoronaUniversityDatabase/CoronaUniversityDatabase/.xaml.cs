using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace CoronaUniversityDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlCon = new SqlConnection();
        public MainWindow()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=Local instance MySql80; Initial Catalog=Phase3; Integrated Security=True;");
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=Local instance MySql80; Initial Catalog=Phase3; Integrated Security=True;");
            sqlCon.Open();
            string nameUser = USER_TEXT.Text;
            string idUser = PWD_TEXT.Text;
            SqlCommand cmd = new SqlCommand("SELECT nameUser, idUser FROM User WHERE nameUser = '" + USER_TEXT.Text + "'and idUser = '" + PWD_TEXT.Text + "'", sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                TeacherScreen teacherWindow = new TeacherScreen();
                teacherWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            sqlCon.Close();
        }

    }
}
