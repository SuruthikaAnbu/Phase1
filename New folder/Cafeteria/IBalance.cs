using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria
{
    public interface IBalance
    {
        public double WalletBalance { get;  }
        public void WalletRecharge(double amount);
        public void DeductAmount(double amount);
    }
}