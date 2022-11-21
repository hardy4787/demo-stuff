namespace ODataDemo.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Score { get; set; }
    }
}
