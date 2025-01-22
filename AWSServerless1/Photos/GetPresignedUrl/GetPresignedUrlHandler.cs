using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.Core;
using Amazon.S3;
using AWSServerless1.Infrastructure.Host;

namespace AWSServerless1.Photos.GetPresignedUrl;
public class GetPresignedUrlHandler : BaseFunction
{
	private readonly IAmazonS3 _amazonS3;
	private const string BucketName = "testbde";

	public GetPresignedUrlHandler()
	{
		_amazonS3 = new AmazonS3Client();
	}

	[LambdaFunction]
	[RestApi(LambdaHttpMethod.Get, "/photos/url")]
	public Task<IHttpResult> Handle(ILambdaContext context)
	{
		return Handle(async () =>
		{
			var url = await _amazonS3.GetPreSignedURLAsync(new Amazon.S3.Model.GetPreSignedUrlRequest
			{
				BucketName = BucketName,
				ContentType = "image/jpeg",
				Expires = DateTime.Now.AddMinutes(5),
				Verb = HttpVerb.PUT,
				Key = Guid.NewGuid().ToString()
			});
			return url;
		});
	}
}
