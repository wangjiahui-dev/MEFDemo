using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankInterface
{
    public interface ICard
    {
        double Money { get; set; }
        string GetCountInfo();
        void SaveMoney(double money);
        void CheckOutMoney(double money);
    }
}
