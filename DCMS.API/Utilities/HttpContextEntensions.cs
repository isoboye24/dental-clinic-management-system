namespace DCMS.API.Utilities
{
    public static class HttpContextEntensions
    {
        public static void InsertPaginationInformationInHeader(this HttpContext httpContext, int totalAmountOfRecords)
        {
            httpContext.Response.Headers.Append("Total-amount-of-records", totalAmountOfRecords.ToString());
        }
    }
}
