namespace Course.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract(){
        }

        public HourContract(DateTime date, double valueperhour, int hours)
        {
            Date = date;
            ValuePerHour = valueperhour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }
    }
}