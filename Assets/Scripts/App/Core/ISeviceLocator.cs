namespace SnowGame
{
    public interface ISeviceLocator
    {
        T GetService<T>();
        void Update();
    }
}