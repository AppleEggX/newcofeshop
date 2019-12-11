using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;
using System.ServiceModel;

namespace Services
{
  
    interface IBasketService
    {
       
        BasketItem AddtoBasket(int basketid, int coffeeid, int amount);
        BasketItem EditBasketItem(int basketItemId, int amount);
        void DeleteFromBasket(int basketid, int coffeeid);
        Basket CheckOutBasket(int basketId);
        List<BasketItem> GetTheBasketItems(int basketId);
        List<BasketItem> GetAllBasketItems();
        List<Coffee> GetAllCoffees();
        Coffee GetCoffeeById(int id);

        List<Basket> GetHistoryBasket(int userId);
        Basket GetTheBasket(int BasketId);
    }
}
