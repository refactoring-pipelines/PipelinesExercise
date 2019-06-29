using System.Collections.Generic;
using System.Text;
using ApprovalUtilities.SimpleLogger.Writers;

namespace PipelinesExercise
{
    public class SimpleCalls
    {
        public static Sandwich FindBestSandwich(ZipCode zipCode)
        {
            var peanutButters = PeanutButterShop.GetAvailable(zipCode);
            var jellies = JellyShop.GetAvailable(zipCode);
            var bestSandwich = Sandwich.Create(peanutButters.BestPeanutButter, jellies.BestJelly);
            return bestSandwich;
        }
    }
}
