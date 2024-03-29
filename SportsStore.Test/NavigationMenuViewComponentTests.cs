﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SportsStore.Web.Components;
using Xunit;
using SportsStore.Models.Entities;
using SportsStore.Repository.Interfaces;

namespace SportsStore.Test
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            // Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                 new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                 new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                 new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                 new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new(mock.Object);
            // Act = get the set of categories
            string[] results = ((IEnumerable<string>)(target.Invoke()
            as ViewViewComponentResult).ViewData.Model).ToArray();
            // Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plums" }, results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            // Arrange
            string categoryToSelect = "Apples";
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                 new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                 new Product {ProductID = 4, Name = "P2", Category = "Oranges"},
            }).AsQueryable<Product>());

            NavigationMenuViewComponent target = new(mock.Object);
            target.ViewComponentContext = new ViewComponentContext
            {
                ViewContext = new ViewContext
                {
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };

            target.RouteData.Values["category"] = categoryToSelect;

            // Action
            string result = (string)(target.Invoke() as
            ViewViewComponentResult).ViewData["SelectedCategory"];

            // Assert
            Assert.Equal(categoryToSelect, result);
        }
    }
}
