using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;
using Repo;
using System.Data.Entity;

namespace Services
{
   
    public class BasketService : IBasketService
    {
        Model1 model1 = new Model1();

        private IRepository<Coffee> coffeeRepository = new Repository<Coffee>();
        private IRepository<Basket> basketRepository = new Repository<Basket>();
        private IRepository<BasketItem> basketItemRepository = new Repository<BasketItem>();
        private IRepository<User> userRepository = new Repository<User>();
        
        public List<Coffee> GetAllCoffees()
        {
            return coffeeRepository.ReadAll();
        }
        public Coffee GetCoffeeById(int id)
        {
            return coffeeRepository.FindById(id);
        }
        #region basket service
        private void ChangeBasketItem(int basketId, int coffeeId, int amount)
        {
            BasketItem itemToUpdate = model1.BasketItems.Where(m => m.Coffee.Id == coffeeId && m.Basket.Id == basketId).FirstOrDefault();
            if(itemToUpdate.Amount + amount >model1.Coffees.Find(coffeeId).Storage)
            { return; }
            else
            {
                itemToUpdate.Amount += amount;
                decimal addPrice = amount * model1.Coffees.FirstOrDefault(m => m.Id == coffeeId).Price;
                itemToUpdate.TotalPrice += addPrice;
                model1.Baskets.FirstOrDefault(m => m.Id == basketId).SumPrice += addPrice;
                model1.SaveChanges();
            }
        }
        public BasketItem AddtoBasket(int basketId, int coffeeId, int amount = 1)
        {
            Coffee coffeeToAdd = coffeeRepository.FindById(coffeeId);
            Basket basketToChange = basketRepository.FindById(basketId);
            
            if (coffeeToAdd != null &&  coffeeToAdd.Storage >= amount)
            {
                BasketItem itemToAdd = new BasketItem()
                {
                    Coffee = model1.Coffees.Where(m => m.Id == coffeeId).FirstOrDefault(),
                    Amount = amount,
                    Basket = model1.Baskets.Where(m => m.Id == basketId).FirstOrDefault(),
                    TotalPrice = model1.Coffees.Where(m => m.Id == coffeeId).FirstOrDefault().Price * amount
                };
                if (model1.BasketItems.Where(m => m.Coffee.Id == coffeeId && m.Basket.Id == basketId).FirstOrDefault() != null)
                { 
                    ChangeBasketItem(basketId, coffeeId, amount); 
                    return itemToAdd; 
                }
                model1.BasketItems.Add(itemToAdd);
                model1.SaveChanges();
                basketToChange.SumPrice += itemToAdd.TotalPrice;
                model1.Baskets.Where(m => m.Id == basketId).FirstOrDefault().SumPrice += itemToAdd.TotalPrice;
                model1.SaveChanges();
                Console.WriteLine("Item added");
                return itemToAdd;
            }
            else if (coffeeToAdd != null && coffeeToAdd.Storage < amount)
            {
                Console.WriteLine("Storage less then {0}", amount);
                return null;
            }
            else
            {
                Console.WriteLine("Wrong Id, No such item to add");
                return null;
            }
        }

        public BasketItem EditBasketItem(int basketItemId, int amount)
        {
            BasketItem itemToEdit = basketItemRepository.FindById(basketItemId);
            int coffeeId = itemToEdit.Coffee.Id;
            if (amount > model1.Coffees.Find(coffeeId).Storage)
            { return itemToEdit; }
            else
            {
                decimal oldTotalPrice = itemToEdit.TotalPrice;
                itemToEdit.Amount = amount;
                decimal addPrice = amount * model1.Coffees.FirstOrDefault(m => m.Id == coffeeId).Price;
                itemToEdit.TotalPrice = addPrice;
                model1.BasketItems.FirstOrDefault(m => m.Id == basketItemId).Amount = amount;
                model1.BasketItems.Find(basketItemId).TotalPrice = addPrice;
                model1.Baskets.FirstOrDefault(m => m.Id == itemToEdit.Basket.Id).SumPrice -= oldTotalPrice;
                model1.Baskets.FirstOrDefault(m => m.Id == itemToEdit.Basket.Id ).SumPrice += addPrice;
                model1.SaveChanges();
                return itemToEdit;
            }
        }

        public void DeleteFromBasket(int basketId, int coffeeId)
        {
            Coffee coffeeToAdd = coffeeRepository.FindById(coffeeId);
            Basket basketToChange = basketRepository.FindById(basketId);
            if (basketToChange != null && coffeeToAdd != null)
            {
                BasketItem itemToDelete = model1.BasketItems.Where(m => m.Coffee.Id == coffeeId && m.Basket.Id == basketId).FirstOrDefault();
                //BasketItem itemToDelete = model1.BasketItems.FirstOrDefault(m => m.Coffee == coffeeToAdd && m.Basket == basketToChange);
                //BasketItem itemToDelete = model1.BasketItems.Where(m => m.Basket.Id == basketId).Where(m => m.Coffee.Id == coffeeId).FirstOrDefault();
                if (itemToDelete == null)
                { Console.WriteLine("Item you want to delete not in basket!"); }
                else
                {
                    //BasketItem itemToRemove = model1.BasketItems.FirstOrDefault(m => m.Coffee.Id == coffeeId && m.Basket.Id == basketId);
                    model1.BasketItems.Remove(itemToDelete);
                    model1.SaveChanges();
                    model1.Baskets.Find(basketId).SumPrice -= itemToDelete.TotalPrice;
                    model1.SaveChanges();
                }
                return;
            }
            else if (coffeeToAdd == null)
            { Console.WriteLine("System error, wrong coffee Id to oprate"); return; }
            else
            { Console.WriteLine("System error, wrong basket Id to oprate"); return; }
        }
    
        public Basket CheckOutBasket(int basketId)
        {
            Console.WriteLine("The totla money need to pay is {0}", model1.Baskets.FirstOrDefault(m => m.Id == basketId).SumPrice);
            Basket newBasket = new Basket()
            {
                User = model1.Baskets.Find(basketId).User,
                Paied = false
            };
            var itemsInTheBasket = model1.BasketItems.Where(m => m.Basket.Id == basketId).ToArray();
            foreach (var item in itemsInTheBasket)
            {
                model1.Coffees.Find(item.Coffee.Id).Storage -= item.Amount;
                model1.SaveChanges();
            }
            model1.Baskets.Find(basketId).Paied = true;
            model1.Baskets.Add(newBasket);
            model1.SaveChanges();
            return newBasket;
        }

        public List<BasketItem> GetTheBasketItems(int basketId)
        {
            List<BasketItem> allItems = model1.BasketItems.Where(m => m.Basket.Id == basketId).ToList();
            //List<BasketItem> inTheBasketItem = allItems.FindAll(m => m.Basket.Id == basketId);
            return allItems;
        }

        public List<BasketItem> GetAllBasketItems()
        {
            return basketItemRepository.ReadAll();
        }
        #endregion

        public List<Basket> GetHistoryBasket(int userId)
        {
            return basketRepository.ReadAll().Where(m => m.User.Id == userId).Where(m => m.Paied == true).ToList();
        }
        public Basket GetTheBasket(int BasketId)
        {
            return basketRepository.FindById(BasketId);
        }
    }
}
