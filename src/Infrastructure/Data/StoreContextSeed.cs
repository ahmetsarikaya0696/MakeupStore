using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (await context.Brands.AnyAsync() || await context.Categories.AnyAsync() || await context.Products.AnyAsync()) return;

            Brand gr = new Brand() { Name = "Golden Rose" };
            Brand mn = new Brand() { Name = "Maybelline New York" };
            Brand lp = new Brand() { Name = "L'Oreal Paris" };
            Brand se = new Brand() { Name = "Sephora" };
            Brand mc = new Brand() { Name = "Mac" };
            await context.AddRangeAsync(gr, mn, lp, se, mc);
            await context.SaveChangesAsync();

            Category ls = new Category() { Name = "Lipstick" };
            Category fo = new Category() { Name = "Foundation" };
            Category el = new Category() { Name = "Eyeliner" };
            Category ms = new Category() { Name = "Mascara" };
            await context.AddRangeAsync(ls, fo, el, ms);
            await context.SaveChangesAsync();


            Product p1 = new Product() { Name = "Golden Rose Velvet Matte Lipstick", Price = 34.90m, PictureUri = "01.jpg", Brand = gr, Category = ls };
            Product p2 = new Product() { Name = "Golden Rose Total Cover 2In1", Price = 119.49m, PictureUri = "02.jpg", Brand = gr, Category = fo };
            Product p3 = new Product() { Name = "Golden Rose Eyeliner - G.R. Dipliner (Black)", Price = 27.68m, PictureUri = "03.jpg", Brand = gr, Category = el };
            Product p4 = new Product() { Name = "Maybelline New York Lash Sensational Skey High Mascara", Price = 119.90m, PictureUri = "04.jpg", Brand = mn, Category = ms };
            Product p5 = new Product() { Name = "Maybelline New York Super Stay Matte Ink Lipstick (Nude)", Price = 95.90m, PictureUri = "05.jpg", Brand = mn, Category = ls };
            Product p6 = new Product() { Name = "L'oreal Paris Loreal Color Riche Lipstick 214 Violet Saturn", Price = 101.00m, PictureUri = "06.jpg", Brand = lp, Category = ls };
            Product p7 = new Product() { Name = "Mac Panultimate Eye Liner - Rapidblack", Price = 89.90m, PictureUri = "07.jpg", Brand = mc, Category = el };
            Product p8 = new Product() { Name = "Mac Lipstick Kinda Sexy", Price = 699.00m, PictureUri = "08.jpg", Brand = mc, Category = ls };
            Product p9 = new Product() { Name = "Sephora Rouge Lacquer Lipstick", Price = 249.00m, PictureUri = "09.jpg", Brand = se, Category = ls };
            Product p10 = new Product() { Name = "Sephora Collection Size Up Mascara Ultra Black 14ML", Price = 90.00m, PictureUri = "10.jpg", Brand = se, Category = ms };
            Product p11 = new Product() { Name = "L'oreal Paris Color Riche Lipstick (Valentine's Day Special)", Price = 59.94m, PictureUri = "11.jpg", Brand = lp, Category = ls };
            Product p12 = new Product() { Name = "L'oreal Paris Unlimited Black Mascara", Price = 178.00m, PictureUri = "12.jpg", Brand = lp, Category = ms };
            await context.AddRangeAsync(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12);
            await context.SaveChangesAsync();
        }
    }
}
