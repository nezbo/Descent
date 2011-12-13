

namespace Descent.ManualValidation.GUI
{
    using Descent.GUI;
    using NUnit.Framework;

    [TestFixture]
    public class GUITests
    {
        [Test]
        public void ElementFocus()
        {
            GUIElement root = new GUIElement(null, "root", 0, 0, 50, 50);
            GUIElement childOne = new GUIElement(null, "child1", 10, 10, 10, 10);
            GUIElement childTwo = new GUIElement(null, "child2", 40, 40, 10, 10);

            root.AddChild(childOne);
            root.AddChild(childTwo);

            root.HandleClick(15, 15);

            Assert.That(childOne.HasFocus());
            Assert.That(!root.HasFocus());
            Assert.That(!childTwo.HasFocus());

            root.HandleClick(25, 25);

            Assert.That(!childOne.HasFocus());
            Assert.That(root.HasFocus());
            Assert.That(!childTwo.HasFocus());
        }
    }
}
