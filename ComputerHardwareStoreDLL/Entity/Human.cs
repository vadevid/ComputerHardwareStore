namespace ComputerHardwareStoreDLL.Entity
{
    public class Human
    {
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public virtual string GetFullName()
        {
            var temp = $"{SecondName} {FirstName} ";
            if (MiddleName != null) temp += $"{MiddleName}";
            return temp;
        }
    }
}
