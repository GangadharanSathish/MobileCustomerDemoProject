using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HttpClientTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            HttpClient httpclient = new HttpClient();

            httpclient.Dispose();
        }
    }
}