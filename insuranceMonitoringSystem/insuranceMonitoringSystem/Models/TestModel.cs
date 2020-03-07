using System;
using System.Data;
using System.Data.Entity;
using insuranceMonitoringSystem.Helpers;

namespace insuranceMonitoringSystem.Models
{
    public class TestModel
    {
        public DataTable testdata()
        {
            DataTable rdata = Dbhelper.GetDbData("select * from tblEmployee");
            return rdata;
        }
    }
   
}
