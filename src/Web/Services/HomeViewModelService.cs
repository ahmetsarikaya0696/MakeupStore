﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Brand> _brandRepo;
        private readonly IRepository<Category> _categoryRepo;

        public HomeViewModelService(IRepository<Product> productRepo, IRepository<Brand> brandRepo, IRepository<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync(int? brandId, int? categoryId)
        {
            var specProducts = new ProductsFilterSpecification(brandId, categoryId);
            var products = await _productRepo.GetAllAsync(specProducts);

            var vm = new HomeViewModel()
            {
                Products = products.Select
                    (
                        x => new ProductViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            PictureUri = x.PictureUri,
                            Price = x.Price
                        }
                    ).ToList(),
                Brands = await GetBrandsAsync(),
                Categories = await GetCategoriesAsync(),
                BrandId = brandId,
                CategoryId = categoryId
            };

            return vm;
        }

        private async Task<List<SelectListItem>> GetCategoriesAsync()
        {
            var categories = (await _categoryRepo.GetAllAsync()).Select
                (
                    x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }
                )
                .OrderBy(x => x.Text)
                .ToList();

            categories.Insert(0, new SelectListItem("All", ""));

            return categories;
        }

        private async Task<List<SelectListItem>> GetBrandsAsync()
        {
            var brands = (await _brandRepo.GetAllAsync()).Select
                (
                    x => new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }
                )
                .OrderBy(x => x.Text)
                .ToList();

            brands.Insert(0, new SelectListItem("All", ""));

            return brands;
        }
    }
}
