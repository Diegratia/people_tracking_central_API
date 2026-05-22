using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CentralMonitoring.Application.Common.Interfaces;
using CentralMonitoring.Domain.Entities;

namespace CentralMonitoring.Infrastructure.Services
{
    public class SiteHttpClient : ISiteClient
    {
        private readonly HttpClient _httpClient;
        private const string ApiKeyHeaderName = "X-BIOPEOPLETRACKING-API-KEY";

        public SiteHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MonitoringConfigInfo>> GetMonitoringConfigsAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default)
        {
            var cleanUrl = baseUrl.TrimEnd('/') + "/api/MonitoringConfig/open";
            var request = new HttpRequestMessage(HttpMethod.Get, cleanUrl);
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add(ApiKeyHeaderName, apiKey);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var wrapper = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<List<MonitoringConfigInfo>>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, 
                cancellationToken);

            return wrapper?.Collection?.Data ?? new List<MonitoringConfigInfo>();
        }

        public async Task<IEnumerable<Building>> GetBuildingsAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default)
        {
            var cleanUrl = baseUrl.TrimEnd('/') + "/api/MstBuilding/open/central";
            var request = new HttpRequestMessage(HttpMethod.Get, cleanUrl);
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add(ApiKeyHeaderName, apiKey);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var wrapper = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<List<Building>>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, 
                cancellationToken);

            return wrapper?.Collection?.Data ?? new List<Building>();
        }

        public async Task<IEnumerable<Floor>> GetFloorsAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default)
        {
            var cleanUrl = baseUrl.TrimEnd('/') + "/api/MstFloor/open";
            var request = new HttpRequestMessage(HttpMethod.Get, cleanUrl);
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add(ApiKeyHeaderName, apiKey);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var wrapper = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<List<Floor>>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, 
                cancellationToken);

            return wrapper?.Collection?.Data ?? new List<Floor>();
        }

        public async Task<IEnumerable<Floorplan>> GetFloorplansAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default)
        {
            var cleanUrl = baseUrl.TrimEnd('/') + "/api/MstFloorplan/open";
            var request = new HttpRequestMessage(HttpMethod.Get, cleanUrl);
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add(ApiKeyHeaderName, apiKey);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var wrapper = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<List<Floorplan>>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, 
                cancellationToken);

            return wrapper?.Collection?.Data ?? new List<Floorplan>();
        }

        public async Task<IEnumerable<MaskedArea>> GetMaskedAreasAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default)
        {
            var cleanUrl = baseUrl.TrimEnd('/') + "/api/FloorplanMaskedArea/central";
            var request = new HttpRequestMessage(HttpMethod.Get, cleanUrl);
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add(ApiKeyHeaderName, apiKey);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var wrapper = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<List<MaskedArea>>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, 
                cancellationToken);

            return wrapper?.Collection?.Data ?? new List<MaskedArea>();
        }

        public async Task<IEnumerable<FloorplanDevice>> GetFloorplanDevicesAsync(string baseUrl, string? apiKey = null, CancellationToken cancellationToken = default)
        {
            var cleanUrl = baseUrl.TrimEnd('/') + "/api/FloorplanDevice/central";
            var request = new HttpRequestMessage(HttpMethod.Get, cleanUrl);
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add(ApiKeyHeaderName, apiKey);
            }

            var response = await _httpClient.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();

            var wrapper = await response.Content.ReadFromJsonAsync<ApiResponseWrapper<List<FloorplanDevice>>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, 
                cancellationToken);

            return wrapper?.Collection?.Data ?? new List<FloorplanDevice>();
        }


        private class ApiResponseWrapper<T>
        {
            public bool Success { get; set; }
            public string? Msg { get; set; }
            public CollectionWrapper<T>? Collection { get; set; }
        }

        private class CollectionWrapper<T>
        {
            public T? Data { get; set; }
        }
    }
}
