using CircularManagementSystem.Entity;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace CircularManagementSystem.DAL
{
    public class CircularRepository
    {
        public void AddCircular(Circular circular)
        {
            using (ContextClass contextClass = new ContextClass())
            {
                contextClass.Circulars.Add(circular);
                contextClass.SaveChanges();
            }
        }
        public int GetCircularId(string filename)
        {
            using(ContextClass contextClass=new ContextClass())
            {
                Circular circular = contextClass.Circulars.Where(x => x.FilePath == filename).SingleOrDefault();
                return circular.CircularId;
            }
        }
        public bool AddCircularDepartments(List<int> SelectedChoices,int CircularId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            bool value=false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                for (int i = 0; i < SelectedChoices.Count; i++)
                {
                    SqlCommand command = new SqlCommand("SP_ADDCIRCULARDEPARTMENTS", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DepartmentId", SelectedChoices[i]);
                    command.Parameters.AddWithValue("@CircularId", CircularId);
                    connection.Open();
                    byte result = (byte)command.ExecuteNonQuery();
                    connection.Close();
                    if(result>=1)
                    {
                        value = true;
                    }
                }
                return value;
            }
        }
        public List<Circular> GetCirculars()
        {
            using (ContextClass contextClass = new ContextClass())
                return contextClass.Circulars.ToList();
        }
        public Circular GetCircular(int circularId)
        {
            using (ContextClass contextClass = new ContextClass())
                return contextClass.Circulars.Where(x => x.CircularId == circularId).SingleOrDefault();
        }
    }
}
