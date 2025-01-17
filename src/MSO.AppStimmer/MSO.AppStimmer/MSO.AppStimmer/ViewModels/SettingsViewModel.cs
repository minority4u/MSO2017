﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Ioc;
using MSO.Common;
using MSO.StimmApp.Core.Helpers;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Models;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private int appPrimaryColorRedChannel;
        private int appPrimaryColorGreenChannel;
        private int appPrimaryColorBlueChannel;
        private ObservableCollection<ColorThemeItem> colorThemes;
        private int selectedColorThemeIndex;

        [PreferredConstructor]
        public SettingsViewModel()
        {
            var colorFromSettingsHex = App.Settings.AppColors.PrimaryColor;
            var colorFromSettings = Color.FromHex(colorFromSettingsHex);

            this.AppPrimaryColorRedChannel = Convert.ToInt32(255 * colorFromSettings.R);
            this.AppPrimaryColorGreenChannel = Convert.ToInt32(255 * colorFromSettings.G);
            this.AppPrimaryColorBlueChannel = Convert.ToInt32(255 * colorFromSettings.B);

            this.InitializeColorThemes();
        }

        private void InitializeColorThemes()
        {
            var standardColorThemes = new List<ColorThemeItem>()
            {
                new ColorThemeItem()
                {
                    Description = "Green Sky",
                    ColorTheme = Core.Helpers.ColorThemes.GreenSky
                },
                new ColorThemeItem()
                {
                    Description = "Night and Day",
                    ColorTheme = Core.Helpers.ColorThemes.NightAndDay
                },
                new ColorThemeItem()
                {
                    Description = "Relaxed",
                    ColorTheme = Core.Helpers.ColorThemes.Relaxed
                },
                new ColorThemeItem()
                {
                    Description = "Walk in the Forest",
                    ColorTheme = Core.Helpers.ColorThemes.WalkInTheForest
                },
            };

            this.ColorThemes = new ObservableCollection<ColorThemeItem>(standardColorThemes);
        }

        public int AppPrimaryColorRedChannel
        {
            get => this.appPrimaryColorRedChannel;
            set => this.Set(ref this.appPrimaryColorRedChannel, value);
        }

        public int AppPrimaryColorGreenChannel
        {
            get => this.appPrimaryColorGreenChannel;
            set => this.Set(ref this.appPrimaryColorGreenChannel, value);
        }

        public int AppPrimaryColorBlueChannel
        {
            get => this.appPrimaryColorBlueChannel;
            set => this.Set(ref this.appPrimaryColorBlueChannel, value);
        }

        public ObservableCollection<ColorThemeItem> ColorThemes
        {
            get => this.colorThemes;
            set => this.Set(ref this.colorThemes, value);
        }

        public int SelectedColorThemeIndex
        {
            get => this.selectedColorThemeIndex;
            set
            {
                this.Set(ref this.selectedColorThemeIndex, value);
                App.Settings.AppColors = this.ColorThemes[this.selectedColorThemeIndex].ColorTheme;


                var color = Color.FromHex(Settings.Current.AppColors.DarkColor);
                App.NavigationBarController.SetStatusBarColor(color);
            }
        }

        public void SaveSettings()
        {
            var redHex = AppPrimaryColorRedChannel.ToString("X2");
            var greenHex = AppPrimaryColorGreenChannel.ToString("X2");
            var blueHex = AppPrimaryColorBlueChannel.ToString("X2");
            var colorStringHex = "#" + redHex + greenHex + blueHex;

            var newAppColors = App.Settings.AppColors.CloneJson();
            newAppColors.PrimaryColor = colorStringHex;

            App.Settings.AppColors = newAppColors;
        }
    }
}
