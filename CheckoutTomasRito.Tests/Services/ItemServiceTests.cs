using System.Collections.Generic;
using CheckoutTomasRito.DataAccess;
using CheckoutTomasRito.DataAccess.Interfaces;
using CheckoutTomasRito.DTO;
using CheckoutTomasRito.Services;
using Moq;
using NUnit.Framework;

namespace CheckoutTomasRito.Tests.Services
{
    [TestFixture]
    public class ItemServiceTests
    {
        private ItemService _itemService;
        private Mock<ShoppingCartRepository> _shoppingCartRepository;


		private void SetupPopulatedRepository()
		{
			_shoppingCartRepository = new Mock<ShoppingCartRepository>();
			_itemService = new ItemService(_shoppingCartRepository.Object);

            var carItemId1 = new CartItem { itemId = 1, quantity = 2 };
			var carItemId2 = new CartItem { itemId = 2, quantity = 10 };


			_shoppingCartRepository.Object.Add(new UserCart(){ items = new List<CartItem>(){carItemId1, carItemId2 }});
		}
            

        [Test]
        public void Add_Item_Success(){
            SetupPopulatedRepository(); ;
            _itemService.AddItem(5,10);
            var repository = _shoppingCartRepository.Object.Get();

            Assert.AreEqual(repository.items.Count, 3);
        }

		[Test]
		public void Change_Quantity_Item_Sucess()
		{
			SetupPopulatedRepository();
            _itemService.ChangeQuantity(2, 5);

			var repository = _shoppingCartRepository.Object.Get();
            var carItemId2NewQuantity = _shoppingCartRepository.Object.Get().items.Find(f => f.itemId == 2).quantity;

			Assert.AreEqual(carItemId2NewQuantity, 5);
		}

		[Test]
		public void Clear_All_Items_Success()
		{
			SetupPopulatedRepository();
            _itemService.ClearItems();

			var repository = _shoppingCartRepository.Object.Get();
			
			Assert.AreEqual(repository.items.Count, 0);
		}

		[Test]
		public void Remove_One_Item_Success()
		{
			SetupPopulatedRepository();
            _itemService.RemoveItem(2);

            var itemNotFound = _shoppingCartRepository.Object.Get().items.Find(f => f.itemId == 2);

            Assert.IsNull(itemNotFound);
		}

        [Test]
		[ExpectedException(typeof(System.ArgumentException), ExpectedMessage = "The item already exists in the shopping cart")]
		public void Add_Existing_Item_Throws_Exception()
        {
			SetupPopulatedRepository();
            _itemService.AddItem(2, 10);
        }

		[Test]
		[ExpectedException(typeof(System.ArgumentException), ExpectedMessage = "The item doesn't exist in the shopping cart")]
		public void Remove_Unexisting_Item_Throws_Exception()
		{
			SetupPopulatedRepository();
            _itemService.RemoveItem(3);
		}
    }
}
