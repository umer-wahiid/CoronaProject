﻿using ECProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECProject.Controllers
{
	public class CartController : Controller
	{
		ECDbContext sc;
		public CartController(ECDbContext dbc)
		{
			sc = dbc;
		}

		public IActionResult Index()
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

			CartViewModel cartVM = new()
			{
				CartItems = cart,
				GrandTotal = cart.Sum(x => x.Quantity * x.Price)
			};

			return View(cartVM);
		}
		public async Task<IActionResult> Add(int id)
		{
			Product product = await sc.Products.FindAsync(id);

			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

			CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

			if (cartItem == null)
			{
				cart.Add(new CartItem(product));
			}
			else
			{
				cartItem.Quantity += 1;
			}
			HttpContext.Session.SetJson("Cart", cart);

			//  TempData["Success"] = "The product has been added!";

			return Redirect(Request.Headers["Referer"].ToString());
		}
		public async Task<IActionResult> Decrease(int id)
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

			CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

			if (cartItem.Quantity > 1)
			{
				--cartItem.Quantity;
			}
			else
			{
				cart.RemoveAll(p => p.ProductId == id);
			}

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			//   TempData["Success"] = "The product has been removed!";

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Remove(int id)
		{
			List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

			cart.RemoveAll(p => p.ProductId == id);

			if (cart.Count == 0)
			{
				HttpContext.Session.Remove("Cart");
			}
			else
			{
				HttpContext.Session.SetJson("Cart", cart);
			}

			// TempData["Success"] = "The product has been removed!";

			return RedirectToAction("Index");
		}
		public IActionResult Clear()
		{
			HttpContext.Session.Remove("Cart");

			return RedirectToAction("Index");
		}
	}
}


