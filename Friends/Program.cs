using System;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using VkNet.Enums;
using System.Data.SqlClient;
using System.Threading;

namespace Friendss
{

    class MyFriend
    {
        private string firstName;
        private string lastName;
        private string birthDate;
        private Sex sex;

        public MyFriend(string firstName, string lastName, string birthDate, Sex sex)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.sex = sex;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {

            int appId = 5271341; // указываем id приложения
            Settings settings = Settings.All; // уровень доступа к данным
            var api = new VkApi();
            int userId;

            string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\Visual Studio 2015\Projects\Friends\Friends\Database1.mdf;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connect);
            connection.Open();
            
            while (true)
            {
                Console.WriteLine("Enter email or phone number: ");
                string email = Console.ReadLine(); // email для авторизации
                Console.WriteLine("Enter password: ");
                string password = "";
                while (true)
                {

                    var key = Console.ReadKey(true);//не отображаем клавишу - true

                    if (key.Key == ConsoleKey.Enter) break; //enter - выходим из цикла

                    Console.Write("*");//рисуем звезду вместо нее
                    password += key.KeyChar; //копим в пароль символы

                }

                try
                {
                    api.Authorize(appId, email, password, settings);

                    SqlCommand insertUserId = connection.CreateCommand();
                    insertUserId.CommandText = "Insert into Users Values('" + api.UserId + "')";
                    try
                    {
                        insertUserId.ExecuteNonQuery();
                    }
                    catch
                    {

                    }
                    finally
                    {
                        SqlCommand searchUserId = connection.CreateCommand();
                        searchUserId.CommandText = "Select Id from Users Where UserId = " + api.UserId;
                        userId = (int)searchUserId.ExecuteScalar();
                    }

                    break;// авторизуемся
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Try enter again!");
                }             
            }

            Console.WriteLine();
            Console.WriteLine("Update app?(Y/N)");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if(cki.Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("Updating...");
                ProfileFields fields = ProfileFields.BirthDate | ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Sex;
                var myFriends = api.Friends.Get(api.UserId.GetValueOrDefault(), fields);
              
                SqlCommand insertField = connection.CreateCommand();

                foreach (var friend in myFriends)
                {
                    insertField.CommandText = "Insert into Friends Values('" + friend.Id + "',N'" + friend.FirstName + "',N'" + friend.LastName + "'";
                    bool date = String.IsNullOrEmpty(friend.BirthDate);
                    if (!date)
                        insertField.CommandText += ",'" + friend.BirthDate.Split('.')[0] + "','" + friend.BirthDate.Split('.')[1] + "','" + userId + "')";
                    else
                        insertField.CommandText += ",'0','0','" + userId +"')";
                    try
                    {
                        insertField.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        //if(ex.Number == 2627)
                        //{
                        //    SqlCommand updateField = connection.CreateCommand();
                        //    updateField.CommandText = "Update Friends SET BDay = " + friend.BirthDate.Split('.')[0] + ", BMonth = " + friend.BirthDate.Split('.')[1] + " WHERE id = " + friend.Id;
                        //    updateField.ExecuteNonQuery();
                        //}
                    }
                }

                Console.WriteLine("Updating finished.");
            }


            SqlCommand searchBirthdayBoys = new SqlCommand("Select * From Friends Where BDay = " + DateTime.Now.Day + " AND BMonth = " + DateTime.Now.Month, connection);
            SqlDataReader result = searchBirthdayBoys.ExecuteReader();

            if(result.Read())
            {
                Console.WriteLine("Когда поздравлять будем?");
                string time = Console.ReadLine();
                DateTime now = DateTime.Now;
                int minutes = int.Parse(time.Split(' ')[1]) - now.Minute;
                int hours = int.Parse(time.Split(' ')[0]) - now.Hour;

                Thread.Sleep(minutes * 60000 + hours * 3600000);

                do
                {
                    MessageSendParams para = new MessageSendParams();
                    para.UserId = result.GetFieldValue<int>(0);
                    para.Message = "Здарова, " + result.GetString(1) + ". С др кароч.";
                    api.Messages.Send(para);
                } while (result.Read());
                Console.WriteLine("Сообщения отправлены.");
            }
            else
            {
                Console.WriteLine("Некого поздравлять.");
                connection.Close();
            }

            connection.Close();
            Console.WriteLine("Type any key to exit.");
            Console.ReadKey(true);
        }
    }
}
