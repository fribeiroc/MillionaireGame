using LibraryModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using MillionaireGameMvc.Controllers;
using System;
using System.Collections.Generic;
using Xunit;

namespace FunctionalTest
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<MillionaireGameMvc.Services.HttpClientService>>
    {
        private readonly WebApplicationFactory<MillionaireGameMvc.Services.HttpClientService> _httpClient;

        public UnitTest1(WebApplicationFactory<MillionaireGameMvc.Services.HttpClientService> httpClient)
        {
            _httpClient = httpClient;
        }

        [Fact]
        public void Test_AnswersIndex()
        {
            var client = _httpClient.CreateClient();
            //var result = client.

            var resultView = Assert.IsType<ViewResult>(null);

            List<Answer> list = new List<Answer>();

            list.Add(new Answer { Description = "O Anibal Com certeza" });
        }
    }
}
