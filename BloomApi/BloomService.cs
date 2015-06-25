using BloomApi.Entities;
using BloomApi.Exceptions;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace BloomApi
{
    public class BloomException : Exception { }
    public class BloomSearchOptions { }
    public class BloomService
    {
        const string sourceUri = "sources";
        const string searchUri = "search/{0}";
        const string findUri = "sources/{0}/{1}";

        public BloomService(string apiKey = null, Uri baseUri = null)
        {
            this.ApiKey = apiKey;
            this.BaseUri = baseUri == null ? new Uri("https://www.bloomapi.com/api/") : baseUri;
        }

        public string ApiKey { get; set; }
        public Uri BaseUri { get; set; }

        private static T GetRequest<T>(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            HttpWebResponse resp = null;
            T parsedResponse = default(T);

            try
            {
                resp = (HttpWebResponse)request.GetResponse();
                using (StreamReader respStream = new StreamReader(resp.GetResponseStream()))
                {
                    string respBody = respStream.ReadToEnd();
                    parsedResponse = JsonConvert.DeserializeObject<T>(respBody);
                }
            }
            catch (WebException e)
            {
                int statusCode;

                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    resp = (HttpWebResponse)e.Response;
                    statusCode = (int)resp.StatusCode;

                    if (statusCode >= 500)
                    {
                        throw new BloomApiInternalException("Unknown server error", e);
                    }
                    else if (statusCode >= 400 && statusCode < 500)
                    {
                        using (StreamReader respStream = new StreamReader(resp.GetResponseStream()))
                        {
                            string respBody = respStream.ReadToEnd();
                            BloomAPIUserErrorInfo info = JsonConvert.DeserializeObject<BloomAPIUserErrorInfo>(respBody);
                            throw new BloomAPIUserException(info.Name, info.Message, e);
                        }
                    }
                    else
                    {
                        throw;
                    }
                } else {
                    throw;
                }
            }
            finally
            {
                resp.Close();
            }

            return parsedResponse;
        }

        public BloomApiSourcesResponse Sources()
        {
            string uri = this.BaseUri + sourceUri;

            if (!String.IsNullOrEmpty(this.ApiKey))
            {
                uri += String.Format("?secret={0}", this.ApiKey);
            }

            return BloomService.GetRequest<BloomApiSourcesResponse>(uri);
        }

        public BloomApiSearchResponse Search(string sourceName, BloomApiSearchOptions options = null)
        {
            string uri = String.Format(searchUri, sourceName);
            string parameters = options != null ? options.ToParameters() : "";

            if (!String.IsNullOrEmpty(this.ApiKey))
            {
                parameters = String.IsNullOrEmpty(parameters) ? 
                                String.Format("secret={0}", this.ApiKey) :
                                String.Format("{0}&secret={1}", parameters, this.ApiKey);
            }

            if (!String.IsNullOrEmpty(parameters))
            {
                uri += String.Format("?{0}", parameters);
            }

            return BloomService.GetRequest<BloomApiSearchResponse>(this.BaseUri + uri);
        }

        public BloomApiFindResponse Find(string sourceName, string id)
        {
            string uri = String.Format(findUri, sourceName, id);
            return BloomService.GetRequest<BloomApiFindResponse>(this.BaseUri + uri);
        }
    }
}
