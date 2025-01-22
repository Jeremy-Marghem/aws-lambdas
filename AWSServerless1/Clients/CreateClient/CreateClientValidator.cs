using FluentValidation;

namespace AWSServerless1.Clients.CreateClient;
public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
	public CreateClientValidator()
	{
		RuleFor(x => x.Name).NotEmpty().MaximumLength(10);
	}
}
