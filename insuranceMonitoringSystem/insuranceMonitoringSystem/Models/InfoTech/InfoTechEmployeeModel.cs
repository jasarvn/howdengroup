using System.Data;
using System.Text;
using insuranceMonitoringSystem.Helpers;

namespace insuranceMonitoringSystem.Models.InfoTech
{
    public class InfoTechEmployeeModel
    {

        public string empFname;
        public string empMname;
        public string empLname;
        public int empId;
        public string tblname { set; get; } = "tblEmployee";


        public DataTable getempList()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT * FROM {0} WHERE dlflg = 1 ORDER BY empId ASC", tblname);
            DataTable rdata = Dbhelper.GetDbData(sql.ToString());
            return rdata;
        }

        public DataTable getEmployeeInfo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Select * from {0} where empId = {1}", tblname, empId);
            DataTable rdata = Dbhelper.GetDbData(sql.ToString());
            return rdata;
        }

        public void insertEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("insert into {0} (empFname,empMname,empLname) values", tblname);
            sql.AppendFormat("('{0}','{1}','{2}')", empFname, empMname, empLname);
            Dbhelper.processData(sql.ToString());

        }

        public void updateEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update {0} set " +
                "empFname = '{1}'," +
                "empMname = '{2}'," +
                "empLname ='{3}'" +
                "where " +
                "empId = {4}", tblname, empFname, empMname, empLname, empId);
            Dbhelper.processData(sql.ToString());

        }

        public void deleteEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update {0} set " +
                "dlflg = '0' " +
                "where " +
                "empId = {1}", tblname, empId);
            Dbhelper.processData(sql.ToString());

        }

    }
}
