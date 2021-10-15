namespace SnowGame
{
    public class GameClient : ServiceLocatorBase
    {
		private static object _sync = new object();

		private static GameClient _Instance;
		public static GameClient Instance
		{
			get
			{
				if (_Instance == null)
				{
					lock (_sync)
					{
						_Instance = new GameClient();
					}
				}
				return _Instance;
			}
		}

		internal GameClient()
		: base()
		{
			AddService<ISoundManager>(new SoundManager());
			AddService<IUIManager>(new UIManager());
            AddService<IAppStateManager>(new AppStateManager());
            AddService<IGameplayManager>(new GameplayManager());
            //AddService<IPlayerManager>(new PlayerController());
        }

		public static T Get<T>()
		{
			return Instance.GetService<T>();
		}

		public override void Dispose()
		{
			base.Dispose();
			_Instance = null;
		}
	}
}