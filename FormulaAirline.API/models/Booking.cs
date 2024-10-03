namespace FormulaAirline.API.Models;


public class Booking{
    public int Id { get; set; }
    public string PassengerName { get; set; } = "";
    public string PassportNumber { get; set; } = "";
    public string FromCity { get; set; } = "";
    public string ToCity { get; set; } = "";
    public int Status { get; set; }
}