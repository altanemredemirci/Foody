namespace Foody.WEBUI.Models
{
    public class ErrorViewModel
    {
        public string Message { get; set; }
        public ErrorObj errorObj { get; set; }
    }

    public class ErrorObj
    {
        public int Code { get; set; }
        public string Css { get; set; }
    }
}
