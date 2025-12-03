namespace DTOLayer.ProductDTO;

public class UpdateProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    public bool Status { get; set; }
}