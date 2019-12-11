using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;
using Repo;
using Services;

namespace BackendConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region InitialParameters
            var context = new Model1();
            Repository<Coffee> coffeeRepository = new Repository<Coffee>(context);
            Repository<Basket> basketRepository = new Repository<Basket>(context);
            Repository<BasketItem> basketItemRepository = new Repository<BasketItem>(context);
            Repository<User> userRepository = new Repository<User>(context);
            BasketService basketService = new BasketService();

            List<Coffee> coffees = coffeeRepository.ReadAll();
            List<User> users = userRepository.ReadAll();
            List<Basket> baskets = basketRepository.ReadAll();
            List<BasketItem> basketItems = basketItemRepository.ReadAll();
            #endregion

            #region basketAddDeleteTest
            //basketItems.ForEach(m => Console.WriteLine("{0} {1} {2} {3} {4}", m.Id, m.Coffee.Name, m.Basket.Id, m.Amount, m.TotalPrice));
            //basketService.AddtoBasket(3, 2, 2);
            //basketItems = basketItemRepository.ReadAll();
            //basketItems.ForEach(m => Console.WriteLine("{0} {1} {2} {3} {4}", m.Id, m.Coffee.Name, m.Basket.Id, m.Amount, m.TotalPrice));
            ////Console.ReadLine();

            //basketService.AddtoBasket(1, 2, 10000);
            //basketItems = basketItemRepository.ReadAll();
            //basketItems.ForEach(m => Console.WriteLine("{0} {1} {2} {3} {4}", m.Id, m.Coffee.Name, m.Basket.Id, m.Amount, m.TotalPrice));
            //Console.ReadLine();

            ////basketService.DeleteFromBasket(2, 4);
            ////basketService.DeleteFromBasket(3, 1);
            //basketService.DeleteFromBasket(3, 2);
            //basketItems = basketItemRepository.ReadAll();
            //basketItems.ForEach(m => Console.WriteLine("{0} {1} {2} {3} {4}", m.Id, m.Coffee.Name, m.Basket.Id, m.Amount, m.TotalPrice));
            //Console.ReadLine();

            //basketService.CheckOutBasket(1);
            //Console.ReadLine();
            #endregion

            //List<BasketItem> list = basketService.GetTheBasketItems(1);
            //list.ForEach(m => Console.WriteLine("{0} {1} {2}", m.Coffee, m.Amount, m.Basket));

            //basketItemRepository.DeleteEntity(12);
            //basketItemRepository.DeleteEntity(1033);
            //basketRepository.DeleteEntity(1009);
            context.Users.Find(6).Admin = true;
            context.SaveChanges();

        }
    }
}
