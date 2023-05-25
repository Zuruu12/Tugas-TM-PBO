using Npgsql;
using System.Data;
using System.Reflection.PortableExecutable;
using System.Xml;

namespace ConsoleApp2

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string idrumah = "1";
            /* string luas = "3 hektare";
             string jmlhkmr = "25 kamar";
             string pemilik = "RAYHAN";
             Console.WriteLine("INSERT DATA");
             Person.InsertRumah(idrumah, luas, jmlhkmr, pemilik);*/
            /* Console.WriteLine("UPDATE DATA");
             Person.UpdateRumah(idrumah, luas, jmlhkmr, pemilik);*/
            Console.WriteLine("DELETE DATA");
            Person.DeleteRumah(idrumah);
            Console.WriteLine("TAMPIL DATA");
            DataTable dt = Person.SelectRumah();
            Person.showdata(dt);


        }
    }
}
class Person
{
    private NpgsqlConnection connection;
    public Person() {
        connection = new NpgsqlConnection();
        string constr = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=forpbo;";
        connection.ConnectionString = constr;
    }
    static public DataTable SelectRumah()
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        string constr = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=forpbo;";
        connection.ConnectionString = constr;
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            string StrSql = "select * from rumahh";
            cmd.CommandText = StrSql;
            cmd.CommandType = CommandType.Text;
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            cmd.Dispose();
            connection.Close();
        }
        catch (Exception ex) { }
        finally
        {
            connection.Close();
        }
        return dt;
    }

    static public void showdata(DataTable dt)
    {

        Console.WriteLine("Data:");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Console.Write((i + 1).ToString() + ". ");
            Console.Write(dt.Rows[i]["idrumah"] + ", ");
            Console.Write(dt.Rows[i]["luas"] + ", ");
            Console.Write(dt.Rows[i]["jmlhkmr"] + ", ");
            Console.Write(dt.Rows[i]["pemilik"]);
            Console.WriteLine();
        }
    }
    
    static public void InsertRumah(string idrumah, string luas, string jmlhkmr, string pemilik)
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        string constr = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=forpbo;";
        connection.ConnectionString = constr;
        DataTable dt = new DataTable();
        string query = "insert into rumahh (idrumah,luas,jmlhkmr,pemilik) values ('{0}','{1}','{2}','{3}');";
        query = string.Format(query, idrumah, luas, jmlhkmr, pemilik);
        try
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
        catch (PostgresException ex)
        {
            Console.WriteLine(ex.MessageText);
            return;
        }
        return;
    }
    public static void UpdateRumah(string idrumah, string luas, string jmlhkmr, string pemilik)
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        string constr = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=forpbo;";
        connection.ConnectionString = constr;
        DataTable dt = new DataTable();
        string query = "UPDATE rumahh SET luas = @luas, jmlhkmr = @jmlhkmr, pemilik = @pemilik WHERE idrumah = @idrumah";
        try
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@luas", luas);
            cmd.Parameters.AddWithValue("@jmlhkmr", jmlhkmr);
            cmd.Parameters.AddWithValue("@pemilik", pemilik);
            cmd.Parameters.AddWithValue("@idrumah", idrumah);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
        catch (Exception ex)
        {
            return;
        }
        return;
    }

    public static void DeleteRumah(string idrumah)
    {
        NpgsqlConnection connection = new NpgsqlConnection();
        string constr = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=forpbo;";
        connection.ConnectionString = constr;
        DataTable dt = new DataTable();
        string query = "DELETE FROM rumahh WHERE idrumah = @idrumah";
        try
        {
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@idrumah", idrumah);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connection.Close();
        }
        catch (Exception ex)
        {
            return;
        }
        return;
    }


}
