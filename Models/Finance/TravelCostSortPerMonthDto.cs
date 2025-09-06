namespace BackendServer.Models.Finance;

public class TravelCostSortPerMonthDto
{
    public required  IQueryable<TravelCost> M1 { get; set; } 
    public required IQueryable<TravelCost> M2 { get; set; }
    public required IQueryable<TravelCost> M3 { get; set; }
    public required IQueryable<TravelCost> M4 { get; set; }
    public required IQueryable<TravelCost> M5 { get; set; }
    public required IQueryable<TravelCost> M6 { get; set; }
    public required IQueryable<TravelCost> M7 { get; set; }
    public required IQueryable<TravelCost> M8 { get; set; }
    public required IQueryable<TravelCost> M9 { get; set; }
    public required IQueryable<TravelCost> M10 { get; set; }
    public required IQueryable<TravelCost> M11 { get; set; }
    public required IQueryable<TravelCost> M12 { get; set; }
    
}