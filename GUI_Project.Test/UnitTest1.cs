using FluentAssertions;
using GUI_Project.Models;
using GUI_Project.View_Models;
using System.Diagnostics;

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

        [Fact]
        public void Product_Added()
        {
            Product p = new Product()
            {
                ProductName = "testproduct",
                Image = "testimage",
                Price = 10
            };

            var dbContext = new DatabaseContext();
            var context = dbContext.CreateContextForSQlite();

            AddProductWindowVM productAdding = new AddProductWindowVM();

            productAdding.addProduct(p);
            context.ListofProducts.Count().Should().Be(1);
        }
    }
}