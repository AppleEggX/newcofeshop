using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Services;
using Pocos;
using System.Net;
using Repo;


namespace CofeWcfServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        BasketService service;
        public Service1()
        {
            service = new BasketService();
        }
        public List<Coffee> GetAllCoffees()
        {
            return service.GetAllCoffees();
        }
        public Coffee GetCoffeeById(int id)
        {
            return service.GetCoffeeById(id);
        }
        public BasketItemDTO AddtoBasket(int basketid, int coffeeid, int amount)
        {
            BasketItem i = service.AddtoBasket(basketid, coffeeid, amount);
            return new BasketItemDTO
            {
                Id = i.Id,
                CoffeeName = i.Coffee.Name,
                Amount = i.Amount,
                TotalPrice = i.TotalPrice
            };
        }

        public BasketDTO CheckOutBasket(int basketId)
        {
            Basket basket = service.CheckOutBasket(basketId);
            return new BasketDTO
            {
                Id = basket.Id,
                Paied = basket.Paied,
                SumPrice = basket.SumPrice
            };
        }
        public BasketItemDTO EditBasketItem(int basketItemId, int amount)
        {
            BasketItem i = service.EditBasketItem(basketItemId, amount);
            return new BasketItemDTO
            {
                Amount = i.Amount,
                CoffeeName = i.Coffee.Name,
                TotalPrice = i.TotalPrice,
                Id = i.Id
            };
        }

        public void DeleteFromBasket(int basketid, int coffeeid)
        {
            service.DeleteFromBasket(basketid, coffeeid);
        }

        public List<BasketItemDTO> GetTheBasketItems(int basketId)
        {
            List<BasketItem> itemList = service.GetTheBasketItems(basketId);
            IEnumerable<BasketItemDTO> itemDTOs = itemList.Select(i => new BasketItemDTO
            {
                Id = i.Id,
                CoffeeName = i.Coffee.Name,
                Amount = i.Amount,
                TotalPrice = i.TotalPrice
            });
            return itemDTOs.ToList();
        }

        public List<BasketItemDTO> GetAllBasketItems()
        {
            List<BasketItem> itemList = service.GetAllBasketItems();
            IEnumerable<BasketItemDTO> itemDTOs = itemList.Select(i => new BasketItemDTO
            {
                Id = i.Id,
                CoffeeName = i.Coffee.Name,
                Amount = i.Amount,
                TotalPrice = i.TotalPrice
            });
            return itemDTOs.ToList();
        }

        public List<BasketDTO> GetHistoryBasket(int userId)
        {
            List<Basket> basketList = service.GetHistoryBasket(userId);
            IEnumerable<BasketDTO> basketDTOs = basketList.Select(i => new BasketDTO
            {
                Id = i.Id,
                Paied = i.Paied,
                SumPrice = i.SumPrice
            });
            return basketDTOs.ToList();
        }

        public BasketDTO GetTheBasket(int basketId)
        {
            Basket theBasket = service.GetTheBasket(basketId);
            return new BasketDTO
            {
                Id = theBasket.Id,
                Paied = theBasket.Paied,
                SumPrice = theBasket.SumPrice
            };
        }
    }
}
