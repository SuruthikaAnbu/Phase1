using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalShop
{
    public interface IWallet
    {
        public double WalletBalance { get; }
        public void WalletRecharge(double money);
        public void DeductBalance(double money);
        //public IWallet();
    }
}