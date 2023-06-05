using FluentAssertions;
using GUI_Project.Models;
using GUI_Project.View_Models;

namespace GUI_Project.Test
{
    public class UnitTest1
    {
        [Fact]
        public void When_AddProductVM_Created()
        {
            AddProductWindowVM testwindowvm = new AddProductWindowVM();

            testwindowvm.productName.Should().BeNull();
            testwindowvm.image.Should().BeNull();
            testwindowvm.price.Should().Be(0);
        }

        [Fact]
        public void When_EditProductWindowVM_Created()
        {
            EditProductWindowVM testwindowvm = new EditProductWindowVM();

            testwindowvm.productName.Should().BeNull();
            testwindowvm.image.Should().BeNull();
            testwindowvm.price.Should().Be(0);
        }
    }
}