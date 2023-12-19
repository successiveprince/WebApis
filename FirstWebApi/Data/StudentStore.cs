using FirstWebApi.Model;

namespace FirstWebApi.Data
{
    public class StudentStore
    {
        
        public static List<Student> studentList = new List<Student>()
        {
            new Student() {Id = 1,Name="Prince", Age = 16 , PhoneNo="9833233233" , Password = "Prince@123" , ConfirmPassword = "Prince@123"},
            new Student() {Id = 2,Name="Ajay", Age = 17 , PhoneNo="8888233233" , Password = "Successive@" , ConfirmPassword = "Successive@"},
            new Student() {Id = 3,Name="Utkarsh", Age = 18 , PhoneNo="7228233233"},
            new Student() {Id = 4,Name="Govind", Age = 20 , PhoneNo="9828239223"},
            new Student() {Id = 5,Name="Akshat", Age = 12, PhoneNo="9090192312"},
        };

        
    }
}
