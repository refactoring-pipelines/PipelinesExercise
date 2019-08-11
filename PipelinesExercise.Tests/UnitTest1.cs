using ApprovalTests.Reporters;
using ApprovalTests.Reporters.Windows;
using NUnit.Framework;
using PipelinesExercise;
using Refactoring.Pipelines.Approvals;

public class UnitTest1
{
  [UseReporter(typeof(TortoiseTextDiffReporter))]
  [Test]
  public void Test_StartHere()
  {
    Implementation.LogOrError = Implementation.Log;
    var (zipCodePipe, bestSandwichCollector) = SimpleCalls.CreatePipe();
    PipelineApprovals.Verify(zipCodePipe);
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