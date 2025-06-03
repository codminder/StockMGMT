using WebApp.DataContracts;

namespace WebApp.MockData;

public static class MockProductList
{
    public static ProductListViewModel ProductList = new ProductListViewModel()
    {
        Products =
        [
            new ProductViewModel()
            {
                Id = 1,
                Name = "Pen",
                Description = "Some information",
                Price = 12.50m,
                Stock = 120,
                DiscountPercentage = 10
            },
            new ProductViewModel()
            {
                Id = 2,
                Name = "Pencil",
                Description = "Writing tool",
                Price = 5.99m,
                Stock = 200,
                DiscountPercentage = 5
            },
            new ProductViewModel()
            {
                Id = 3,
                Name = "Notebook",
                Description = "Paper notebook",
                Price = 15.99m,
                Stock = 75,
                DiscountPercentage = 20
            }
        ]
    };
}