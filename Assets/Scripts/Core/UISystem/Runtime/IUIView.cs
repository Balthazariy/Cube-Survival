using System;

namespace RGD.Core.UI
{
    public interface IUIView
    {
        public void Show();
        public void Hide();
        bool IsVisible { get; }
    }

    public interface IUIViewInternal : IUIView, IDisposable
    {
        void Initialize();
    }
}
