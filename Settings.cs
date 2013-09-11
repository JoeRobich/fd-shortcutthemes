using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using ShortcutThemes.Localization;

namespace ShortcutThemes
{
    public delegate void SettingsChangesEvent();

    [Serializable]
    public class Settings
    {
        [field: NonSerialized]
        public event SettingsChangesEvent OnSettingsChanged;

        private const bool DEFAULT_SHOW_SAVE_WARNING = true;
        private bool _showSaveWarning = DEFAULT_SHOW_SAVE_WARNING;

        public Settings()
        {
            CustomThemes = new List<string>();
        }

        [LocalizedCategory("ShortcutThemes.Category.Visibility")]
        [LocalizedDisplayName("ShortcutThemes.Label.ShowSaveWarning")]
        [LocalizedDescription("ShortcutThemes.Description.ShowSaveWarning")]
        [DefaultValue(DEFAULT_SHOW_SAVE_WARNING)]
        public bool ShowSaveWarning
        {
            get { return _showSaveWarning; }
            set
            {
                if (_showSaveWarning != value)
                {
                    _showSaveWarning = value;
                    FireChanged();
                }
            }
        }

        [Browsable(false)]
        public List<string> CustomThemes { get; set; }

        private void FireChanged()
        {
            if (OnSettingsChanged != null) OnSettingsChanged();
        }
    }
}
