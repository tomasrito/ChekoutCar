using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using CheckoutTomasRito.Services.Interfaces;
using CheckoutTomasRito.Services;

namespace CheckoutTomasRito.Controllers
{
    public class ShoppingCartController : ApiController
	{

        private IItemService _itemService;

        public ShoppingCartController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public ShoppingCartController() : this(new ItemService()){}

        //public ShoppingCartController() : this(new ItemService()){}

		[HttpGet]
		[Route("ShoppingCart/GetCart/")]
		[ResponseType(typeof(DTO.ShoppingCart))]
        public HttpResponseMessage GetShoppingCart()
        {
            try
            {
                var shoppingCart = _itemService.GetShoppingCart();
                return Request.CreateResponse(HttpStatusCode.OK, shoppingCart);
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [HttpPost]
        [Route("ShoppingCart/AddItem/{itemId}/{quantity}")]
		public HttpResponseMessage AddIdem(int itemId, int quantity)
		{
			try
            {
                _itemService.AddItem(itemId, quantity);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
            {
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}

		[HttpPost]
		[Route("ShoppingCart/ChangeQuantity/{itemId}/{newQuantity}")]
		public HttpResponseMessage ChangeQuantity(int itemId, int newQuantity)
		{
			try
			{
                _itemService.ChangeQuantity(itemId, newQuantity);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}


		[HttpPost]
		[Route("ShoppingCart/RemoveItem/{itemId}/")]
		public HttpResponseMessage RemoveItems(int itemId)
		{
			try
			{
                _itemService.RemoveItem(itemId);
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}

		[HttpPost]
		[Route("ShoppingCart/ClearItems/")]
		public HttpResponseMessage ClearItems()
		{
			try
			{
				_itemService.ClearItems();
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception e)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
			}
		}

    }
}
