using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pirates.GameObjects;
using Pirates.Windows;

namespace Pirates.Rendering
{    
    abstract class Component : MainWindow.PlayerInputListener
    {
        public interface OnClickListener
        {
            bool onClick(MouseEventArgs e);
        }

        protected Location location;

        protected Color background = Color.Transparent;
        protected Color focused = Color.White;
        protected Color highlighted = Color.Black;
        protected Color normal = Color.Transparent;
        protected Color text = Color.Chocolate;

        protected OnClickListener listener;

        public Component(float x, float y, float width, float height)
        {
            this.location = new Location(x, y, x + width, y + height);
        }

        public abstract void draw(Graphics g);

        public void setOnClickListener(OnClickListener listener) 
        {
            this.listener = listener;
        }

        public bool onClickAction(MouseEventArgs e) 
        {
            return performOnClick(e);
        }

        public bool onMouseMove(MouseEventArgs e)
        {
            if (location.containsPoint(e.X, e.Y))
            {
                background = focused;
                return true;
            }
            else
            {
                background = normal;
                return false;
            }
        }        

        private bool performOnClick(MouseEventArgs e)
        {
            if (location.containsPoint(e.X, e.Y))
            {
                background = highlighted;
                new Thread(new ThreadStart(changeColor)).Start();
                return listener.onClick(e);
            }
            
            return false;
        }

        private void changeColor()
        {
            Thread.Sleep(25);
            if (background == highlighted)
            {
                background = normal;
            }
        }
    }

    class MapButton : Component
    {
        public String label { set; get; }
        private float width;
        private float height;

        public MapButton(float x, float y, float width, float height, String label) : base(x, y, width, height) 
        {
            this.label = label;
        }

        public override void draw(Graphics g)
        {
            g.DrawRectangle(new Pen(background), location.left, location.top, width, height);
            g.DrawString(label, new Font("Arial", Utils.dpToPx(16)), Brushes.Chocolate, location.left + Utils.dpToPx(10), location.top + (location.bottom - location.top + Utils.dpToPx(16)) / 2);
        }
    }

    abstract class AbstractRenderingMap : ICleanupable
    {

        protected static AbstractRenderingMap instance;
        protected List<Component> components = new List<Component>();
        private MainWindow window;

        public static AbstractRenderingMap getInstance(MainWindow window)
        {
            return instance;
        }

        public AbstractRenderingMap(MainWindow window)
        {
            this.window = window;
        }

        protected void addComponent(Component c) 
        {
            components.Add(c);
            window.registerListener(c);
        }

        public abstract void draw(Graphics g);

        public void cleanUp()
        {
            foreach (MainWindow.PlayerInputListener listener in components)
            {
                window.unregisterListener(listener);
            }
            components.Clear();
        }
    }
}
