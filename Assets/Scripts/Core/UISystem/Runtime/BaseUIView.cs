using System;
using UnityEngine;

namespace RGD.Core.UI
{
    public class BaseUIView<TModel> where TModel : BaseUIViewModel, IDisposable, IUIView
    {
        protected TModel ViewModel;
        protected GameObject SelfObject;
        
        public BaseUIView(string elementName)
        {
            SelfObject = GameObject.Find(elementName);
            
            ViewModel = (TModel)Activator.CreateInstance(typeof(TModel));
        }
        
        public virtual void Initialize()
        {
            ViewModel.Initialize();
        }

        public virtual void Dispose()
        {
            ViewModel.Dispose();
        }
        
        public virtual void Show()
        {
        }
        
        public virtual void Hide()
        {
        }
    }
}
