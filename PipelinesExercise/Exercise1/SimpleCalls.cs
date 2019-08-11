using PipelinesExercise;
using Refactoring.Pipelines;
using Refactoring.Pipelines.Approvals;

public class SimpleCalls
{
  public static Sandwich FindBestSandwich(ZipCode zipCode)
  {
    // Set up Pipeline
    var zipCodePipe = new InputPipe<ZipCode>("zipCode");
    var peanutButtersPipe = zipCodePipe.ProcessFunction(PeanutButterShop.GetAvailable);
    var peanutButtersCollector = peanutButtersPipe.Collect();
    var jelliesPipe = zipCodePipe.ProcessFunction(JellyShop.GetAvailable);
    var jelliesCollector = jelliesPipe.Collect();

    // ApprovalPipeline
    PipelineApprovals.Verify(zipCodePipe);

    // Send thru pipeline
    zipCodePipe.Send(zipCode);

    // Original code

    var peanutButters = peanutButtersCollector.SingleResult;
    var jellies = jelliesCollector.SingleResult;
    var bestSandwich = Sandwich.Create(peanutButters.BestPeanutButter, jellies.BestJelly);
    return bestSandwich;
  }
}