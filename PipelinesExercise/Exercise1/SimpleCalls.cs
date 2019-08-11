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
    var jelliesPipe = zipCodePipe.ProcessFunction(JellyShop.GetAvailable);
    var ingredientsPipe = peanutButtersPipe.JoinTo(jelliesPipe);

    var bestSandwichPipe = ingredientsPipe.Process((p, j)=> Sandwich.Create(p.BestPeanutButter, j.BestJelly));
    var bestSandwichCollector = bestSandwichPipe.Collect();

    // ApprovalPipeline
    PipelineApprovals.Verify(zipCodePipe);

    // Send thru pipeline
    zipCodePipe.Send(zipCode);

    // Original code

    var bestSandwich = bestSandwichCollector.SingleResult;
    return bestSandwich;
  }
}