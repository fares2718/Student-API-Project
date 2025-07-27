using StudentProjectAPI.Model;

namespace StudentProjectAPI.DataSemulation
{
    public class StudentDataSemulation
    {
        public static readonly List<Student> StudentsList = new List<Student>()
        {
            new Student {Id=1,Name="Fares Obaid",Age=20,Grade=95},
            new Student {Id=2,Name="Some Shit",Age=22,Grade=78},
            new Student {Id=3,Name="Any Thing",Age=30,Grade=88},
            new Student {Id=4,Name="Hassan Obaid",Age=25,Grade=93},
        };
    }
}
