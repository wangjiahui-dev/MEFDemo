using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankInterface;

/// <summary>
/// Added BankInterface as a reference. 
/// More bank cards can be added easily by inheriting ICard interface in a seperate Class Library project.
/// Need to copy the dll into "Cards" folder under bin\debug in MEFDemo_Bank.
/// </summary>
namespace BankOfChina
{
    [Export(typeof(ICard))]
    public class ZHCard : ICard
    {
        public double Money { get; set; }

        public void CheckOutMoney(double money)
        {
            this.Money -= money;
        }

        public string GetCountInfo()
        {
            return "Bank Of China";
        }

        public void SaveMoney(double money)
        {
            this.Money -= money;
        }
    }
}
