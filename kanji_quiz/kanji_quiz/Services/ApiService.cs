﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using kanji_quiz.Exceptions;
using kanji_quiz.Models;
using Newtonsoft.Json;
using Prism.Services;

namespace kanji_quiz.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        private const string HOST = "http://shtptraining-career.azurewebsites.net";
        

        public ApiService()
        {

            _httpClient = new HttpClient { BaseAddress = new Uri(HOST) };
        }

        public Task<Quiz> Quiz_Detail(string Id)
        {
            var url = $"Quiz/detail/{Id}";
            return GetAsync<Quiz>(url);
        }
        internal async Task<T> GetAsync<T>(string url) where T : class
        {

            var message = new HttpRequestMessage(HttpMethod.Get, url);
            Debug.WriteLine("GET: " + url);
            var response = await _httpClient.SendAsync(message);


            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                {
                    Debug.WriteLine("RESPONSE: " + content);
                    var r = JsonConvert.DeserializeObject<T>(content);

                    return r;
                }
            }

            return default(T);
        }
    }
}
