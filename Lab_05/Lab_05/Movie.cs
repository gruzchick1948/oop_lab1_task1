namespace laba5
{
    public abstract class Movie
    {
        public abstract float Rating { get; set; }
        protected abstract int AgeLimit { get; set; }
        public virtual void IncrementAgeLimit()
        {
            --AgeLimit;
        }
        public abstract bool isGood();
    }
}
