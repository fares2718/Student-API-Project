using StudentProjectAPI.Model;

namespace StudentProjectAPI.DataSemulation
{
    public class StudentDataSemulation
    {
        public static readonly List<Student> StudentsList = new List<Student>()
        {
            new Student {Id=1,Name="Fares Obaid",Age=20,Grade=95},
            new Student {Id=2,Name="Ali Ahmad",Age=22,Grade=48},
            new Student {Id=3,Name="Osama Radi",Age=30,Grade=49},
            new Student {Id=4,Name="Hassan Housain",Age=25,Grade=93},
        };
    }
}
