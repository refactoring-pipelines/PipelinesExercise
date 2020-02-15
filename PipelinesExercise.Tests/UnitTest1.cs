using ApprovalTests.Reporters;
using NUnit.Framework;
using PipelinesExercise;
using Refactoring.Pipelines.ApprovalTests;

namespace Tests
{
    public class Tests
    {
        [UseReporter(typeof(DotReporter))]
        [Test]
        public void Test_StartHere()
        {
            var inputs1AndOutputs1 = SimpleCalls.SetUpFindBestSandwichPipeline();
            PipelineApprovals.Verify(inputs1AndOutputs1.Input1);
        }

        [Test]
        [Ignore("Turn on when ready.")]
        public void Test2_EasyWay()
        {
            new DoEverythingTheEasyWay().MakeAllTheViewModels("filename", "username", "password");
        }

        [Test]
        [Ignore("Turn on when ready.")]
        public void Test3_HardWay()
        {
            new DoEverythingTheHardWay().MakeAllTheViewModels("filename", "username", "password");
        }
    }
}