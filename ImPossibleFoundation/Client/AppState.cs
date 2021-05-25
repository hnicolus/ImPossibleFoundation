using System;
using MudBlazor;

namespace ImPossibleFoundation.Client
{
    public class AppState
    {
        private MudTheme currentTheme = new MudTheme();

        public MudTheme CurrentTheme
        {
            get => currentTheme;
            set
            {
                currentTheme = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}