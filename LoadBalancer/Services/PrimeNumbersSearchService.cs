using LoadBalancer.dtos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Services
{
    public interface IPrimeNumbersSearchService
    {
        Task<ResultDTO> CountPrimesRandom(string start, string end);
        Task<ResultDTO> CountPrimesRoundRobin(string start, string end);
    }

    public class PrimeNumbersSearchService : IPrimeNumbersSearchService
    {
        private readonly ILoadBalancer _loadBalancer;
        private readonly IRestClient _restClient;
        public PrimeNumbersSearchService(ILoadBalancer loadBalancer, IRestClient restCleint)
        {
            _loadBalancer = loadBalancer;
            _restClient = restCleint;
        }

        public async Task<ResultDTO> CountPrimesRandom(string start, string end)
        {
            return await GetAsync(_loadBalancer.GetRandomPort(), "random", start, end);
        }

        public async Task<ResultDTO> CountPrimesRoundRobin(string start, string end)
        {
            return await GetAsync(_loadBalancer.GetNextPort(), "round-robin", start, end);
        }

        private async Task<ResultDTO> GetAsync(int port, string method, string start, string end)
        {
            _restClient.BaseUrl = new Uri($"https://localhost:{port}/PrimeNumber");

            var request = new RestRequest($"{start}/{end}", Method.GET);
            var response = await _restClient.ExecuteAsync(request);

            ResultDTO responseObject = JsonConvert.DeserializeObject<ResultDTO>(response.Content);
            responseObject.URL = $"Fetched data from: '{_restClient.BaseUrl}' using the '{method}' method";

            return responseObject;
        }
    }
}
