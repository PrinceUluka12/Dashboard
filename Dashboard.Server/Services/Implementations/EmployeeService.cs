using Dashboard.Server.Data;
using Dashboard.Server.Models;
using Dashboard.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dashboard.Server.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;
        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> PostToDb(List<EmployeeDataDto> data)
        {
            try
            {
                List<EmployeesData> DataList = new List<EmployeesData>();
                

                foreach (var employee in data)
                {
                    EmployeesData employeesData = new EmployeesData();
                    employeesData.EmployeeImage = GetImageData(employee.EmployeeImage);
                    employeesData.HireDate = employee.HireDate;
                    employeesData.Name = employee.Name;
                    employeesData.Title = employee.Title;
                    employeesData.Country = employee.Country;
                    employeesData.ReportsTo = employee.ReportsTo;

                   DataList.Add(employeesData);
                }
                await _db.EmployeesDatas.AddRangeAsync(DataList);
                await _db.SaveChangesAsync();
           
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return false;
            }
        }

        private static byte[] GetImageData(string imagePath)
        {
            try
            {
                Image image = Image.FromFile("C:\\Users\\Prince\\Desktop\\Learning\\Dashboard" + imagePath + ".jpg");
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }

            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }

        }

        public async Task<List<EmployeesData>> GetAll()
        {
            try
            {
                var data = await _db.EmployeesDatas.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return new List<EmployeesData>();
            }
        }
    }
}
