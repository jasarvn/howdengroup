using System;
using System.Data;
using System.Data.Entity;
using System.Text;
using insuranceMonitoringSystem.Helpers;

namespace insuranceMonitoringSystem.Models.InfoTechModel
{
    public class InfoTechModel
    {
        public string empFname;
        public string empMname;
        public string empLname;
        public int empId;


        public DataTable getempList()
        {
            DataTable rdata = Dbhelper.GetDbData("select * from tblEmployee where dlflg ='1' order by empId asc");
            return rdata;
        }

        public DataTable getEmployeeInfo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Select * from tblEmployee where empId = {0}", empId);
            DataTable rdata = Dbhelper.GetDbData(sql.ToString());
            return rdata;
        }

        public void insertEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into tblEmployee (empFname,empMname,empLname) values");
            sql.AppendFormat("('{0}','{1}','{2}')", empFname, empMname, empLname);
            Dbhelper.processData(sql.ToString());

        }

        public void updateEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update tblEmployee set " +
                "empFname = '{0}'," +
                "empMname = '{1}'," +
                "empLname ='{2}'" +
                "where " +
                "empId = {3}",empFname,empMname,empLname,empId);
            Dbhelper.processData(sql.ToString());

        }

        public void deleteEmployee()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update tblEmployee set " +
                "dlflg = '0' " +
                "where " +
                "empId = {0}",empId);
            Dbhelper.processData(sql.ToString());

        }



    }

}
