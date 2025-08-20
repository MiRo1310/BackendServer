namespace BackendServer.Models.Finance;

public class CalculatedTravelCost
{
    public decimal Total { get; set; }

    public List<TravelCost> TravelCost { get; set; }
}