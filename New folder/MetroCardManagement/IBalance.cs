using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {
        public double Balance { get;  }
        public void WalletRecharge(double amount);
        public void DeductBalance(double amount);
        
    }
}