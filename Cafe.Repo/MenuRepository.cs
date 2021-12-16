using Cafe.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Repo
{
    public class MenuRepository
    {
        private List<Menu> _menuList = new List<Menu>();
        public void AddToMenu(Menu item)
        {
            _menuList.Add(item);
        }
        public List<Menu> GetMenuItems()
        {
            return _menuList;
        }
        //Update Method for later
        /*
        public bool UpdateMenuItems(int mealNum, Menu newItem)
        {
            Menu oldItem = GetMenuItemsByNum(mealNum);

            if(oldItem != null)
            {
                oldItem.MealNum = newItem.MealNum;
                oldItem.Name = newItem.Name;
                oldItem.MealDesc = newItem.MealDesc;
                oldItem.TypeOfIngredient = newItem.TypeOfIngredient;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }*/
        public bool RemoveItemFromMenu(int mealNum)
        {
            Menu item = GetMenuItemsByNum(mealNum);

            if(item == null)
            {
                return false;
            }
            int initialCount = _menuList.Count;
            _menuList.Remove(item);
            if(initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Menu GetMenuItemsByNum(int mealNum)
        {
            foreach (Menu item in _menuList)
            {
                if(item.MealNum == mealNum)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
