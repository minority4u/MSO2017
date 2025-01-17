﻿using GalaSoft.MvvmLight;

namespace MSO.StimmApp.Core.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => this.isBusy;
            set => this.Set(ref this.isBusy, value);
        }
    }
}
