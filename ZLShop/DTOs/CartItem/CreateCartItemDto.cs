using System.ComponentModel.DataAnnotations;

public class CreateCartItemDto
{
    [Range(1, int.MaxValue, ErrorMessage = "ProductVariantId không hợp lệ")]
    public int ProductVariantId { get; set; }

    [Required(ErrorMessage = "Số lượng không được để trống")]
    [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
    public int Quantity { get; set; }

}