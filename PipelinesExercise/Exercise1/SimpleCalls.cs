using System;
using System.Linq;
using Refactoring.Pipelines.Async;
using Refactoring.Pipelines.InputsAndOutputs;

namespace PipelinesExercise
{
    public class SimpleCalls
    {
        public static Sandwich FindBestSandwich(ZipCode zipCode)
        {
            var inputs1AndOutputs1 = SetUpFindBestSandwichPipeline();
            inputs1AndOutputs1.Input1.Send(zipCode);
            return inputs1AndOutputs1.Output1.SingleResult;
        }

        public static Inputs1AndOutputs1<ZipCode, Sandwich> SetUpFindBestSandwichPipeline()
        {
            var zipCodePipe = new Refactoring.Pipelines.Async.InputPipe<ZipCode>("zipCode");
            var peanutButtersPipe = zipCodePipe.ProcessFunction(PeanutButterShop.GetAvailable);
            var jelliesPipe = zipCodePipe.ProcessFunction(JellyShop.GetAvailable);

            var bestPeanutButterPipe = peanutButtersPipe.Process(_ => _.BestPeanutButter);
            var bestJelliesPipe = jelliesPipe.Process(_ => _.BestJelly);
            var bestPeanutButterAndBestJellyPipe = bestPeanutButterPipe.JoinTo(bestJelliesPipe);
            var bestSandwichPipe =
                bestPeanutButterAndBestJellyPipe.Process(t => Sandwich.Create(t.Item1, t.Item2));

            var bestSandwichCollector = bestSandwichPipe.Collect();

            var inputs1AndOutputs1 = zipCodePipe.GetInputs<ZipCode>().AndOutputs<Sandwich>();
            return inputs1AndOutputs1;
        }
    }
}