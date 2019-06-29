namespace PipelinesExercise
{
    public class Sandwich
    {
        private Sandwich(PeanutButter peanutButter, Jelly jelly)
        {
        }

        public static Sandwich Create(PeanutButter peanutButter, Jelly jelly)
        {
            Implementation.Do();
            return new Sandwich(peanutButter, jelly);
        }
    }
}