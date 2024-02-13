namespace AmazingLibraryManagerAutomation.Utils
{
    public class UtilsBase
    {
        public static RestClient Client = new (GetValueJsonGlobalVariables("Url"));
        public static RestResponse? Response { get; set; }
        public UtilsBase() {  }

        /// <summary>
        /// RestRequest Methods for implementation at steps.cs
        /// Métodos RestRequest para implementação em steps.cs 
        /// </summary>

        #region Book Requests

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

        #endregion Book Requests

        #region BookLoan Requests



        #endregion BookLoan Requests

        #region Users Requests

        public static RestRequest UserGet()
        {
            RestRequest request = new($"user", Method.Get);

            return request;
        }

        public static RestRequest UserPost(string Name, string Email, string PhoneNumber)
        {
            RestRequest request = new($"user", Method.Post);
            request.AddJsonBody(new
            {
                name = Name,
                email = Email,
                phoneNumber = PhoneNumber,
            });

            return request;
        }
        
        public static RestRequest UserPut(string Id, string Name, string Email, string PhoneNumber)
        {
            RestRequest request = new($"user", Method.Put);
            request.AddJsonBody(new
            {
                id = Id,
                name = Name,
                email = Email,
                phoneNumber = PhoneNumber,
            });

            return request;
        }

        public static RestRequest UserGetAvailibles()
        {
            RestRequest request = new($"user/availibles", Method.Get);

            return request;
        }

        public static RestRequest UserIdGet(string Id)
        {
            RestRequest request = new("user/{id}", Method.Get);
            request.AddParameter("id", Id);

            return request;
        }

        public static RestRequest UserIdDelete(string Id)
        {
            RestRequest request = new("user/{id}", Method.Delete);
            request.AddParameter("id", Id);

            return request;
        }

        #endregion Users Requests

        #region Métodos úteis
        public static string GetValueJsonGlobalVariables(string key)
        {
            StreamReader r = new("GlobalVariables.json");

            var data = (JObject)JsonConvert.DeserializeObject(r.ReadToEnd());
            string Value = data[key].Value<string>();

            return Value;
        }
        #endregion Métodos úteis
    }
}