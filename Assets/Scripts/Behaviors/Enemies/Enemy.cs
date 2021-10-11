public abstract class Enemy : ControllableBehavior, IEnemy
{
    public abstract int ScorePoints { get; }
}
