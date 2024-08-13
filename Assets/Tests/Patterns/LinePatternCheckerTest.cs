using JGM.Game.Patterns;
using JGM.Game.Rollers;
using NUnit.Framework;
using System.Collections.Generic;

namespace JGM.GameTests.Patterns
{
    public class LinePatternCheckerTest
    {
        private LinePatternChecker _linePatternChecker;

        [OneTimeSetUp]
        public void SetUp()
        {

            _linePatternChecker = new LinePatternChecker();
        }

        [Test]
        public void GetResult_ThreeConsecutiveLemons_Returns3ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Bag, (int)RollerItemType.Bag, (int)RollerItemType.Bag, (int)RollerItemType.Watch, (int)RollerItemType.Camera };
            var lemonsResult = _linePatternChecker.GetResultFromLine(list,null, null, null, null,0);
            Assert.AreEqual(3, lemonsResult.ItemCount);
        }

        [Test]
        public void GetResult_FourConsecutiveLemons_Returns4ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Watch, (int)RollerItemType.Watch, (int)RollerItemType.Watch, (int)RollerItemType.Watch, (int)RollerItemType.None };
            var bellsResult = _linePatternChecker.GetResultFromLine(list,null, null, null, null,0);
            Assert.AreEqual(4, bellsResult.ItemCount);
        }

        [Test]
        public void GetResult_TwoConsecutiveCherries_Returns2ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.None, (int)RollerItemType.None, (int)RollerItemType.Watch, (int)RollerItemType.Watch, (int)RollerItemType.Watch };
            var cherriesResult = _linePatternChecker.GetResultFromLine(list, null, null, null, null,0);
            Assert.AreEqual(2, cherriesResult.ItemCount);
        }

        [Test]
        public void GetResult_FiveConsecutivePlums_Returns5ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Iphone, (int)RollerItemType.Iphone, (int)RollerItemType.Iphone, (int)RollerItemType.Iphone, (int)RollerItemType.Iphone };
            var grapesResult = _linePatternChecker.GetResultFromLine(list, null,null, null, null,0);
            Assert.AreEqual(5, grapesResult.ItemCount);
        }

        [Test]
        public void GetResult_2Lemons1Bell2Lemons_Returns2ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Bag, (int)RollerItemType.Bag, (int)RollerItemType.Watch, (int)RollerItemType.Bag, (int)RollerItemType.Bag };
            var plumsResult = _linePatternChecker.GetResultFromLine(list, null, null, null, null,0);
            Assert.AreEqual(2, plumsResult.ItemCount);
        }

        [Test]
        public void GetResult_ZeroConsecutiveItems_Returns1ItemsCount()
        {
            var list = new List<int> { (int)RollerItemType.Bag, (int)RollerItemType.Camera, (int)RollerItemType.Watch, (int)RollerItemType.Iphone, (int)RollerItemType.None };
            var plumsResult = _linePatternChecker.GetResultFromLine(list, null, null , null, null,0);
            Assert.AreEqual(1, plumsResult.ItemCount);
        }
    }
}