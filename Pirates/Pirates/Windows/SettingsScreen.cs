using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Pirates.Windows
{
    class UserPreferncesUI
    {
        internal Button save;
        internal Button defautls;
        internal Button abort;
        internal Panel steerRight;
        internal Panel steerLeft;
        internal TextBox steerRightKey;
        internal TextBox steerLeftKey;

        public UserPreferncesUI(Button save, Button defautls, Button abort,
            Panel steerRight, Panel steerLeft, TextBox steerRightKey, TextBox steerLeftKey)
        {
            this.save = save;
            this.defautls = defautls;
            this.abort = abort;
            this.steerLeft = steerLeft;
            this.steerLeftKey = steerLeftKey;
            this.steerRight = steerRight;
            this.steerRightKey = steerRightKey;
        }
    }

    class SettingsScreen
    {

        internal enum SteeringOption
        {
            RIGHT, LEFT, NONE, RIGHT_ALT, LEFT_ALT
        }

        private UserPreferncesUI ui;

        private SteeringOption steer;

        public SettingsScreen(UserPreferncesUI settings)
        {
            ui = settings;
            init();
        }

        private void init()
        {
            ui.abort.Click += new System.EventHandler(onAbortClick);
            ui.defautls.Click += new System.EventHandler(onDefaultsClick);
            ui.save.Click += new System.EventHandler(onSaveClick);
            ui.steerLeft.Click += new System.EventHandler(onSteeringLeftClick);
            ui.steerLeft.DoubleClick += new System.EventHandler(onSteeringLeftDoubleClick);
            ui.steerRight.Click += new System.EventHandler(onSteeringRightClick);
            ui.steerRight.DoubleClick += new System.EventHandler(onSteeringRightDoubleClick);
            ui.steerLeftKey.Click += new System.EventHandler(onSteeringLeftClick);
            ui.steerLeftKey.DoubleClick += new System.EventHandler(onSteeringLeftDoubleClick);
            ui.steerRightKey.Click += new System.EventHandler(onSteeringRightClick);
            ui.steerRightKey.DoubleClick += new System.EventHandler(onSteeringRightDoubleClick);
        }

        private void onSteeringRightClick(object sender, EventArgs e)
        {
            String current = ui.steerRightKey.Text;
            ui.steerRightKey.Text = setWaitingText(current);
            steer = SteeringOption.RIGHT;
        }

        private void onSteeringRightDoubleClick(object sender, EventArgs e)
        {
            String current = ui.steerRightKey.Text;
            ui.steerRightKey.Text = setAltWaitingText(current);
            steer = SteeringOption.RIGHT_ALT;
        }

        private void onSteeringLeftDoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onSteeringLeftClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onSaveClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onDefaultsClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void onAbortClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private string setWaitingText(string current)
        {
            string[] keys = current.Split(new String[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
            if (keys.Length == 2)
            {
                return "...; " + keys[1];
            }
            return "...";
        }

        private string setAltWaitingText(string current)
        {
            string[] keys = current.Split(new String[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
            if (keys.Length > 0)
            {
                return keys[0] + "; ..." ;
            }
            return "...";
        }

        internal bool onKeyDown(object sender, EventArgs e)
        {
            if (steer == SteeringOption.NONE)
            {
                return false;
            }
            String current;
            switch (steer)
            {
                case SteeringOption.LEFT:
                    current = ui.steerLeftKey.Text;
                    ui.steerLeftKey.Text = setKeys(current, e);
                    break;

                case SteeringOption.RIGHT:
                    current = ui.steerRightKey.Text;
                    ui.steerRightKey.Text = setKeys(current, e);
                    break;

                case SteeringOption.LEFT_ALT:
                    current = ui.steerLeftKey.Text;
                    ui.steerLeftKey.Text = setKeys(current, e);
                    break;

                case SteeringOption.RIGHT_ALT:
                    current = ui.steerRightKey.Text;
                    ui.steerRightKey.Text = setKeys(current, e);
                    break;
                    
            }

            steer = SteeringOption.NONE;
            
            return true;
        }

        private string setKeys(string current, EventArgs e)
        {
            int key = 0;
            if (e is KeyEventArgs)
            {
                key = ((KeyEventArgs) e).KeyValue;
            }
            else if (e is PreviewKeyDownEventArgs)
            {
                key = ((PreviewKeyDownEventArgs)e).KeyValue;
            }
            else
            {
                throw new ArgumentException("EventArgs must be instance of KeyEventArgs or PreviewKeyDownEventArgs");
            }
            return current.Replace("...", Convert.ToChar(key).ToString());
        }

    }
}
