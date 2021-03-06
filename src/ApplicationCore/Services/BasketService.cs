using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IRepository<Basket> _basketRepo;

        public BasketService(IRepository<Basket> basketRepo)
        {
            _basketRepo = basketRepo;
        }

        public async Task<Basket> AddItemToBasketAsync(string buyerId, int productId, int quantity)
        {
            var specBasket = new BasketWithItemsSpecification(buyerId);
            var basket = await _basketRepo.FirstOrDefaultAsync(specBasket);

            if (basket == null)
            {
                basket = new Basket() { BuyerId = buyerId };
                await _basketRepo.AddAsync(basket);
            }

            var basketItem = basket.Items.FirstOrDefault(x => x.ProductId == productId);
            
            if (basketItem != null)
                basketItem.Quantity += quantity;
            else
                basket.Items.Add(new BasketItem() { ProductId = productId, Quantity = quantity });

            await _basketRepo.UpdateAsync(basket);

            return basket;
        }
    }
}
