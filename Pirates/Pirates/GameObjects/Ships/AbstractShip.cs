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
        public int MAX_DAMAGE_LEVEL = 500;
        protected int level = 15;
        protected string type;
        protected int cannonsCount;
        protected int crewCount;
        protected int MAX_CREW;
        public float TURN_VALUE { set; get; }
        protected Location location;
        protected Location rotatedLocation;
        protected Bitmap texture;
        protected Storage shipStorage;
        private float _azimuth;
        public float azimuth { set { _azimuth = value; refreshRotatedLocation(); } get { return _azimuth; } }

        public AbstractShip()
        {
            shipStorage = new Storage(5000);
        }

        private void refreshRotatedLocation()
        {
            double angle = Utils.DegreeToRadian(_azimuth);
            float middleX = location.left + (Math.Abs(location.right - location.left)) / 2;
            float middleY = location.top + (Math.Abs(location.bottom - location.top)) / 2;
            float newLeft = (float) Math.Round(middleX + (location.left - middleX) * Math.Cos(angle) - (location.top - middleY) * Math.Sin(angle));
            float newRight = (float) Math.Round(middleX + (location.right - middleX) * Math.Cos(angle) - (location.top - middleY) * Math.Sin(angle));
            float newTop = (float) Math.Round(middleY + (location.left - middleX) * Math.Sin(angle) + (location.top - middleY) * Math.Cos(angle));
            float newBottom = (float) Math.Round(middleY + (location.right - middleX) * Math.Sin(angle) + (location.bottom - middleY) * Math.Cos(angle));            
 	        rotatedLocation = new Location(newLeft, newTop, newRight, newBottom);
        }

        protected void init() 
        {
            rotatedLocation = location;
        }

        public void changeLocationToCenter()
        {
            texture.RotateFlip(RotateFlipType.Rotate90FlipX);
            float centerX = ViewPortHelper.getInstance().right/2;
            float centerY = ViewPortHelper.getInstance().bottom/2;
            float shipWidthP2 = texture.Size.Width/2;
            float shipHeightP2 = texture.Size.Height/2;
            location = new Location(centerX - shipWidthP2, centerY - shipHeightP2, centerX + shipWidthP2, centerY + shipHeightP2);
            azimuth = 0;
            init();
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
            /*Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString((rotatedLocation.left + "x" + rotatedLocation.top), drawFont, drawBrush, 0,0);*/
            g.TranslateTransform(-location.left, -location.top);            
            g.TranslateTransform(ViewPortHelper.getInstance().right / 2, (ViewPortHelper.getInstance().bottom + halfHeight) / 2);
            g.RotateTransform(-azimuth);
            g.TranslateTransform(-ViewPortHelper.getInstance().right / 2, -((ViewPortHelper.getInstance().bottom + halfHeight) / 2));            
        }
        public void refreshVisibilityTowards(float[] move)
        {

        }
        public int getLevel()
        {
            return level;
        }
        public Location getLocation()
        {
            return rotatedLocation;
        }

        public int addProducts(Product product, int count)
        {
            return shipStorage.addProducts(product, count);
        }

        public int removeProducts(Product product, int count)
        {
            return shipStorage.removeProducts(product, count);
        }

        public double velocity { get; set; }

        public int damages { get; set; }

        internal int getAmount(Product p)
        {
            return shipStorage.getAmount(p);
        }
    }
}
