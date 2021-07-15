using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using Oxide.Core;

namespace Oxide.Plugins
{
    [Info("Alerts", "Bob", 0.1)]
    [Description("Alerts")]

    class Alerts : RustPlugin
    {
        void OnServerInitialized(){
            char[] symbol = new char[4] ;

            bool checktimeday = false;
            bool checktimenight = false;

            rust.RunServerCommand("crafting.rate", 0);

             timer.Repeat(4f, 0, () =>
            {
                double hour = TOD_Sky.Instance.Cycle.Hour;
                double hours = hour;
                double hourss = hours;
                hour = Math.Floor(hour);
                hours = hours - hour;
                string result = hour.ToString();
                if(hour < 7 || hour > 21){
                    if(!checktimenight){
                        PrintToChat("Наступает ночь, добыча ресурсов увеличена до х3.");
                        rust.RunServerCommand("gather.rate", "dispenser", "*", 3);
                        rust.RunServerCommand("gather.rate", "quarry", "*", 3);
                        checktimenight = true;
                        checktimeday = false;
                    }
                }else{
                    if(!checktimeday){
                        PrintToChat("Наступает день, добыча ресурсов снижена до х2.");
                        rust.RunServerCommand("gather.rate", "dispenser", "*", 2);
                        rust.RunServerCommand("gather.rate", "quarry", "*", 2); 
                        checktimeday = true; 
                        checktimenight = false;
                    }
                }
            });
            timer.Repeat(3600f, 0, () =>
            {
                PrintToChat("Тяжело играть? Тогда заходи в наш магазин - igmserver.ru.");
            });
            timer.Repeat(7200, 0, () =>
            {
                PrintToChat("Следите за новостями сервера в нашей группе - vk.com/rustfans.");
            });
        }

        void OnPlayerRespawned(BasePlayer player)
        {
            Item item1 = ItemManager.CreateByName("shirt.tanktop", 1);    
            player.inventory.GiveItem(item1, player.inventory.containerWear);
            Item item3 = ItemManager.CreateByName("burlap.trousers", 1);
            player.inventory.GiveItem(item3, player.inventory.containerWear);
            player.inventory.GiveItem(ItemManager.CreateByName("stonehatchet", 1));
            player.inventory.GiveItem(ItemManager.CreateByName("stone.pickaxe", 1));
            player.inventory.GiveItem(ItemManager.CreateByName("bandage", 3));
            player.inventory.GiveItem(ItemManager.CreateByName("apple", 3));
        }
    }
}