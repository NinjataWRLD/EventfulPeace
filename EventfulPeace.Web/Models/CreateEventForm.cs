using System.ComponentModel;

namespace EventfulPeace.Web.Models;

public class CreateEventForm
{
    [DisplayName("Event Name")]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Description")]
    public string Description { get; set; } = string.Empty;

    [DisplayName("Date & Time")]
    public DateTime OccursAt { get; set; }

    [DisplayName("Upload Image")]
    public IFormFile Image { get; set; } = null!;

    [DisplayName("Region")]
    public Guid LocationId { get; set; }

    public LocationModel[] Locations { get; set; } = [];
};
