namespace SourDictionary.Common.Models.RequestModels
{
    public class CreateEntryCommand : IRequest<Guid>
    {
        public CreateEntryCommand()
        {
        }

        public CreateEntryCommand(string subject, string content, Guid? createdById)
        {
            Subject = subject;
            Content = content;
            CreatedById = createdById;
        }

        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid? CreatedById { get; set; }
    }
}
