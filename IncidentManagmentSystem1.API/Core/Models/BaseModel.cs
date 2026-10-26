namespace IncidentManagmentSystem1.API.Core.Models;

public class BaseModel
{
    public bool IsDeleted { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; } = null;


    // CreatedBy and LastUpdatedBy can be used to track the user who created or last updated the record.
    // ...................
    // ...................



    public string? CreatedById { get; set; }
    public ApplicationUser? CreatedBy { get; set; }

    public string? UpdatedById { get; set; }
    public ApplicationUser? UpdatedBy { get; set; }

}
