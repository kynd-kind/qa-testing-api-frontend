using System;
using Xunit;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonPlaceholderApi.Test
{
    public class ApiTests
    {
        [Fact]
        public void CheckEndPointContent()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/comments?postId=1");

            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            var objectResponse = JsonConvert.DeserializeObject<List<JSONModel>>(response.Content);

            var comments = objectResponse.Count;

            Assert.Equal(5, comments);

        }

        [Theory]
        [InlineData("https://jsonplaceholder.typicode.com/posts")]
        [InlineData("https://jsonplaceholder.typicode.com/comments")]
        [InlineData(" https://jsonplaceholder.typicode.com/photos")]
        [InlineData("https://jsonplaceholder.typicode.com/comments?postId=1")]
        public void CheckStatusCode(string input)
        {
            var client = new RestClient(input);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            
            IRestResponse response = client.Execute(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
