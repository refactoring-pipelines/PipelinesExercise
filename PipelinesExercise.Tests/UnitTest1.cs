using NUnit.Framework;
using PipelinesExercise;

public class UnitTest1
{
  [Test]
  public void Test_StartHere()
  {
    Implementation.LogOrError = Implementation.Log;
    SimpleCalls.FindBestSandwich(new ZipCode("90210"));
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