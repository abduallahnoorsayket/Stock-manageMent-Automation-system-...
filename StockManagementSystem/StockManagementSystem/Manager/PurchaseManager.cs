using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;
using StockManagementSystem.Repository;

namespace StockManagementSystem.Manager
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public Purchase GetLastPurchasesProductInfoById(int id)
        {
            return _purchaseRepository.GetLastPurchasesProductInfoById(id);
        }

        public bool UniquePurchaseCode(Purchase purchase)
        {
            return _purchaseRepository.UniquePurchaseCode(purchase);
        }

        public bool AddPurchase(List<Purchase> purchases)
        {
            return _purchaseRepository.AddPurchase(purchases);
        }

        public string GetLastPurchaseCode()
        {
            return _purchaseRepository.GetLastPurchaseCode();
        }

        public int GetTotalProductById(int id)
        {
            return _purchaseRepository.GetTotalProductById(id);
        }

    }
}
