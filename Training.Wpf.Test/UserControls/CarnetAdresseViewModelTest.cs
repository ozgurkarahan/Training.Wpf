using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Training.Wpf.UserControls;
using Training.Wpf.Commun;
using Training.Wpf.Properties;

namespace Training.Wpf.Test.UserControls
{
    /// <summary>
    /// Description résumée pour CarnetAdresseViewModelTest
    /// </summary>
    [TestClass]
    public class CarnetAdresseViewModelTest
    {
        public CarnetAdresseViewModelTest()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Ctor_doit_init_les_prop_public()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            Assert.IsNotNull(vm.Persons);
            Assert.AreEqual(ctx.Persons.Count, vm.Persons.Count);
            Assert.IsNotNull(vm.AddCommand);
            Assert.IsNotNull(vm.DelCommand);
        }

        [TestMethod]
        public void Test_Name()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            Assert.IsNotNull(vm.Name);
            Assert.AreEqual(Resources.EcranNameCarnetAdresse, vm.Name);
        }

        [TestMethod]
        public void Test_AddPerson()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            var count = vm.Persons.Count;

            vm.AddCommand.Execute(null);
            var countAfter = vm.Persons.Count;
            Assert.AreEqual(count + 1, countAfter);
            Assert.AreEqual(ctx.Persons.Count, countAfter);
        }

        [TestMethod]
        public void Test_DelPerson()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            vm.Persons.Add(new PersonModel());
            var count = vm.Persons.Count;
            vm.DelCommand.Execute(null);
            var countAfter = vm.Persons.Count;
            Assert.AreEqual(count - 1, countAfter);
            Assert.AreEqual(ctx.Persons.Count, countAfter);
        }

        [TestMethod]
        public void Test_CanAddPerson()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            var result = vm.AddCommand.CanExecute(null);
            Assert.IsTrue(result);
            for (int i = 0; i < Settings.Default.maxLengthOfCarnetAdresse; i++)
            {
                vm.Persons.Add(new PersonModel());
            }

            result = vm.AddCommand.CanExecute(null);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void Test_CanDelPerson()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            var result = vm.DelCommand.CanExecute(null);
            Assert.IsFalse(result);

            vm.Persons.Add(new PersonModel());


            result = vm.DelCommand.CanExecute(null);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Test_MaxLenght_Person()
        {
            var ctx = new Context();
            var vm = new CarnetAdresseViewModel(ctx);
            while (vm.AddCommand.CanExecute(null))
            {
                vm.AddCommand.Execute(null);
            }

            Assert.AreEqual(Settings.Default.maxLengthOfCarnetAdresse, vm.Persons.Count);                        
        }
    }
}
