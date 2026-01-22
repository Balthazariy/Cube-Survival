using UnityEngine;

namespace RGD.Core.UI
{
    public interface IUISystem
    {
        public void ShowPage<T>(T view) where T : IUIView;
        public void HidePage<T>() where T : IUIView;
        public void ShowPopup<T>(T view) where T : IUIView;
        public void HidePopup<T>() where T : IUIView;
        public void HideAllPopups();
    }
}