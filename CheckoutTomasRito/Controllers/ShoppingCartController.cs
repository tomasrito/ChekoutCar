<%@ WebService Language="C#" Class="CheckoutTomasRito.Controllers.ShoppingCartController" %>
using System;
using System.Web.Services;

namespace CheckoutTomasRito.Controllers
{
	class ShoppingCartController
	{


      /// <summary>
      /// Gets MediaCodes by Department
      /// </summary>
      /// <param name="deptId"></param>
      [HttpGet]
      [Route("ShoppingCart/GetCart/")]
      [ResponseType(typeof(List<adazzle.mediaApp.businessLogic.department.DTOs.DeptMediaCodeMediaId>))]
      public HttpResponseMessage GetShoppingCart() {
         try {
            
            return Request.CreateResponse(HttpStatusCode.OK);
         }
         catch (Exception ex) {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
         }
      }
	}
}
