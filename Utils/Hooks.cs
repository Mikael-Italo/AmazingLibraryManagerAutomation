using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace AmazingLibraryManagerAutomation.Utils
{
    [TestClass]
    public abstract class Hooks
    {
        public TestContext? TestContext { get; set; }

        [TestInitialize]
        public void StartUp()
        {
            ResultGenerator resultGeneratorAfter = new(TestContext!.TestName!);
        }

        [TestCleanup]
        public void Cleanup()
        {
            ResultGenerator resultGeneratorBefore = new(TestContext!.TestName!, "test document");
        }
    }
}
