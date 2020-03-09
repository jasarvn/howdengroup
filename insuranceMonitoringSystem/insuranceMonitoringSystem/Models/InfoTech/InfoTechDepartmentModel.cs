using System.Data;
using System.Text;
using insuranceMonitoringSystem.Helpers;

namespace insuranceMonitoringSystem.Models.InfoTech
{
    public class InfoTechDepartmentModel
    {

        public int deptId;
        public string deptDescription;
        public string tblname { set; get; } = "tblDepartment";


        public DataTable getdeptList()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("SELECT * FROM {0} WHERE dlflg = 1 ORDER BY deptId ASC", tblname);
            DataTable rdata = Dbhelper.GetDbData(sql.ToString());
            return rdata;
        }

        public DataTable getDepartmentInfo()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("Select * from {0} where deptId = {1}", tblname, deptId);
            DataTable rdata = Dbhelper.GetDbData(sql.ToString());
            return rdata;
        }

        public void insertDepartment()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("insert into {0} (deptDescription) values", tblname);
            sql.AppendFormat("('{0}')", deptDescription);
            Dbhelper.processData(sql.ToString());

        }

        public void updateDepartment()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update {0} set " +
                "deptDescription = '{1}'" +
                "where " +
                "deptId = {4}", tblname, deptId);
            Dbhelper.processData(sql.ToString());

        }

        public void deleteDepartment()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("update {0} set " +
                "dlflg = '0' " +
                "where " +
                "deptId = {1}", tblname, deptId);
            Dbhelper.processData(sql.ToString());

        }

    }
}
