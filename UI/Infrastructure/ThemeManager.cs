using System;
using System.Drawing;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UI.Infrastructure
{
    public enum ThemeMode
    {
        Light,
        Dark
    }

    public class ThemeManager
    {
        private static ThemeManager? _instance;
        private static readonly object _lock = new object();
        
        private ThemeMode _currentTheme;
        private MaterialSkinManager? _skinManager;

        public event EventHandler<ThemeChangedEventArgs>? ThemeChanged;

        private ThemeManager()
        {
            _currentTheme = ThemeMode.Light; // Default to light theme
        }

        public static ThemeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ThemeManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetTheme(ThemeMode mode)
        {
            if (_currentTheme != mode)
            {
                _currentTheme = mode;
                ThemeChanged?.Invoke(this, new ThemeChangedEventArgs(mode));
            }
        }

        public void ApplyTheme(MaterialSkinManager skinManager)
        {
            _skinManager = skinManager;
            
            if (_currentTheme == ThemeMode.Light)
            {
                ApplyLightTheme(skinManager);
            }
            else
            {
                ApplyDarkTheme(skinManager);
            }
        }

        private void ApplyLightTheme(MaterialSkinManager skinManager)
        {
            // Blue/Professional Light Theme
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue700,      // Primary color
                Primary.Blue800,      // Primary color dark
                Primary.Blue500,      // Primary color light
                Accent.Blue400,       // Accent color
                TextShade.WHITE       // Text shade
            );

            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void ApplyDarkTheme(MaterialSkinManager skinManager)
        {
            // Dark Theme with Cyan Accent
            skinManager.ColorScheme = new ColorScheme(
                Primary.Blue900,      // Primary color (dark blue)
                Primary.Blue800,     // Primary color dark
                Primary.Blue700,     // Primary color light
                Accent.Cyan400,      // Accent color (cyan)
                TextShade.WHITE      // Text shade
            );

            skinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        public ThemeMode GetCurrentTheme()
        {
            return _currentTheme;
        }

        public bool IsDarkMode => _currentTheme == ThemeMode.Dark;

        public void ToggleTheme()
        {
            SetTheme(_currentTheme == ThemeMode.Light ? ThemeMode.Dark : ThemeMode.Light);
        }

        public Color GetPrimaryColor()
        {
            return _currentTheme == ThemeMode.Light ? Color.FromArgb(25, 118, 210) : Color.FromArgb(13, 71, 161);
        }

        public Color GetAccentColor()
        {
            return _currentTheme == ThemeMode.Light ? Color.FromArgb(33, 150, 243) : Color.FromArgb(0, 188, 212);
        }

        public Color GetBackgroundColor()
        {
            return _currentTheme == ThemeMode.Light ? Color.FromArgb(255, 255, 255) : Color.FromArgb(30, 30, 30);
        }

        public Color GetTextColor()
        {
            return _currentTheme == ThemeMode.Light ? Color.FromArgb(0, 0, 0) : Color.FromArgb(255, 255, 255);
        }
    }

    public class ThemeChangedEventArgs : EventArgs
    {
        public ThemeMode Theme { get; }

        public ThemeChangedEventArgs(ThemeMode theme)
        {
            Theme = theme;
        }
    }
}
