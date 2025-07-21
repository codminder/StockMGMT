namespace WebApp.DataContracts;

public class ProductListViewModel
{
    public required List<ProductViewModel> Products { get; set; }

    public decimal Total => Products.Sum(x => x.CalculateDiscounted);
}