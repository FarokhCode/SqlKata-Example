using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var connection = new SqlConnection(@"Data Source=.;initial Catalog=test01;User Id=sa;Password=ali@123");
        var compiler = new SqlServerCompiler();

        var db = new QueryFactory(connection, compiler);

        UserList(db);

        SearchUser(db);

        Console.ReadLine();
    }
    private static void SearchUser(QueryFactory db)
    {
        IEnumerable<dynamic> userSearch = db.Query("Users").Where("UserId", 2).WhereTrue("State").Get();

        Console.WriteLine("\r\nUser Search ------\r\n ");
        foreach (var user in userSearch)
        {
            Console.WriteLine($"Id: {user.UserId}, SurName: {user.FirstName}, First Name: {user.LastName}");
        }
    }

    private static void UserList(QueryFactory db)
    {
        IEnumerable<dynamic> users = db.Query("Users").Get();

        Console.WriteLine("User List ------\r\n");
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.UserId}, SurName: {user.FirstName}, First Name: {user.LastName}");
        }
    }
}