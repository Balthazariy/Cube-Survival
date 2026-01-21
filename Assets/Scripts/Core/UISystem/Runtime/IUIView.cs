using System;
using UnityEngine;

namespace RGD.Core.UI
{
    public interface IUIView
    {
        public void Show();
        public void Hide();
        bool IsVisible { get; }
    }

    internal interface IUIViewInternal : IUIView, IDisposable
    {
        void Initialize();
    }
}
