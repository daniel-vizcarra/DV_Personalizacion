using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace DV_Frontend
{
    public partial class MainPageDV : ContentPage
    {
        private readonly HttpClient _httpClient;

        public MainPageDV(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;

            LoadAuthors();
        }

        private async void LoadAuthors()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7289/api/authors");

                if (response.IsSuccessStatusCode)
                {
                    var authors = await response.Content.ReadFromJsonAsync<List<Author>>();
                    ListViewAuthors.ItemsSource = authors;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    public class Author
    {
        public string? AuthorName { get; set; }
    }
}
