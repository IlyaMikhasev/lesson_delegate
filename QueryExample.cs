using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DbConnectionExample;
using static System.Net.Mime.MediaTypeNames;

namespace DbConnectionExample
{
    public class myConnectToMSSQLDB
    {
        public SqlConnection connection;
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
                //myConn.Close();
                connection = myConn;
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
        string _cmd = @"use test;
        insert into[output](myText) values (N'TEST');";
        /* Конструетор по умолчанию */
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = connect.connection;
        sqlCommand.CommandText = _cmd;

        /* Использование нестатического метода SqlConnection */
        //var sqlCommand = myConn.CreateCommand();
        //sqlCommand.CommandText = _cmd;

        /* Использование перегрузки конструктора с 2-мя параметрами */
        //SqlCommand sqlCommand = new SqlCommand(_cmd, myConn);

        var dataReader = sqlCommand.ExecuteReader();
        Console.WriteLine(_cmd);
        while (dataReader.Read())
        {
            int row = dataReader.FieldCount; // Вспомогательная переменная, количество возвращённых столбцов
            for (int i = 0; i < row; i++)
            {
                Console.Write("  " + dataReader[i].ToString());
            }
            Console.WriteLine();
        }
        Console.ReadKey();
        }
    }

