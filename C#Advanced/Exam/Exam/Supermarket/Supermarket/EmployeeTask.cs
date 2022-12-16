namespace Supermarket
{
    public class EmployeeTask
    {
        public EmployeeTask(string name, string description, DateTime deadline)
        {
            this.Name = name;
            this.Description = description;
            this.Deadline = deadline;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }

        public override string ToString()
        {
            return $"Task: {this.Name} - Description: {this.Description} - Deadline: {this.Deadline}";
        }
    }
}
