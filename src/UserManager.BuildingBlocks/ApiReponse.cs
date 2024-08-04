namespace UserManager.BuildingBlocks;

public record ApiReponse(bool Status, IEnumerable<string> Messages)
{
    public bool Status { get; set; } = Status;
    public IEnumerable<string> Messages { get; set; } = Messages;
}