using Refactoring.Pipelines;
using Refactoring.Pipelines.ApprovalTests;
using System.Collections.Generic;
using System.Text;
using ApprovalUtilities.SimpleLogger.Writers;

namespace PipelinesExercise
{
    public class SimpleCalls
    {
        public static Sandwich FindBestSandwich(ZipCode zipCode)
        {
            // Set up Pipeline
            // PipelineApprovals.Verify()
            // Send thru pipeline
            // Original code

            var peanutButters = PeanutButterShop.GetAvailable(zipCode);
            var jellies = JellyShop.GetAvailable(zipCode);
            var bestSandwich = Sandwich.Create(peanutButters.BestPeanutButter, jellies.BestJelly);
            return bestSandwich;
        }
    }
}
