using FirstWebApi.Model;

namespace FirstWebApi.Data
{
    public class StudentStore
    {
        
        public static List<Student> studentList = new List<Student>()
        {
            new Student() {Id = 1,Name="Prince",PhoneNo="9833233233"},
            new Student() {Id = 2,Name="Ajay",PhoneNo="8888233233"},
            new Student() {Id = 3,Name="Utkarsh",PhoneNo="7228233233"},
            new Student() {Id = 4,Name="Govind",PhoneNo="9828239223"},
            new Student() {Id = 5,Name="Akshat",PhoneNo="9090192312"},
        };

        
    }
}
