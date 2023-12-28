using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Dashboard.Server.Models
{
    public class EmployeesData
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string HireDate { get; set; }
        public string Country { get; set; }
        public string ReportsTo { get; set; }
        public byte[] EmployeeImage { get; set; }
    }
}
