using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.Rendering
{
    partial class OnBackClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window;

        public OnBackClicked(Pirates.Windows.MainWindow window)
        {
            this.window = window;
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            window.nextMode = GameEngineRenderer.GameEngineRendererMode.SEA;
            return true;
        }
    }

    partial class OnDockClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window;

        public OnDockClicked(Pirates.Windows.MainWindow window)
        {
            this.window = window;
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            window.nextMode = GameEngineRenderer.GameEngineRendererMode.DOCK;
            return true;
        }
    }

    class PortRenderingMap : AbstractRenderingMap
    {
        public PortRenderingMap(Pirates.Windows.MainWindow window) : base(window) 
        {
            window.DialogResult = System.Windows.Forms.DialogResult.None;
            MapButton back = new MapButton(100, 600, 125, 50, "Powrót na morze");
            back.setOnClickListener(new OnBackClicked(window));
            addComponent(back);
            MapButton dock = new MapButton(100, 450, 125, 50, "Odwiedź stocznię");
            dock.setOnClickListener(new OnDockClicked(window));
            addComponent(dock);
        }

        public override void draw(System.Drawing.Graphics g)
        {
            //g.DrawImage(Properties.Resources.Port_bg, ((ViewPortHelper.getInstance().right - Properties.Resources.Port_bg.Width) / 2 + ViewPortHelper.getInstance().left), ((ViewPortHelper.getInstance().bottom - Properties.Resources.Port_bg.Height) /2) + ViewPortHelper.getInstance().top);
            g.DrawImage(Properties.Resources.Port_bg, 0,0);
            foreach (Component c in components) 
            {
                c.draw(g);
            }
        }

        public static AbstractRenderingMap getInstance(Pirates.Windows.MainWindow window)
        {
            if (instance != null && !(instance is PortRenderingMap))
            {
                instance.cleanUp();
                instance = null;
            }
            if (instance == null)
            {
                instance = new PortRenderingMap(window);
            }
            return instance;
        }
    }
}
