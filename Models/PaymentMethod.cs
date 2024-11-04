namespace CinemaApp.Models;

public class PaymentMethod : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; } = true;
}
