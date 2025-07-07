using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masrofy.BLL.Models
{
    public class SavingGoalVM
    {
        public int Id { get; set; }
        public double AmountSaved { get; set; }
        public DateTime Date { get; set; }
    }
}
