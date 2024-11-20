using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace HotelFoodAndRoomServiceSystem
{
    public partial class GuestLoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OpenDB();
        }

        //DATABSE CONNECTION

        public MySqlConnection dbconn = new MySqlConnection("server=localhost;username=root;password=;database=hotelmanagement");

        public void OpenDB()
        {
            try
            {
                dbconn.Open();
            }
            catch 
            {
                
            }
        }

        public void CloseDB()
        {
            try
            {
                dbconn.Close();
            }
            catch
            {

            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {   
            // GET THE VALUES OF EMAIL AND PASSWORD 
            string email = emailTxtBox.Text.Trim();
            string password = passwordTxtBox.Text.Trim();

            // VERIFY EMAIL AND PASSWORD WHEN LOGIN BUTTON CLICKED!
            LoginStatus status = loginVerification(email, password);
            switch (status)
            {
                case LoginStatus.Success:
                    retrieveUserDetails(email);
                    emailErrorLbl.Text = "";
                    passwordErrorLbl.Text = "";
                    userNotFoundLbl.Text = "";
                    emailTxtBox.Text = "";
                    passwordTxtBox.Text = "";
                    CloseDB();
                    break;
                case LoginStatus.InvalidPassword:
                    passwordTxtBox.Text = "";
                    emailErrorLbl.Text = "*Account existing!";
                    userNotFoundLbl.Text = "";
                    passwordErrorLbl.Text = "*Invalid password! please try again.";
                    break;
                case LoginStatus.AccountNotFound:
                    emailTxtBox.Text = "";
                    passwordTxtBox.Text = "";
                    userNotFoundLbl.Text = "*Account not found!";
                    emailErrorLbl.Text = "*Invalid email! please try again.";
                    break;
                case LoginStatus.Error:
                    Console.WriteLine("Error in Database");
                    break;
            }
            // CLEAR email and password textbox
            emailTxtBox.Text = "";
            passwordTxtBox.Text = "";
        }


        //LOGIN VERIFICATION

        public enum LoginStatus
        {
            Success,
            InvalidPassword,
            AccountNotFound,
            Error
        }
        private LoginStatus loginVerification(string email, string password)
        {
            try
            {

                //FOR EMAIL VERIFICATION
                String verifyEmail = "SELECT COUNT(*) FROM guestroominformation WHERE email=@Email";
                MySqlCommand emailcmd = new MySqlCommand(verifyEmail, dbconn);
                emailcmd.Parameters.AddWithValue("@Email", email);


                object emailResult = emailcmd.ExecuteScalar();
                int emailCount = emailResult != null ? Convert.ToInt32(emailResult) : 0;


                if (emailCount == 0) { return LoginStatus.AccountNotFound; }

                //FOR PASSWORD VERIFICATION
                String verifyPassword = "SELECT password FROM guestroominformation WHERE email=@Email";
                MySqlCommand passwordcmd = new MySqlCommand(verifyPassword, dbconn);
                passwordcmd.Parameters.AddWithValue("@Email", email);

                object passwordresult = passwordcmd.ExecuteScalar();

                if (passwordresult == null)
                {
                    Console.WriteLine("No result found for the provided email.");
                    return LoginStatus.InvalidPassword; // Email does not exist
                }

                // Get the stored password
                string storedPassword = passwordresult.ToString();

                // Check if the provided password matches the stored password
                if (password == storedPassword)
                {
                    return LoginStatus.Success; // Login successful
                }
                else
                {
                    Console.WriteLine("Incorrect password entered.");
                    return LoginStatus.InvalidPassword; // Incorrect password
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return LoginStatus.Error;
            }
        }

        private void retrieveUserDetails(String email)
        {
            try
            {
                String retrieveUserDetails = "SELECT * FROM guestroominformation WHERE email = @1";
                MySqlCommand cmd = new MySqlCommand(retrieveUserDetails, dbconn);
                cmd.Parameters.AddWithValue("@1", email);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Session["Email"] = reader["email"];
                    Session["Username"] = reader["username"];
                    Session["RoomNumber"] = reader["room_number"];
                    Session["CheckInDate"] = reader["chk_in_date"];
                    Session["CheckOutDate"] = reader["chk_out_date"];
                    Session["RoomType"] = reader["room_type"];
                    Session["Occupancy"] = reader["occupancy"];
                    Session["Amenities"] = reader["amenities"];

                    Response.Redirect("GuestDashboard.aspx");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void adminLoginBtn_Click(object sender, EventArgs e)
        {
            proceedToAdminLogin();
        }

        private void proceedToAdminLogin()
        {
            CloseDB();
            Response.Redirect("AdminLogin.aspx");
        }
            
    }
}





