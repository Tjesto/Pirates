using Pirates.GameObjects;
using Pirates.GameObjects.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates.Rendering
{
    internal class OnReturnToPortClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window;

        public OnReturnToPortClicked(Pirates.Windows.MainWindow window)
        {
            this.window = window;
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            window.nextMode = GameEngineRenderer.GameEngineRendererMode.PORT;
            return true;
        }
    }

    internal class OnSellClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window;
        Pirates.GameObjects.Product product;
        PlayersInfo player;

        public OnSellClicked(Pirates.Windows.MainWindow window, Pirates.GameObjects.Product product, PlayersInfo player)           
        {
            this.window = window;
            this.product = product;
            this.player = player;
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            WorldInfo.getInfo().getProductAmount(product);
            int notSold = player.playersShip.removeProducts(product, MarketRenderingMap.STANDARD_TRANSACTION_AMOUNT);
            player.money += WorldInfo.getInfo().getPriceOf(product) * (MarketRenderingMap.STANDARD_TRANSACTION_AMOUNT - notSold);
            return true;
        }
    }

    internal class OnBuyClicked : Component.OnClickListener
    {
        Pirates.Windows.MainWindow window;
        Pirates.GameObjects.Product product;
        PlayersInfo player;        

        public OnBuyClicked(Pirates.Windows.MainWindow window, Pirates.GameObjects.Product product, PlayersInfo player)
        {
            this.window = window;
            this.product = product;
            this.player = player;
        }
        public bool onClick(System.Windows.Forms.MouseEventArgs e)
        {
            WorldInfo.getInfo().getProductAmount(product);
            int notSold = player.playersShip.addProducts(product, MarketRenderingMap.STANDARD_TRANSACTION_AMOUNT);
            player.money -= WorldInfo.getInfo().getPriceOf(product) * (MarketRenderingMap.STANDARD_TRANSACTION_AMOUNT - notSold);
            return true;
        }
    }

    class MarketRenderingMap : AbstractRenderingMap
    {
        public static int STANDARD_TRANSACTION_AMOUNT = 25;
        public MarketRenderingMap(Pirates.Windows.MainWindow window, PlayersInfo player)
            : base(window)
        {
            window.DialogResult = System.Windows.Forms.DialogResult.None;
            MapButton back = new MapButton(100, 600, 125, 50, "Powrót do portu");
            back.setOnClickListener(new OnReturnToPortClicked(window));
            addComponent(back);
            int y = 25;
            foreach (Product p in WorldInfo.getInfo().getProducts()) {

                TextView tv = new TextView(40, y, 60, 25, "Sprzedaj " + player.playersShip.getAmount(p));
                ImageButton sell = new ImageButton(100, y, Properties.Resources.button_sell);
                sell.setOnClickListener(new OnSellClicked(window, p, player));
                addComponent(sell);
                addComponent(tv);

                tv = new TextView(240, y, 60, 25, "Kup " + p.name + " za " + p.price);
                ImageButton buy = new ImageButton(200, y, Properties.Resources.button_buy);
                buy.setOnClickListener(new OnBuyClicked(window, p, player));
                addComponent(buy);
                addComponent(tv);
                y += 100;
            }
        }

        public override void draw(System.Drawing.Graphics g)
        {
            //g.DrawImage(Properties.Resources.Port_bg, ((ViewPortHelper.getInstance().right - Properties.Resources.Port_bg.Width) / 2 + ViewPortHelper.getInstance().left), ((ViewPortHelper.getInstance().bottom - Properties.Resources.Port_bg.Height) /2) + ViewPortHelper.getInstance().top);
            g.DrawImage(Properties.Resources.Port_bg, 0, 0);
            foreach (Component c in components)
            {
                c.draw(g);
            }
        }

        public static AbstractRenderingMap getInstance(Pirates.Windows.MainWindow window, PlayersInfo player)        
        {
            if (instance != null && !(instance is MarketRenderingMap))
            {
                instance.cleanUp();
                instance = null;
            }
            if (instance == null)
            {
                instance = new MarketRenderingMap(window, player);
            }
            return instance;
        }
    }
}
