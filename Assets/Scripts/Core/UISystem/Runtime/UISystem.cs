using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RGD.Core.UI
{
    public class UISystem : IUISystem, IDisposable, IInitializable
    {
        private Dictionary<Type, IUIViewInternal> _pageViews = new ();
        private Dictionary<Type, IUIViewInternal> _popupViews = new ();
        
        internal void RegisterPage<T>(T view) where T : IUIViewInternal
        {
            Type type = typeof(T);

            if (_pageViews.ContainsKey(type))
            {
                throw new Exception($"UISystem: Page {type} is already registered");
            }
            
            _pageViews.Add(type, view);
        }

        internal void RegisterPopup<T>(T view) where T : IUIViewInternal
        {
            Type type = typeof(T);
            
            if (_popupViews.ContainsKey(type))
            {
                throw new Exception($"UISystem: Popup {type} is already registered");
            }
            
            _popupViews.Add(type, view);
        }
        
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

        public void HideAllPopups()
        {
            foreach (var popupView in _pageViews)
            {
                popupView.Value.Hide();
            }
        }

        public void Initialize()
        {
            foreach (var pageView in _pageViews)
            {
                pageView.Value.Initialize();
            }
            
            foreach (var popupView in _popupViews)
            {
                popupView.Value.Initialize();
            }
        }
        
        public void Dispose()
        {
            foreach (var pageView in _pageViews)
            {
                pageView.Value.Dispose();
            }
            
            foreach (var popupView in _popupViews)
            {
                popupView.Value.Dispose();
            }
            
            _pageViews.Clear();
            _popupViews.Clear();
        }
    }
}
