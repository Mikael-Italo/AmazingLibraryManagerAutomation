namespace AmazingLibraryManagerAutomation.Utils
{
    [TestClass]
    public abstract class Hooks
    {
        public TestContext? TestContext { get; set; }

        [TestInitialize]
        public void StartUp()
        {
            ResultGenerator RgA = new(TestContext!.TestName!);
            RgA.CreateBaseResult();
        }

        [TestCleanup]
        public void Cleanup()
        {
            ResultGenerator RgF = new(TestContext!.TestName!);
            RgF.FinishBaseResult();
        }
    }
}
