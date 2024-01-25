namespace AmazingLibraryManagerAutomation.Features.Book
{
    [TestClass]
    public class BookPostFeature : Hooks
    {
        [TestMethod]
        public void ValidarLivro2()
        {
            ResultGenerator Result = new(TestContext!.TestName!);

            Result.WriteBDD("Dado");
            Result.WriteBDD("Quando");
            Result.WriteBDD("Então");
        }

    }
}