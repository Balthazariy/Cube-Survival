using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RGD.Core.UI
{
    public class UISystem : IUISystem, IDisposable, IInitializable
    {
        private Dictionary<Type, IUIView> _pageViews = new ();
        private Dictionary<Type, IUIView> _popupViews = new ();
        
        public void ShowPage<T>() where T : IUIView
        {
            foreach (var pageView in _pageViews)
            {
                pageView.Value.Hide();
                
                if (pageView.Key == typeof(T))
                {
                    pageView.Value.Show();
                }
            }
        }

        public void HidePage<T>() where T : IUIView
        {
            _pageViews[typeof(T)].Hide();
        }

        public void ShowPopup<T>() where T : IUIView
        {
            foreach (var popupView in _popupViews)
            {
                popupView.Value.Hide();
                
                if (popupView.Key == typeof(T))
                {
                    popupView.Value.Show();
                }
            }
        }

        public void HidePopup<T>() where T : IUIView
        {
            _popupViews[typeof(T)].Hide();
        }

        public void Initialize()
        {
            foreach (var pageView in _pageViews)
            {
            }
            
            foreach (var popupView in _popupViews)
            {
            }
        }
        
        public void Dispose()
        {
            foreach (var pageView in _pageViews)
            {
            }
            
            foreach (var popupView in _popupViews)
            {
            }
        }
    }
}
