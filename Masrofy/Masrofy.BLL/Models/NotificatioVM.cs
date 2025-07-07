using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Models
{
    public class NotificatioVM
    {
        public int Id { get; set; }
        public String Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsRead { get; set; }
        //----------------------------------------------

        public int expenseId { get; set; }//FK
        public int userId { get; set; } //FK
    }
}
