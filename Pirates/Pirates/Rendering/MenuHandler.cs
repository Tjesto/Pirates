using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using Pirates.Windows;

namespace Pirates.Rendering
{
    public class MainMenuButtonContainer
    {
        public Button newGame { set; get; }

        public Button loadGame { set; get; }

        public Button settings { set; get; }

        public Button exit { set; get; }

        public MainMenuButtonContainer(Button newGame, Button loadGame, Button settings, Button exit)
        {
            this.newGame = newGame;
            this.loadGame = loadGame;
            this.settings = settings;
            this.exit = exit;
        }
    }

    class MenuHandler
    {
        public interface OnMenuItemClickedListener 
        {
            void notifyButtonClicked();
            void showSettings();
            void exitClicked();
        }

        private Panel menuPanel;

        private MainMenuButtonContainer buttons;

        public OnMenuItemClickedListener listener { set; get; }

        private Form formToRun;

        public Form selectedForm { get { return formToRun; } }

        public MenuHandler(Panel menuPanel, MainMenuButtonContainer buttons)
        {
            this.menuPanel = menuPanel;
            this.buttons = buttons;
            initMenuPanel();            
        }

        private void initMenuPanel()
        {
            MapUtils.ARGBColor color =  MapUtils.BackgroundARGBColor;
            menuPanel.BackColor = Color.FromArgb(color.Alpha, color.Red, color.Green, color.Blue);
            buttons.newGame.Click += new System.EventHandler(this.onNewGameClick);
            buttons.loadGame.Click += new System.EventHandler(this.onLoadGameClick);
            buttons.settings.Click += new System.EventHandler(this.onSettingsClick);
            buttons.exit.Click += new System.EventHandler(this.onExitClick);
        }

        /**
         * Method run in every button click
         * Important to call at the end of the method stub
         */
        private void onButtonClicked()
        {            
            if (listener != null)
            {
                listener.notifyButtonClicked();
            }
        }

        private void onNewGameClick(object sender, EventArgs e)
        {
            formToRun = new MainWindow();
            onButtonClicked();            
        }

        private void onLoadGameClick(object sender, EventArgs e)
        {
            //onButtonClicked();
            //TODO do something
        }

        private void onSettingsClick(object sender, EventArgs e)
        {
            listener.showSettings();
        }

        private void onExitClick(object sender, EventArgs e)
        {
            if (listener != null)
            {
                listener.exitClicked();
            }
        }

    }
}
