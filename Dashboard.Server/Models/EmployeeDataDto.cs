using System.Reflection.Metadata;

namespace Dashboard.Server.Models
{
    public class EmployeeDataDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string HireDate { get; set; }
        public string Country { get; set; }
        public string ReportsTo { get; set; }
        public string EmployeeImage { get; set; }
    }
}
