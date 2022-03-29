namespace Eri.Core.Models;

public class Response
{
    public Response()
    {
        Errors = new List<string>();
    }

    public Response(string error)
    {
        Errors.Add(error);
    }

    public bool HasErrors { get => Errors.Any(); }
    public List<string> Errors { get; }

    public string ToStringErrors()
    {
        var errors = string.Empty;
        foreach (var error in Errors)
        {
            errors += error;
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