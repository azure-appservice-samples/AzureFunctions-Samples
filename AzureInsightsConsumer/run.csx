using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");

    // Get request body
    dynamic data = await req.Content.ReadAsAsync<object>();

    // Gets the name of the resource from the Auto-Scale event.
    name = data?.context?.resourceName.ToString();
    operation = data?.operation;

    log.Info($"Resource: '{name}' is performing a {operation} operation.")

    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "This is not a valid auto-scale payload.")
        : req.CreateResponse(HttpStatusCode.OK, $"Hello {name}");
}