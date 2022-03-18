namespace Damage.presentation
{
    public interface IProjectilePoolItem
    {
        void onCreateFromPool();
        void onReturnToPool();
    }
}