using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace API.Services.Impl
{
    public class Cars : ICars
    {

        private readonly IConfiguration _configuration;
        public Cars(IConfiguration configuration)
        {

            _configuration = configuration;


        }
        public List<API.Cars> GetCars()
        {

            DataTable Cars = GetDtCars();

            return (from DataRow dr in Cars.Rows
                    select new API.Cars()
                    {
                        Carno = Convert.ToInt32(dr["Carno"]),
                        CarName = dr["CarName"].ToString(),
                        OwnerName = dr["OwnerName"].ToString(),
                        Address = dr["Address"].ToString(),
                        Mobile = dr["Mobile"].ToString(),

                    }).ToList();
        }


        private DataTable GetDtCars()
        {
            string constr = this._configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            SqlConnection con = new SqlConnection(constr);
            string query = "SELECT * FROM [Loyaltysample].[dbo].[Cars]";
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);

            sqlDataAdapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
    }
}
