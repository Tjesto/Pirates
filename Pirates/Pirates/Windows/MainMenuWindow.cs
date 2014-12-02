using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pirates.Rendering;

namespace Pirates.Windows
{
    public partial class MainMenuWindow : Form
    {
        internal class ButtonClickHandler : MenuHandler.OnMenuItemClickedListener
        {
            private MainMenuWindow window;

            public ButtonClickHandler(MainMenuWindow window)
            {
                this.window = window;
            }

            public void showSettings()
            {
                window.onSettingsClick();
            }

            public void notifyButtonClicked()
            {
                window.startOption();                
            }

            public void exitClicked()
            {
                window.Close();
            }
        }

        private MenuHandler menuHandler;

        private SettingsScreen settingsScreen;

        public MainMenuWindow()
        {
            InitializeComponent();
            settingsPanel.Visible = false;
            menuHandler = new MenuHandler(MainMenuPanel, 
                new MainMenuButtonContainer(newGameButtonMM, loadGameButtonMM, settingsButton, exitButton));

            menuHandler.listener = new ButtonClickHandler(this);

            settingsScreen = new SettingsScreen(
                new UserPreferncesUI(saveButtonSettings, defaultSettingsButton, abortButton,steerRightP, steerLeftP, steerRightKey, steeerLeftKey));
        }

        internal void startOption()
        {
            this.Hide();
            menuHandler.selectedForm.Show(this);
        }

        internal void onSettingsClick()
        {            
            settingsPanel.Visible = true;
        }

        private void MainMenuWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (settingsScreen.onKeyDown(sender, e))
            {
                return;
            }

            //empty, implement this if you need
        }

        private void settingsPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (settingsScreen.onKeyDown(sender, e))
            {
                return;
            }
        }

    }
}
