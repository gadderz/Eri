namespace Eri.Api.Web.Models;

public class Response
{
    public Response()
    {
    }

    public Response(string error)
    {
        Errors.Add(error);
    }

    public bool HasErrors { get => Errors.Any(); }
    public List<string> Errors { get; } = new List<string>();

    public string ToStringErrors()
    {
        var errors = string.Empty;
        foreach (var error in Errors)
        {
            errors += $"{error}\n\n";
        }

        return errors;
    }
}

public class Response<TResult> : Response
{
    public Response() : base()
    {
    }

    public Response(string error) : base(error)
    {
    }

    public Response(TResult result)
    {
        Result = result;
    }

    public TResult Result { get; set; }
}