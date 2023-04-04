//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Mobile.Domain1.Model;
//using MobileDemoProject.Controllers;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
 

//namespace HttpClientTestProject
//{
//    //[TestClass]
//    //public class GetAllTestEndpoint
//    //{
//    //    private string getUrl = "https://localhost:7090/api/Customers/GetAllCustomer";
//    //    [TestMethod]
//    //    public void TestGetAllEndpoint()
//    //    {

//    //        HttpClient httpClient = new HttpClient();

//    //        httpClient.GetAsync(getUrl);

//    //        httpClient.Dispose();
//    //    }

//    //    [TestMethod]
//    //    public void TestGetAllEndpointwithUri()
//    //    {
//    //        HttpClient httpClient = new HttpClient();
//    //        Uri getUri = new Uri(getUrl);
//    //        httpClient.GetAsync(getUri);
//    //        httpClient.Dispose();
//    //    }
//    //}

//    public class MyHttpClient
//    {
//        private readonly HttpCustomerController _httpClient;

//        public MyHttpClient(HttpCustomerController httpClient)
//        {
//            _httpClient = httpClient;
//        }

//        public async Task<customer> GetAsync(customer url)
//        {
//            var response = await _httpClient.GetAsync(url);
//            response.EnsureSuccessStatusCode();
//            return await response.Content.ReadAsStringAsync();
//        }
//    }
//    [Fact]
//    public async Task GetAsync_ShouldReturnData()
//    {
//        // Arrange
//        var expectedData = "some data";
//        var response = new HttpResponseMessage()
//        {
//            StatusCode = HttpStatusCode.OK,
//            Content = new StringContent(expectedData)
//        };

//        var mockHttp = new Mock<HttpCustomerController>();
//        mockHttp
//            .Setup(x => x.GetAsync (It.IsAny<customer>()))
//            .ReturnsAsync(response);

//        var myHttpClient = new MyHttpClient(mockHttp.Object);

//        // Act
//        var result = await myHttpClient.GetAsync("");

//        // Assert
//        Assert.Equal(expectedData, result);
//    }
//}

