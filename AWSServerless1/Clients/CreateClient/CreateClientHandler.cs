using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.Core;
using FluentValidation;
using AWSServerless1.Infrastructure.Host;
using AWSServerless1.Shared.Dto;

namespace AWSServerless1.Clients.CreateClient;
public class CreateClientHandler : BaseFunction
{
	private readonly IValidator<CreateClientCommand> _validator;

	public CreateClientHandler()
	{
		_validator = new CreateClientValidator();
	}

	[LambdaFunction]
	[RestApi(LambdaHttpMethod.Post, "/clients")]
	public Task<IHttpResult> Handle([FromBody] CreateClientCommand request, ILambdaContext context)
	{
		return Handle(async () =>
		{
			await _validator.ValidateAndThrowAsync(request);
			return new ClientDto { Id = Guid.NewGuid(), Name = request.Name };
		});

		//context.Logger.LogInformation("Handling the 'Create' Request");

		//var result = _validator.Validate(request);

		//if (!result.IsValid)
		//{
		//	return HttpResults.BadRequest(JsonSerializer.Serialize(result.Errors));
		//}

		//return HttpResults.Ok(JsonSerializer.Serialize(request));
	}
}
