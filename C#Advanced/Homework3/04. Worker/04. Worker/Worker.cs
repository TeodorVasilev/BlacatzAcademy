namespace _04._Worker
{
    public class Worker
    {
        private int workingMonths;
        private int monthWorkingDays;
        private int dayWorkingHours;

        public Worker(string name, decimal hourlyRate)
        {
            this.Name = name;
            this.HourlyRate = hourlyRate;
            this.workingMonths = 12;
            this.monthWorkingDays = 22;
            this.dayWorkingHours = 8;
        }

        public string Name { get; set; }
        public decimal HourlyRate { get; set; }

        public decimal YearlySalary()
        {
            decimal yearlySalary = (this.monthWorkingDays * this.dayWorkingHours) * this.workingMonths;
            return yearlySalary;
        }
    }
}
