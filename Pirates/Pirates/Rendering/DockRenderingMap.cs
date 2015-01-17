using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pirates.GameObjects.Players;

namespace Pirates.Rendering
{
    partial class OnBackToPortClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window;

        public OnBackToPortClicked(Pirates.Windows.MainWindow window)
        {
            this.window = window;            
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            window.nextMode = GameEngineRenderer.GameEngineRendererMode.PORT;
            return true;
        }
    }

    partial class OnRepairClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window; 
        PlayersInfo player;
        MapButton button;
        private string repairedLabel = "Statek bez uszkodzeń";
        

        public OnRepairClicked(Pirates.Windows.MainWindow window, PlayersInfo player, MapButton button)
        {
            this.window = window;
            this.player = player;
            this.button = button;
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            if (button.label.Equals(repairedLabel))
            {
                return true;
            }
            int money = player.money;
            int repairs = player.playersShip.damages;
            if (money < player.playersShip.damages * DockRenderingMap.DOCK_PRICE_FOR_REPAIR)
            {
                repairs = (int) (money / DockRenderingMap.DOCK_PRICE_FOR_REPAIR);
            }
            player.money -= (int) (repairs * DockRenderingMap.DOCK_PRICE_FOR_REPAIR);
            player.playersShip.damages -=  repairs;
            System.Windows.Forms.MessageBox.Show("Twój statek został naprawiony");
            button.label = player.playersShip.damages == 0 ? repairedLabel : "Napraw za " + player.playersShip.damages * DockRenderingMap.DOCK_PRICE_FOR_REPAIR; 
            return true;
        }
    }

    class DockRenderingMap : AbstractRenderingMap
    {
        public static float DOCK_PRICE_FOR_REPAIR = 0.2f;

        public DockRenderingMap(Pirates.Windows.MainWindow window, PlayersInfo player) : base(window) 
        {
            window.DialogResult = System.Windows.Forms.DialogResult.None;
            MapButton back = new MapButton(100, 600, 125, 50, "Wróć do portu");
            back.setOnClickListener(new OnBackToPortClicked(window));
            addComponent(back);
            MapButton dock = new MapButton(100, 450, 125, 50, player.playersShip.damages == 0 ? "Statek bez uszkodzeń" : "Napraw za " + player.playersShip.damages * DockRenderingMap.DOCK_PRICE_FOR_REPAIR);
            dock.setOnClickListener(new OnRepairClicked(window, player, dock));
            addComponent(dock);
        }

        public override void draw(System.Drawing.Graphics g)
        {
            //g.DrawImage(Properties.Resources.Port_bg, ((ViewPortHelper.getInstance().right - Properties.Resources.Port_bg.Width) / 2 + ViewPortHelper.getInstance().left), ((ViewPortHelper.getInstance().bottom - Properties.Resources.Port_bg.Height) /2) + ViewPortHelper.getInstance().top);
            g.DrawImage(Properties.Resources.Dock_bg, 0,0);
            foreach (Component c in components) 
            {
                c.draw(g);
            }
        }

        public static AbstractRenderingMap getInstance(Pirates.Windows.MainWindow window, PlayersInfo player)
        {
            if (instance != null && !(instance is DockRenderingMap))
            {
                instance.cleanUp();
                instance = null;
            }
            if (instance == null)
            {
                instance = new DockRenderingMap(window, player);
            }
            return instance;
        }
    }
}
