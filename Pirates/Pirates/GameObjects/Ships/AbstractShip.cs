using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using Pirates.GameObjects.Map;
using Pirates.Rendering;
using System.Threading.Tasks;

namespace Pirates.GameObjects.Ships
{
    class AbstractShip : Ship
    {
        protected int level = 15;
        protected string type;
        protected int cannonsCount;
        protected int crewCount;
        protected int MAX_CREW;
        public float TURN_VALUE { set; get; }
        protected Location location;
        protected Bitmap texture;
        public float azimuth { set; get; }

        public void changeLocationToCenter()
        {
            texture.RotateFlip(RotateFlipType.Rotate90FlipX);
            float centerX = ViewPortHelper.getInstance().right/2;
            float centerY = ViewPortHelper.getInstance().bottom/2;
            float shipWidthP2 = texture.Size.Width/2;
            float shipHeightP2 = texture.Size.Height/2;
            location = new Location(centerX - shipWidthP2, centerY - shipHeightP2, centerX + shipWidthP2, centerY + shipHeightP2);
            azimuth = 0;
        }

        public void refresh()
        {

        }
        public void move(int x, int y)
        {

        }
        public bool isCollisionWith(Ship ship)
        {
            return false;
        }

        public void draw(Graphics g)
        {            
            float halfWidth = texture.Size.Width / 2;
            float halfHeight = texture.Size.Height / 2;
            g.TranslateTransform(ViewPortHelper.getInstance().right/2, (ViewPortHelper.getInstance().bottom + halfHeight)/2);
            g.RotateTransform(azimuth);
            g.TranslateTransform(-ViewPortHelper.getInstance().right/2, -((ViewPortHelper.getInstance().bottom + halfHeight)/2));
            g.TranslateTransform(location.left, location.top);
            g.DrawImage(texture, 0,0);
            g.TranslateTransform(-location.left, -location.top);
        }
        public void refreshVisibilityTowards(Ship ship)
        {

        }
        public int getLevel()
        {
            return level;
        }
        public Location getLocation()
        {
            return location;
        }
    }
}
