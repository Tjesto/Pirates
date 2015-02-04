using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pirates.GameObjects
{
    class OrbisonTreasureQuest : TreasureQuest
    {
        public OrbisonTreasureQuest()
        {
            gold = WorldInfo.getInfo().r.Next(10,45);
            food = WorldInfo.getInfo().r.Next(100, 450);
            MessageBox.Show("Dostajesz " + gold + " szutk złota i " + food + " jednostek jedzenia", "", MessageBoxButtons.OK);
            Players.PlayersInfo.info.food += food;
            Players.PlayersInfo.info.money += gold;
        }

    }
}
