
namespace Domain;

public class Activity
{
    // public Guid Id { get; set; } = Guid.NewGuid().ToString();
    // String is easier to work with.
    // [Key] // using System.ComponentModel.DataAnnotations; // In case the primary key was not named "Id"
    // public string NotID { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public required string Category { get; set; }
    public bool IsCancelled { get; set; }

    // Location Props
    public required string City { get; set; }
    public required string Venue { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
