namespace SnowGame
{
    public interface IAppStateManager
    {
        Data.Enumerators.AppState AppState { get; set; }
        void ChangeAppState(Data.Enumerators.AppState stateTo);
    }
}