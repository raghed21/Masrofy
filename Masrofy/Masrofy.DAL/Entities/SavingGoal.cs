namespace Masrofy.DAL.Entities
{
    public class SavingGoal
    {
        public int Id { get; set; }
        public double AmountSaved { get; set; }
        public DateTime Date { get; set; }

        //-----------------------------------------------------
        //public int userId { get; set; } //FK

        //public UserProfile User { get; set; } // Navigation Prop 

    }
}
