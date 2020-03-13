using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Knapsack_problem_interface
{
    [Serializable]
    public class Item
    {
        public string name;
        public int weight;
        public int cost;
        public bool IsOld = true;

        public Item(string name, int weight, int cost)
        {
            this.name = name;
            this.weight = weight;
            this.cost = cost;
        }

        public Item() { }
    }

    class Items
    {
        public List<Item> list_of_items;

        public Items()
        {
            list_of_items = new List<Item>();
        }

        public Items(List<Item> lst)
        {
            list_of_items = lst;
        }

        public void Add(string name, int weight, int cost)
        {
            list_of_items.Add(new Item(name, weight, cost));
        }

        public void Change(int id, string name, int weight, int cost)
        {
            list_of_items[id].name = name;
            list_of_items[id].weight = weight;
            list_of_items[id].cost = cost;
        }

        public void Delete(int id)
        {
            list_of_items.RemoveAt(id);
        }
    }
}
