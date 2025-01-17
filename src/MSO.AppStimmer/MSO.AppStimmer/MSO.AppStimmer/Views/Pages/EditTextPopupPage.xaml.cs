﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Services;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTextPopupPage : PopupPage
    {
        private ISoftwareKeyboardService keyboardService;

        public EditTextPopupPage(EditAppStimmerTextViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;

            this.keyboardService = App.KeyboardService;
            keyboardService.Hide += KeyboardServiceOnHide;
            keyboardService.Show += KeyboardServiceOnShow;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.TextEditor.Focus();
        }

        private async void KeyboardServiceOnShow(object sender, SoftwareKeyboardEventArgs args)
        {
            if (!this.ViewModel.FinishedEdit)
                await this.MainFrame.TranslateTo(0, -150, 250U, Easing.Linear);           
        }

        private async void KeyboardServiceOnHide(object sender, SoftwareKeyboardEventArgs args)
        {
            if (!this.ViewModel.FinishedEdit)
                await this.MainFrame.TranslateTo(0, 0, 250U, Easing.Linear);
        }

        public EditAppStimmerTextViewModel ViewModel => this.BindingContext as EditAppStimmerTextViewModel;

        protected override bool OnBackgroundClicked()
        {
            base.OnBackgroundClicked();

            if (this.CloseWhenBackgroundIsClicked)
                PopupNavigation.PopAsync(true);

            return this.CloseWhenBackgroundIsClicked;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            this.ViewModel.FinishedEdit = true;
            await PopupNavigation.PopAsync(true);
        }

        //protected override Task OnAppearingAnimationEnd()
        //{
        //    return Content.FadeTo(0.5);
        //}

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected override Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1);
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // Close Popup when a user clicks the transparent background
            await PopupNavigation.PopAsync(true);
        }

        private void FrameGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            // ignore. This method is there just to prevent the view from closing when a user clicks the frame instead of the transparent page background.
        }
    }
}