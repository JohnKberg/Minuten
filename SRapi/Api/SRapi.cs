using SRapi.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRapi
{
    public class SRapi
    {
        public string BaseUrl { get; set; }

        public SRapi(string baseUrl = "http://api.sr.se/api/v2/")
        {
            this.BaseUrl = baseUrl;
        }

        #region RestSharp helpers

        /// <summary>
        /// Execute API call and serialize response to .NET object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(this.BaseUrl);

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving API response. Check inner details for more info.";
                var callException = new ApplicationException(message, response.ErrorException);
                throw callException;
            }

            return response.Data;
        }

        /// <summary>
        /// Execute API call and get RestResponse object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private IRestResponse ExecuteGetResponseObject(RestRequest request)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(this.BaseUrl);

            var response = client.Execute(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving API response. Check inner details for more info.";
                var callException = new ApplicationException(message, response.ErrorException);
                throw callException;
            }

            return response;
        }

        #endregion

        #region API ENDPOINTS

        public EpisodeArrayResponse GetAllProgramEpisodes(int programId, DateTime? fromDate, string format = "json")
        {
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Resource = "episodes/index";

            request.AddParameter("programid", programId, ParameterType.QueryString);

            request.AddParameter("format", format, ParameterType.QueryString);
            request.AddParameter("pagination", "false", ParameterType.QueryString);

            if (fromDate.HasValue)
            {
                request.AddParameter("fromdate", fromDate.Value.ToString("yyyy-MM-dd"), ParameterType.QueryString);
            }

            return this.Execute<EpisodeArrayResponse>(request);
        }


        #endregion
    }
}
