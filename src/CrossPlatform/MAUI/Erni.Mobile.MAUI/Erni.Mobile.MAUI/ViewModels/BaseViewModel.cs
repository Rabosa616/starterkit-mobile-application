﻿using Erni.Mobile.MAUI.Models;
using Erni.Mobile.MAUI.Services;
using Erni.Mobile.MAUI.Services.Configuration;
using Erni.Mobile.MAUI.Services.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Erni.Mobile.MAUI.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        
        public readonly ILoggingService LoggingService;
        public readonly IApplicationSettingsService ApplicationSettingsService;

        public BaseViewModel(ILoggingService loggingService, IApplicationSettingsService applicationSettingsService)
        {
            this.LoggingService = loggingService;
            this.ApplicationSettingsService = applicationSettingsService;
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
