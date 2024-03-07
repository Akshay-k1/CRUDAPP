using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace CRUDAPP.Models
{
    public class EmployyeDB
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-P19SBMN\SQLEXPRESS;database=CRUDAPP;integrated security=true");

        public string DBinsert(Employee objcls)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SP_INSERT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empname", objcls.ename);
                cmd.Parameters.AddWithValue("@empage", objcls.eage);
                cmd.Parameters.AddWithValue("@empadd", objcls.eadd);
                cmd.Parameters.AddWithValue("@empph", objcls.ephone);
                cmd.Parameters.AddWithValue("@una", objcls.eusername);
                cmd.Parameters.AddWithValue("@pas", objcls.epassword);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("inserted successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }

        }
        public string DBlogin(Employee objcls, out int employeeId)
        {
            employeeId = 0;
            try
            {
                string msg = "";
                SqlCommand cmd = new SqlCommand("sp_login", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@una", objcls.eusername);
                cmd.Parameters.AddWithValue("@pas", objcls.epassword);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int result = Convert.ToInt32(reader["Result"]);
                    if (result == 1)
                    {
                        employeeId = Convert.ToInt32(reader["EmployeeID"]); // Retrieve employee ID
                        msg = "success";
                    }
                    else
                    {
                        msg = "invalid login";
                    }
                }
                reader.Close();
                con.Close();

                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message.ToString();
            }
        }
    
        public List<Employee> GetEmployeeList(Employee obj)
        {
            var list=new List<Employee>();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var o = new Employee
                    {
                        eid = Convert.ToInt32(reader["EMP_ID"]),
                        ename = reader["EMP_NAME"].ToString(),
                        eage = Convert.ToInt32(reader["EMP_AGE"]),
                        eadd = reader["EMP_ADDRESS"].ToString(),
                        eusername = reader["UsernName"].ToString(),
                        epassword = reader["Password"].ToString(),
                    };
                    list.Add(o);
                    
                }
				con.Close();
				return list;
			}
            catch(Exception ex) 
            {
                if(con.State == ConnectionState.Open) 
                {
                    con.Close();
                }
            }
            return list;
        }
		public Employee Profileview(int id)
        {
            var getdata = new Employee();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_display", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    getdata = new Employee
                    {
                        eid = Convert.ToInt32(sdr["EMP_ID"]),
                        ename = sdr["EMP_NAME"].ToString(),
                        eage = Convert.ToInt32(sdr["EMP_AGE"]),
                        eadd = sdr["EMP_ADDRESS"].ToString(),
                        ephone = sdr["EMP_PHONE"].ToString(),
                        eusername = sdr["UsernName"].ToString(),
                        epassword = sdr["Password"].ToString(),
                    };
                }
                    con.Close();
                    return getdata;
                
            }
            catch(Exception ex)
            {
                if(con.State== ConnectionState.Open)
                {
                        con.Close();
                }
                throw;
            }
        }
        public string DBUpdate(Employee emp)
        {
            string retVal = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Upadate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empname", emp.ename);
                cmd.Parameters.AddWithValue("@empage", emp.eage);
                cmd.Parameters.AddWithValue("@empadd", emp.eadd);
                cmd.Parameters.AddWithValue("@empph", emp.ephone);
                cmd.Parameters.AddWithValue("@una", emp.eusername);
                cmd.Parameters.AddWithValue("@pas", emp.epassword);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                retVal = "Ok .Updated";
            }
            catch(Exception ex) 
            {
                if(con.State== ConnectionState.Open)
                {
                    con.Close() ;
                }
            }
            return (retVal);
        }
		public string DBDelete(Employee emp)
		{
			string retVal = "";
			try
			{
				SqlCommand cmd = new SqlCommand("SP_Delete", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@una", emp.eusername);
				cmd.Parameters.AddWithValue("@pas", emp.epassword);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
				retVal = "Ok ..Deleted";
			}
			catch (Exception ex)
			{
				if (con.State == ConnectionState.Open)
				{
					con.Close();
				}
			}
			return (retVal);
		}
	}
	
}

