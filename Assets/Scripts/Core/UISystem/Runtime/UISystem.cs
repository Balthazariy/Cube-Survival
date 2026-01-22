using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RGD.Core.UI
{
    public class UISystem : IUISystem, IDisposable, IInitializable
    {
        private HashSet<IUIViewInternal> _pageViews = new();
        private HashSet<IUIViewInternal> _lazyPageViews = new();
        private HashSet<IUIViewInternal> _popupViews = new();
        private HashSet<IUIViewInternal> _lazyPopupViews = new();

        public void Initialize()
        {
        }

        public void Dispose()
        {
            foreach (var pageView in _pageViews)
            {
                pageView.Dispose();
            }

            foreach (var popupView in _popupViews)
            {
                popupView.Dispose();
            }

            _pageViews.Clear();
            _popupViews.Clear();
            _lazyPageViews.Clear();
            _lazyPopupViews.Clear();
        }

        public void RegisterPage<T>(T view) where T : IUIViewInternal
        {
            if (!_pageViews.Add(view))
            {
                throw new Exception($"UISystem: Page {view} is already registered");
            }

            if (!_lazyPageViews.Add(view))
            {
                throw new Exception($"UISystem: Page {view} is already registered");
            }
        }

        public void RegisterPopup<T>(T view) where T : IUIViewInternal
        {
            if (!_popupViews.Add(view))
            {
                throw new Exception($"UISystem: Popup {view} is already registered");
            }
        }

        public void ShowPage<T>(T view) where T : IUIView
        {
            if (_lazyPageViews.Contains((IUIViewInternal)view))
            {
                ((IUIViewInternal)view).Initialize();
                _lazyPageViews.Remove((IUIViewInternal)view);
            }
            
            foreach (var pageView in _pageViews)
            {
                pageView.Hide();

                if (pageView == (IUIViewInternal)view)
                {
                    pageView.Show();
                }
            }
        }

        public void HidePage<T>() where T : IUIView
        {
            // GetPage<T>(view)
        }

        public void ShowPopup<T>(T view) where T : IUIView
        {
            if (_lazyPopupViews.Contains((IUIViewInternal)view))
            {
                ((IUIViewInternal)view).Initialize();
                _lazyPopupViews.Remove((IUIViewInternal)view);
            }
            
            foreach (var popupView in _popupViews)
            {
                popupView.Hide();

                if (popupView == (IUIViewInternal)view)
                {
                    popupView.Show();
                }
            }
        }

        public void HidePopup<T>() where T : IUIView
        {
            // _popupViews[typeof(T)].Hide();
        }

        public void HideAllPopups()
        {
            foreach (var popupView in _pageViews)
            {
                popupView.Hide();
            }
        }
    }
}
