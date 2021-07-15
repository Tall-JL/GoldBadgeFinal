using CafePOCO;
using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private MenuItemRepo _items;
        private MenuItem _menuItem;
        private Ingredient _ingredient;

       [TestInitialize]
       public void Arrange()
        {
            _items = new MenuItemRepo();
            _ingredient = new Ingredient("Nuts");
            _menuItem = new MenuItem("1", "Brownie", "Yum yum in ya tum", new List<Ingredient> {_ingredient} ,3m);

            _items.AddItemToMenu(_menuItem);
        }

        [TestMethod]
        public void AddItemToMenu_ItemAddedToField_ReturnTrue()
        {
            bool result = _items.AddItemToMenu(_menuItem);
           
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AddIgredientToItem_IngredientIsAdded_ReturnTrue()
        {
            //Arrange

            //Act
            bool result = _items.AddIngredientToItem(_menuItem, "Nuts");
            //Assert
            Assert.IsTrue(result);
        }        
        [TestMethod]
        public void DeleteMenuItem_ItemIsNotNull_ReturnTrue()
        {
            //Arrange

            //Act
            bool result = _items.DeleteMenuItem("1");
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DeleteMenuItem_ItemIsNull_ReturnFalse()
        {
            //Arrange

            //Act
            bool result = _items.DeleteMenuItem("100");
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void GetMenuItemByNumber_NotNull_ReturnItem()
        {
            //Arrange
            string number = "1";
            //Act
             MenuItem result = _items.GetMenuItemByNumber(number);
            //Assert
            Assert.AreEqual(result.MealNumber, number);
        } 
        [TestMethod]
        public void GetMenuItemByNumber_IsNull_ReturnNull()
        {
            //Arrange
            string number = "90";
            //Act
            MenuItem result = _items.GetMenuItemByNumber(number);
            //Assert
            Assert.IsNull(result);
        }         
        [TestMethod]
        public void GetIngredientName_IsNull_ReturnNull()
        {
            //Arrange
            string name = "Bromance";
            //Act
            MenuItem result = _items.GetMenuItemByNumber(name);
            //Assert
            Assert.IsNull(result);
        }
       
    }
}
