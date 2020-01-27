using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Tray_Application
{
    public class SysTrayApp : ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        Hotkeys hotkeys = new Hotkeys();

        public SysTrayApp()
        {
            MenuItem configMenuItem = new MenuItem("Exit", Exit);

            notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem });
            notifyIcon.Click += Exit;
            notifyIcon.Visible = true;

            Hotkey exitApplication = new Hotkey(new Action(Exit), Hotkeys.KeyModifier.Control, Keys.C);
            
            hotkeys.SetHotkey(exitApplication);
        }

        void Exit(object sender, EventArgs e)
        {
            Exit();
        }

        void Exit()
        {
            notifyIcon.Visible = false;
            hotkeys.UnsetHotkeys();
            Application.Exit();
        }
    }
}
