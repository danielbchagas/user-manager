namespace UserManager.BuildingBlocks;

public class Message(string id, string email)
{
    internal string Id { get; set; } = id;
    internal string Email { get; set; } = email;

    public (bool status, IEnumerable<string> messages) IsValid()
        => new MessageValidator().IsValid(this);
}

public class MessageValidator
{
    private IList<string> Messages { get; set; } = new List<string>();
    
    public (bool status, IEnumerable<string> messages) IsValid(Message message)
    {
        if (string.IsNullOrWhiteSpace(message.Id))
            Messages.Add("Id is required.");
        if (string.IsNullOrWhiteSpace(message.Email))
            Messages.Add("Email is required.");
        
        return (Messages.Count == 0, Messages);
    }
}