using PipelinesExercise;
using Refactoring.Pipelines;

public class SimpleCalls
{
  public static Sandwich FindBestSandwich(ZipCode zipCode)
  {
    var (zipCodePipe, bestSandwichCollector) = CreatePipe();
    zipCodePipe.Send(zipCode);
    return bestSandwichCollector.SingleResult;
  }

  public static (InputPipe<ZipCode> zipCodePipe, CollectorPipe<Sandwich> bestSandwichCollector) CreatePipe()
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