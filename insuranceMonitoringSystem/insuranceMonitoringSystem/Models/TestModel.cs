using System;
using System.Data;
using System.Data.Entity;
using System.Text;
using insuranceMonitoringSystem.Helpers;

namespace insuranceMonitoringSystem.Models
{
    public class TestModel
    {
        public string empFname;
        public string empMname;
        public string empLname;
        public int empId;
        
        public DataTable testdata()
        {
            DataTable rdata = Dbhelper.GetDbData("select * from tblEmployee order by empId asc");
            return rdata;
        }

        public DataTable getEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Select * from tblEmployee where empId = {0}", empId);
            DataTable rdata = Dbhelper.GetDbData(sql.ToString());
            return rdata;
        }

        public void testInsert()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into tblEmployee (empFname,empMname,empLname) values");
            sql.AppendFormat("('{0}','{1}','{2}')", empFname, empMname, empLname);
            Dbhelper.processData(sql.ToString());
        }

    }
   
}
