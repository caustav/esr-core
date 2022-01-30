using Newtonsoft.Json;

public class InvoiceCreated
{
    public string InvoiceNumber { get; set; } = string.Empty;   
    public string Name {get; set; } = nameof(InvoiceCreated);
    public string Amount {get; set;} = string.Empty;
    public string Vendor {get; set;} = string.Empty;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}