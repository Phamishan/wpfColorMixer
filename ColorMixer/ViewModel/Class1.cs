using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace ColorMixer.ViewModel
{
    public partial class ColorMixerViewModel : ObservableObject
    {
        public ColorMixerViewModel()
        {
            PropertyChanged += ColorMixerViewModel_PropertyChanged;
        }

        private void ColorMixerViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(RedSlider):
                case nameof(GreenSlider):
                case nameof(BlueSlider):
                    ChangeColor();
                    break;
            }
        }

        [ObservableProperty]
        private int redSlider;

        [ObservableProperty]
        private int greenSlider;

        [ObservableProperty]
        private int blueSlider;

        [ObservableProperty]
        private Canvas rectangle;

        [ObservableProperty]
        private string hexCode;

        [ObservableProperty]
        private string hexCodeInput = "000000";

        public void ChangeColor()
        {
            var redColor = RedSlider.ToString("x2");

            var greenColor = GreenSlider.ToString("x2");

            var blueColor = BlueSlider.ToString("x2");

            HexCode = "#" + redColor + greenColor + blueColor;
        }

        [RelayCommand(CanExecute = nameof(IsValidHex))]
        private void ChangeColorHex()
        {
            HexCode = "#" + HexCodeInput;
        }

        private bool IsValidHex()
        {
            var rx = new Regex(@"[a-fA-F0-9]{6}");

            return rx.IsMatch(HexCodeInput);
        }
    }
}

