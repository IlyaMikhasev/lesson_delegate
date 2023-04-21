using DbConnectionExample;
using System;
using System.Data.SqlClient;
using System.IO;//для работы с чтением и записью фалов
using System.Text;
/*namespace lesson_delegate
{
    delegate void myDelegate(string _text);

    *//* internal class Program
     {
         static void Print(string _text) {
             Console.WriteLine(_text);
         }
         static void SaveText(string _text ) {
             string _nameFile = "output.txt";
             StreamWriter writer = new StreamWriter(_nameFile,true);
             writer.WriteLine(_text);
             writer.Close();
             *//*using (
                 StreamWriter writer1 = new StreamWriter(_nameFile))
             {
                 writer1.WriteLine(_text,true);
             } *//*
}
static void Main(string[] args)
{
    //delegate
    myDelegate output;
    output = Print;
    output += SaveText;
    output($"Hello ! {DateTime.Now}");//вызов делегата
    output.Invoke($"Hello ! {DateTime.Now.ToString("mm.ss")}");
    output.Invoke(null);
}
    }
}*/
namespace DbConnectionExample
{
    public class myConnectToMSSQLDB
    {
        public myConnectToMSSQLDB()
        {
            string conStr = @"Data Source=(localdb)\MSSQLLocalDB;" + /* Имя сервера */
                        "Initial Catalog=master;" + /* БД подключения*/
                        "Integrated Security=True;" + /* Использование уч.записи Windows */
                        "Connect Timeout=30;" + /* Таймаут в секундах*/
                        "Encrypt=False;" + /* Поддержка шифрования, работает в паре со сл.параметром */
                        "TrustServerCertificate=False;" + /* Только при подключении к экземпляру SQL Server с допустимым сертификатом. Если ключевому слову TrustServerCertificate присвоено значение true, то транспортный уровень будет использовать протокол SSL для шифрования канала и не пойдет по цепочке сертификатов для проверки доверия. */
                        "ApplicationIntent=ReadWrite;" + /* Режим подключения*/
                        "MultiSubnetFailover=False;"; /* true - поддержка уровня доступности: оптимизирует работу для пользователей одной подсети*/
            var myConn = new SqlConnection(conStr);
            try
            {
                myConn.Open();
                Console.WriteLine($"Установлено соединение с параметрами {conStr}");
            }
            catch
            {
                Console.WriteLine($"Не удалось установить соединение с параметрами {conStr}");
            }
            finally
            {

                myConn.Close();
                Console.WriteLine($"Закрыто соединение с параметрами {conStr}");

            }

        }

    }

}
internal class Program
{
    static void Main(string[] args)
    {
        var connect = new myConnectToMSSQLDB();
        string conStr = @"Data Source=ATLAS_NOTE;" + /* Имя сервера */
                    "Initial Catalog=master;" +  /* БД подключения*/
                    "User ID = sa;" + /* Имя пользователя БД */
                    "Password = 1234;" + /* Его пароль */
                    "Connect Timeout=30;" + /* Таймаут в секундах*/
                    "Encrypt=False;" + /* Поддержка шифрования, работает в паре со сл.параметром */
                    "TrustServerCertificate=False;" + /* Только при подключении к экземпляру SQL Server с допустимым сертификатом. Если ключевому слову TrustServerCertificate присвоено значение true, то транспортный уровень будет использовать протокол SSL для шифрования канала и не пойдет по цепочке сертификатов для проверки доверия. */
                    "ApplicationIntent=ReadWrite;" + /* Режим подключения*/
                    "MultiSubnetFailover=False;"; /* true - поддержка уровня доступности: оптимизирует работу для пользователей одной подсети*/
        Console.ReadKey();
    }
}
