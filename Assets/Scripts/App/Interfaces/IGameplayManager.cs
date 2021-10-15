namespace SnowGame
{
    public interface IGameplayManager
    {
        T GetController<T>() where T : IController;
    }
}

