using FlashDevelop.Managers;
using PluginCore;
using PluginCore.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ShortcutThemes.Helpers
{
    class ShortcutHelper : ReflectedStaticClass
    {
        const string TypeName = "FlashDevelop.Managers.ShortcutManager, FlashDevelop";

        public ShortcutHelper()
            : base(TypeName)
        {
        }

        public List<ShortcutItem> RegisteredItems
        {
            get
            {
                return GetFieldValue("RegistedItems") as List<ShortcutItem>;
            }
        }

        /// <summary>
        /// Gets the specified registered shortcut item
        /// </summary>
        public ShortcutItem GetRegisteredItem(string id)
        {
            return InvokeMethod("GetRegisteredItem", new Type[] { typeof(string) }, new object[] { id }) as ShortcutItem;
        }

        /// <summary>
        /// Applies all shortcuts to the items
        /// </summary>
        public void ApplyAllShortcuts()
        {
            InvokeMethod("ApplyAllShortcuts");
        }

        /// <summary>
        /// Resets all shortcuts to their default.
        /// </summary>
        public void ApplyDefault()
        {
            foreach (var item in RegisteredItems)
                item.Custom = item.Default;
        }

        /// <summary>
        /// Clears all shortcuts.
        /// </summary>
        public void ClearShortcuts()
        {
            foreach (var item in RegisteredItems)
                item.Custom = Keys.None;
        }

        /// <summary>
        /// Loads the shortcuts from a stream
        /// </summary>
        public void LoadShortcuts(Stream input)
        {
            var tempFilename = Path.GetTempFileName();

            using (var output = File.OpenWrite(tempFilename))
            {
                byte[] buffer = new byte[8 * 1024];
                int len;
                while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, len);
                }
            }

            LoadShortcuts(tempFilename);
        }

        /// <summary>
        /// Loads the shortcuts from a file
        /// </summary>
        public void LoadShortcuts(string file)
        {
            if (File.Exists(file))
            {
                List<Argument> shortcuts = new List<Argument>();
                shortcuts = (List<Argument>)ObjectSerializer.Deserialize(file, shortcuts, false);
                ClearShortcuts();
                foreach (Argument arg in shortcuts)
                {
                    ShortcutItem item = GetRegisteredItem(arg.Key);
                    if (item != null) item.Custom = (Keys)Enum.Parse(typeof(Keys), arg.Value);
                }
            }
        }

        /// <summary>
        /// Saves the shorcuts to a file
        /// </summary>
        public void SaveShortcuts(string file)
        {
            List<Argument> shortcuts = new List<Argument>();
            foreach (ShortcutItem item in RegisteredItems)
            {
                if (item.Custom != Keys.None)
                {
                    shortcuts.Add(new Argument(item.Id, item.Custom.ToString()));
                }
            }
            ObjectSerializer.Serialize(file, shortcuts);
        }
    }
}
