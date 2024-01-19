namespace AmazingLibraryManagerAutomation.Utils
{
    public class RequestDefault
    {
        public static RestClient? Client { get; set; }
        public static RestResponse? Response { get; set; }
        public RequestDefault() { Client = new("http://localhost:5019/"); }
        
        /// <summary>
        /// RestRequest Methods for implementation at steps.cs
        /// Métodos RestRequest para implementação em steps.cs 
        /// </summary>
        public static RestRequest BookAvailibleGet()
        {
            RestRequest request = new ($"book/availible", Method.Get);

            return request;
        }
        
        public static RestRequest BookGet()
        {
            RestRequest request = new ($"book", Method.Get);

            return request;
        }

        public static RestRequest BookPost(string Title, string SubTitle, string Author)
        {
            RestRequest request = new($"book", Method.Post);
            request.AddJsonBody(new
            {
                title = Title,
                subTitle = SubTitle,
                author = Author,
            });

            return request;
        }
        
        public static RestRequest BookPut(string Id, string Title, string SubTitle, string Author)
        {
            RestRequest request = new($"book", Method.Put);
            request.AddJsonBody(new
            {
                id = Id,
                title = Title,
                subTitle = SubTitle,
                author = Author,
            });

            return request;
        }
        
        public static RestRequest BookIdGet(string Id)
        {
            RestRequest request = new("book/{id}", Method.Get);
            request.AddParameter("id", Id);

            return request;
        }
        
        public static RestRequest BookIdDelete(string Id)
        {
            RestRequest request = new("book/{id}", Method.Delete);
            request.AddParameter("id", Id);

            return request;
        }
    }
}
