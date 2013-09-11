using ShortcutThemes.Helpers;
using PluginCore;
using ShortcutThemes.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PluginCore.Utilities;
using System.Collections;

namespace ShortcutThemes.Controls
{
    public partial class ShortcutThemeDialog : Form, IComparer
    {
        Settings _settings;
        ShortcutHelper _helper;
        string _browse = string.Empty;
        string _flashDevelop = "FlashDevelop";
        string _visualStudio = "Visual Studio";
        string _saveWarningMessage = string.Empty;
        string _invalidFileMessage = string.Empty;

        public ShortcutThemeDialog(Settings settings)
        {
            _settings = settings;
            _helper = new ShortcutHelper();

            InitializeComponent();
            InitializeLabels();
            InitializeThemes();

            themes.ListViewItemSorter = this;
        }

        private void InitializeLabels()
        {
            this.Text = ResourceHelper.GetString("ShortcutThemes.Title.ShortcutThemes");
            this.themesLabel.Text = ResourceHelper.GetString("ShortcutThemes.Label.Themes");
            this.apply.Text = ResourceHelper.GetString("ShortcutThemes.Label.Apply");
            this.save.Text = ResourceHelper.GetString("ShortcutThemes.Label.Save");
            this.close.Text = ResourceHelper.GetString("ShortcutThemes.Label.Close");

            _browse = ResourceHelper.GetString("ShortcutThemes.Label.Browse");
            _saveWarningMessage = ResourceHelper.GetString("ShortcutThemes.Message.SaveWarning");
            _invalidFileMessage = ResourceHelper.GetString("ShortcutThemes.Message.InvalidFile");
        }

        public void InitializeThemes()
        {
            themes.Items.Add(_browse);
            themes.Items.Add(_flashDevelop);
            themes.Items.Add(_visualStudio);

            for (int index = _settings.CustomThemes.Count - 1; index >= 0; index--)
            {
                var filename = _settings.CustomThemes[index];
                if (File.Exists(filename))
                    AddCustomTheme(filename);
                else
                    _settings.CustomThemes.RemoveAt(index);
            }
            themes_ClientSizeChanged(null, null);
        }

        public void AddCustomTheme(string filename)
        {
            if (!_settings.CustomThemes.Contains(openFile.FileName))
                _settings.CustomThemes.Add(openFile.FileName);

            var name = GetThemeName(filename);
            var item = new ListViewItem(name);
            item.Tag = filename;
            themes.Items.Add(item);
            themes.Sort();
        }

        private string GetThemeName(string filename)
        {
            return Path.GetFileNameWithoutExtension(filename);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _helper.SaveShortcuts(saveFile.FileName);
                    AddCustomTheme(saveFile.FileName);
                }
                catch (Exception)
                {

                }
            }
        }

        private void apply_Click(object sender, EventArgs e)
        {
            var selectedTheme = themes.SelectedItems[0];
            selectedTheme.Selected = false;

            if (_settings.ShowSaveWarning)
            {
                if (MessageBox.Show(_saveWarningMessage, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }

            if (selectedTheme.Text == _browse &&
                openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _helper.LoadShortcuts(openFile.FileName);

                    if (!_settings.CustomThemes.Contains(openFile.FileName))
                        AddCustomTheme(openFile.FileName);
                }
                catch (Exception)
                {
                    MessageBox.Show(_invalidFileMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (selectedTheme.Text == _flashDevelop)
            {
                _helper.ApplyDefault();
            }
            else if (selectedTheme.Text == _visualStudio)
            {
                using (var theme = ResourceHelper.GetFileStream(_visualStudio + ".keys"))
                {
                    _helper.LoadShortcuts(theme);
                }
            }
            else
            {
                var filename = (string)selectedTheme.Tag;
                try
                {
                    _helper.LoadShortcuts(filename);
                }
                catch (Exception)
                {
                    _settings.CustomThemes.Remove(filename);
                    themes.Items.Remove(selectedTheme);

                    MessageBox.Show(_invalidFileMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _helper.ApplyAllShortcuts();
        }

        private void themes_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            apply.Enabled = themes.SelectedItems.Count > 0;
        }

        private void themes_ClientSizeChanged(object sender, EventArgs e)
        {
            themesHeader.Width = themes.ClientSize.Width - 4;
        }

        public int Compare(object item1, object item2)
        {
            var name1 = ((ListViewItem)item1).Text;
            var name2 = ((ListViewItem)item2).Text;

            if (name1 == _browse)
                return -1;
            if (name2 == _browse)
                return 1;

            return string.Compare(name1, name2);
        }
    }
}
