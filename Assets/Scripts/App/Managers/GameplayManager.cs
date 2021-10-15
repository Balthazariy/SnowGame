using System.Collections.Generic;

namespace SnowGame
{
    public class GameplayManager : IService, IGameplayManager
    {
        private List<IController> _controllers;
        public void Init()
        {
            InitControllers();
        }

        private void InitControllers()
        {
            _controllers = new List<IController>
            {
                new GameplayController()
            };
            foreach (IController controller in _controllers)
            {
                controller.Init();
            }
        }

        public T GetController<T>() where T : IController
        {
            return (T)_controllers.Find(x => x is T);
        }
        public void Update()
        {
        }

        public void Dispose()
        {
        }
    }
}