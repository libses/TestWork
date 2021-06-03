using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{
    
    public class Tests
    {
        [Test]
        public void ModelTest()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(2, 2);
            var p3 = new Vector(4, 0);
            var f = new Vector(2, 1);
            var list = new List<Vector>() { p1, p2, p3 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "inside");
        }
        
        [Test]
        public void ModelTest2()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(2, 2);
            var p3 = new Vector(4, 0);
            var f = new Vector(-1, -1);
            var list = new List<Vector>() { p1, p2, p3 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "outside");
        }
        [Test]
        public void ModelTest3()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(5, 2);
            var p3 = new Vector(3, 3);
            var p4 = new Vector(5, 4);
            var p5 = new Vector(0, 7);
            var f = new Vector(2, 3);
            var list = new List<Vector>() { p1, p2, p3, p4, p5 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "inside");
        }
        [Test]
        public void ModelTest4()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(5, 2);
            var p3 = new Vector(3, 3);
            var p4 = new Vector(5, 4);
            var p5 = new Vector(0, 7);
            var f = new Vector(1, 6);
            var list = new List<Vector>() { p1, p2, p3, p4, p5 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "inside");
        }
        [Test]
        public void ModelTest5()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(5, 2);
            var p3 = new Vector(3, 3);
            var p4 = new Vector(5, 4);
            var p5 = new Vector(0, 7);
            var f = new Vector(4, 4);
            var list = new List<Vector>() { p1, p2, p3, p4, p5 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "inside");
        }
        [Test]
        public void ModelTest6()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(5, 2);
            var p3 = new Vector(3, 3);
            var p4 = new Vector(5, 4);
            var p5 = new Vector(0, 7);
            var f = new Vector(4, 3);
            var list = new List<Vector>() { p1, p2, p3, p4, p5 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "outside");
        }
        [Test]
        public void ModelTest7()
        {
            var p1 = new Vector(0, 0);
            var p2 = new Vector(5, 2);
            var p3 = new Vector(3, 3);
            var p4 = new Vector(5, 4);
            var p5 = new Vector(0, 7);
            var f = new Vector(-1, 3);
            var list = new List<Vector>() { p1, p2, p3, p4, p5 };
            var model = new Model(new Polygon(list), f);
            Assert.IsTrue(model.MakeChecks() == "outside");
        }
    }
}
