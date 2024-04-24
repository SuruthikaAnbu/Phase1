using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    public interface IBalance
    {
        public double WalletBalance { get; }
        //method
        public void WalletRecharge(double money);
        public void DeductBalance(double money);
    }
}