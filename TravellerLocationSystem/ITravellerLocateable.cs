namespace TravellerLocationSystem;

public interface ITravellerLocateable
{
    string LocateableName { get; }
    TravellerLocation Location { get; set; }
}