using Ardalis.GuardClauses;
using BananaPie.Users.Core.Events;
using MediatR;

namespace BananaPie.Users.Core.Handlers
{
    public class NewKnownAliasAddedEventHandler : INotificationHandler<NewKnownAliasAddedEvent>
    {
        //private readonly IEmailSender _emailSender;

        // In a REAL app you might want to use the Outbox pattern and a command/queue here...
        //public NewUserAddedEventHandler(IEmailSender emailSender)
        public NewKnownAliasAddedEventHandler()
        {
            //_emailSender = emailSender;
        }

        // configure a test email server to demo this works
        // https://ardalis.com/configuring-a-local-test-email-server
        public Task Handle(NewKnownAliasAddedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
            return null;

            //return _emailSender.SendEmailAsync("test@test.com", "test@test.com", $"{domainEvent.SurveyQuestion.Title} was completed.", domainEvent.SurveyQuestion.ToString());
        }
    }
}
