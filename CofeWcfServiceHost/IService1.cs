using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Pocos;
using Services;

namespace CofeWcfServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Coffee> GetAllCoffees();
        [OperationContract]
        Coffee GetCoffeeById(int coffee_id);
        [OperationContract]
        BasketItemDTO AddtoBasket(int basketid, int coffeeid, int amount);
        [OperationContract]
        BasketItemDTO EditBasketItem(int basketItemId, int amount);
        [OperationContract]
        void DeleteFromBasket(int basketid, int coffeeid);
        [OperationContract]
        BasketDTO CheckOutBasket(int basketId);
        [OperationContract]
        List<BasketItemDTO> GetTheBasketItems(int basket_id);
        [OperationContract]
        List<BasketItemDTO> GetAllBasketItems();

        [OperationContract]
        List<BasketDTO> GetHistoryBasket(int userId);
        [OperationContract]
        BasketDTO GetTheBasket(int basketId);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    public class CompositeType
    {
        [DataMember]
        public int coffee_id { get; set; }
        [DataMember]
        public int basket_id { get; set; }
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    }
}
