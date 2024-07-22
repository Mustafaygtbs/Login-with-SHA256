using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Login_with_SHA256
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=MUSTAFA\\SQLEXPRESS;Initial Catalog=ProjelerVT;Integrated Security=True;Encrypt=False");

        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private string SHA256Olusutr(string s)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        private void buttonKayit_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text.ToString().Length == 0 ||
               txtUsername.Text.ToString().Length == 0)
            {
                MessageBox.Show("Please fill in the blanks.");
                return;
            }
            string sorgu = "SELECT KullaniciAdi FROM KullaniciLogin WHERE KullaniciAdi=@P1";
            try
            {
                baglanti.Open();
                SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", txtUsername.Text);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                bool NewUser = false;
                if (reader.HasRows) // If the username already exists
                {
                    MessageBox.Show("This username already exists.");
                }
                else
                {
                    NewUser = true;
                }
                reader.Close();

                if (NewUser == true)
                {
                    // If the username does not exist, add the new user to the database 
                    string sorgu2 = "INSERT INTO KullaniciLogin (KullaniciAdi, Sifre) VALUES (@P1, @P2)";
                    SqlCommand sqlCommand2 = new SqlCommand(sorgu2, baglanti);
                    sqlCommand2.Parameters.AddWithValue("@P1", txtUsername.Text);
                    sqlCommand2.Parameters.AddWithValue("@P2", SHA256Olusutr(txtPassword.Text));

                    sqlCommand2.ExecuteNonQuery();
                    MessageBox.Show("Kayýt baþarýlý.");
                    txtUsername.Clear();
                    txtPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with data base connection, ERROR CODE:A3106\n" + ex.Message);
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text.ToString().Length == 0 ||
               txtUsername.Text.ToString().Length == 0)
            {
                MessageBox.Show("Please fill in the blanks.");
                return;
            }
            try
            {
                baglanti.Open();
                string sorgu = "SELECT * FROM KullaniciLogin WHERE KullaniciAdi=@P1 AND Sifre=@P2";
                SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", txtUsername.Text);
                sqlCommand.Parameters.AddWithValue("@P2", SHA256Olusutr(txtPassword.Text));

                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Login successful.");
                }
                else
                {
                    MessageBox.Show("Login failed.");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem with data base connection, ERROR CODE:A3107\n" + ex.Message);
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
            txtPassword.Clear();
            txtUsername.Clear();
        }
    }
}
