using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.DAL.Entities
{
    public class Notification
    {
        public int Id { get; set; } 
        public String Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        //----------------------------------------------

        public int expenseId { get; set; }//FK
        //public int userId { get; set; } //FK
        //public UserProfile User { get; set; } //Navigation prop 
    }
}
