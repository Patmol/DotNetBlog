using DotNetBlog.Cli.Tools.Build;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetBlog.Cli.Tests.Tools
{
    [TestClass]
    public partial class BuilderTests
    {
        [TestMethod]
        public void TestLoadConfigurationBlog1()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathDirectory = System.IO.Path.GetDirectoryName(path);

            var builder = new Builder($"{pathDirectory}/Examples/Blog-1");
            builder.LoadConfiguration();

            Assert.AreEqual("My Test Title", builder.Configuration.Title);
            Assert.AreEqual("My Test Subtitle", builder.Configuration.Subtitle);
            Assert.AreEqual("My Test Description", builder.Configuration.Description);
            Assert.AreEqual("/assets/img/logo.png", builder.Configuration.Logo);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Tags);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Categories);
        }

        [TestMethod]
        public void TestLoadConfigurationBlog2()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathDirectory = System.IO.Path.GetDirectoryName(path);

            var builder = new Builder($"{pathDirectory}/Examples/Blog-2");
            builder.LoadConfiguration();

            Assert.AreEqual("My Test Title", builder.Configuration.Title);
            Assert.AreEqual("My Test Subtitle", builder.Configuration.Subtitle);
            Assert.AreEqual("My Test Description", builder.Configuration.Description);
            Assert.AreEqual(false, builder.Configuration.PageDetails.Tags);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Categories);
        }

        [TestMethod]
        public void TestLoadConfigurationBlog3()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathDirectory = System.IO.Path.GetDirectoryName(path);

            var builder = new Builder($"{pathDirectory}/Examples/Blog-3");
            builder.LoadConfiguration();

            Assert.AreEqual(null, builder.Configuration.Title);
            Assert.AreEqual("My Test Subtitle", builder.Configuration.Subtitle);
            Assert.AreEqual("My Test Description", builder.Configuration.Description);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Tags);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Categories);
        }

        [TestMethod]
        public void TestLoadConfigurationBlog4()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathDirectory = System.IO.Path.GetDirectoryName(path);

            var builder = new Builder($"{pathDirectory}/Examples/Blog-4");
            builder.LoadConfiguration();

            Assert.AreEqual("My Test Title", builder.Configuration.Title);
            Assert.AreEqual("My Test Subtitle", builder.Configuration.Subtitle);
            Assert.AreEqual(null, builder.Configuration.Description);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Tags);
            Assert.AreEqual(true, builder.Configuration.PageDetails.Categories);
        }

        [TestMethod]
        public void TestLoadConfigurationNoFile()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathDirectory = System.IO.Path.GetDirectoryName(path);

            var builder = new Builder($"{pathDirectory}/Examples/Blog-Empty");
            Assert.ThrowsException<System.IO.FileNotFoundException>(builder.LoadConfiguration);
        }

        [TestMethod]
        public void TestLoadConfigurationNoFolder()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathDirectory = System.IO.Path.GetDirectoryName(path);

            var builder = new Builder($"{pathDirectory}/Examples/Blog-Error");
            Assert.ThrowsException<System.IO.DirectoryNotFoundException>(builder.LoadConfiguration);
        }
    }
}