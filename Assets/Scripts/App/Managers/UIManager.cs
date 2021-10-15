using System.Collections.Generic;
using UnityEngine;

namespace SnowGame
{
    public class UIManager : IService, IUIManager
    {
        public GameObject Canvas { get; set; }
        public IUIElement CurrentPage { get; set; }

        private List<IUIElement> _uiPages;
        private List<IUIPopup> _uiPopups;

        private bool _loaded = false;

        public void Init()
        {
            Canvas = GameObject.Find("MainApp/CanvasSnow");
            LoadAllPopupsAndPages();
        }

        public void Update()
        {
            if (!_loaded)
                return;

            foreach (var page in _uiPages)
                page.Update();

            foreach (var popup in _uiPopups)
                popup.Update();
        }

        public void Dispose()
        {
            if (_uiPages == null)
                return;

            foreach (var page in _uiPages)
                page.Dispose();

            foreach (var popup in _uiPopups)
                popup.Dispose();
        }

        public void SetPage<T>(bool hideAll = false) where T : IUIElement
        {
            if (!_loaded)
                return;

            if (hideAll)
            {
                HideAllPages();
            }
            else
            {
                if (CurrentPage != null)
                    CurrentPage.Hide();
            }

            foreach (var _page in _uiPages)
            {
                if (_page is T)
                {
                    CurrentPage = _page;
                    break;
                }
            }
            CurrentPage.Show();
        }

        public void DrawPopup<T>(object message = null, bool setMainPriority = false) where T : IUIPopup
        {
            if (!_loaded)
                return;

            IUIPopup popup = null;
            foreach (var _popup in _uiPopups)
            {
                if (_popup is T)
                {
                    popup = _popup;
                    break;
                }
            }

            if (setMainPriority)
                popup.SetMainPriority();

            if (message == null)
                popup.Show();
            else
                popup.Show(message);
        }

        public void HidePopup<T>() where T : IUIPopup
        {
            foreach (var _popup in _uiPopups)
            {
                if (_popup is T)
                {
                    _popup.Hide();
                    break;
                }
            }
        }

        public IUIPopup GetPopup<T>() where T : IUIPopup
        {
            IUIPopup popup = null;
            foreach (var _popup in _uiPopups)
            {
                if (_popup is T)
                {
                    popup = _popup;
                    break;
                }
            }

            return popup;
        }

        public IUIElement GetPage<T>() where T : IUIElement
        {
            IUIElement page = null;
            foreach (var _page in _uiPages)
            {
                if (_page is T)
                {
                    page = _page;
                    break;
                }
            }

            return page;
        }

        public void HideAllPages()
        {
            if (!_loaded)
                return;

            foreach (var _page in _uiPages)
            {
                _page.Hide();
            }
        }

        public void HideAllPopups()
        {
            if (!_loaded)
                return;

            foreach (var _popup in _uiPopups)
            {
                _popup.Hide();
            }
        }

        private void LoadAllPopupsAndPages()
        {
            _uiPages = new List<IUIElement>();
            //_uiPages.Add(new MainPage());
            //_uiPages.Add(new GamePage());

            foreach (var page in _uiPages)
                page.Init();

            _uiPopups = new List<IUIPopup>();
            //_uiPopups.Add(new BackgroundPopup());
            //_uiPopups.Add(new GameInfoPopup());
            //_uiPopups.Add(new ExitGamePopup());
            //_uiPopups.Add(new BonusGamePopup());
            //_uiPopups.Add(new WinnerPopup());
            //_uiPopups.Add(new TriggerBonusPopup());
            //_uiPopups.Add(new StartedBonusGamePopup());
            //_uiPopups.Add(new MaximumWinPopup());
            //_uiPopups.Add(new BigWinPopup());
            //_uiPopups.Add(new NoMoneyPopup());
            //_uiPopups.Add(new QuestionPopup());
            //_uiPopups.Add(new PrizeViewerPopup());
            //_uiPopups.Add(new LoginPopup());


            foreach (var popup in _uiPopups)
                popup.Init();

            _loaded = true;
        }
    }
}
