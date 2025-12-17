namespace DTOLayer.BasketDTO;

public class CreateBasketDto
{
    public decimal Price { get; set; }
    public decimal Count { get; set; }
    public int TotalPrice { get; set; }
    public int ProductId { get; set; }
    public int MenuTableId { get; set; }
}