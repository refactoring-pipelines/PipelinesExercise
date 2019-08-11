using PipelinesExercise;
using Refactoring.Pipelines;
using Refactoring.Pipelines.Approvals;

public class SimpleCalls
{
  public static Sandwich FindBestSandwich(ZipCode zipCode)
  {
    var (zipCodePipe, bestSandwichCollector) = PipeInputsAndOutputs();
    PipelineApprovals.Verify(zipCodePipe);
    zipCodePipe.Send(zipCode);
    return bestSandwichCollector.SingleResult;
  }

  private static (InputPipe<ZipCode> zipCodePipe, CollectorPipe<Sandwich> bestSandwichCollector) PipeInputsAndOutputs()
  {
    var zipCodePipe = new InputPipe<ZipCode>("zipCode");
    var peanutButtersPipe = zipCodePipe.ProcessFunction(PeanutButterShop.GetAvailable);
    var jelliesPipe = zipCodePipe.ProcessFunction(JellyShop.GetAvailable);
    var ingredientsPipe = peanutButtersPipe.JoinTo(jelliesPipe);

    var bestSandwichPipe = ingredientsPipe.Process((p, j) => Sandwich.Create(p.BestPeanutButter, j.BestJelly));
    var bestSandwichCollector = bestSandwichPipe.Collect();
    return (zipCodePipe, bestSandwichCollector);
  }
}