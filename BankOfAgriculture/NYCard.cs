using BankInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfAgriculture
{
    [Export(typeof(ICard))]
    public class NYCard : ICard
    {
        public double Money { get; set; }

        public void CheckOutMoney(double money)
        {
            this.Money -= money;
        }

        public string GetCountInfo()
        {
            return "Nong Ye Yin Hang";
        }

        public void SaveMoney(double money)
        {
            this.Money += money;
        }
    }
}
