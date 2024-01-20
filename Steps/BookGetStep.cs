namespace AmazingLibraryManagerAutomation.Steps
{
    public class BookGetStep : UtilsBase
    {

        public static void ValidaSucessoBookGet()
        {
            UtilsBase ut = new();
            Response = Client!.Execute(BookGet());

            Assert.AreEqual(200, (int)Response.StatusCode);
            Assert.IsTrue(Response.Content.Contains("id"));
        }
    }
}
