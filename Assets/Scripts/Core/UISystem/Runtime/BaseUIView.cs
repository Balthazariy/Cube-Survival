using System;
using UnityEngine;

namespace RGD.Core.UI
{
    public abstract class BaseUIView<TViewModel> : IUIViewInternal where TViewModel : BaseUIViewModel
    {
        protected TViewModel ViewModel { get; private set; }
        protected GameObject SelfObject { get; private set; }
        
        public bool IsVisible { get; private set; }
        
        public BaseUIView(string elementName, TViewModel viewModel)
        {
            ViewModel = viewModel;
            SelfObject = FindSelfObject(elementName);
        }
        
        public virtual void Initialize()
        {
            ViewModel.Initialize();
            Hide();
        }

        public virtual void Dispose()
        {
            ViewModel.Dispose();
        }

        private GameObject FindSelfObject(string selfObjectName)
        {
            return GameObject.Find(selfObjectName);
        }
        
        public virtual void Show()
        {
            SelfObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            SelfObject.SetActive(false);
        }
    }
}
