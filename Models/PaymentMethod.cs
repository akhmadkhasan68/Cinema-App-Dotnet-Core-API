namespace CinemaApp.Models;

public class PaymentMethod : BaseModel
{
    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;
}
