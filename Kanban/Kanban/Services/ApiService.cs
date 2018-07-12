using Kanban.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Services
{
    public class ApiService
    {
        public async Task<ContentResponse<List<TaskModel>>> GetAllTasks()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                    string url = "https://eafit.azurewebsites.net/tables/tasks";
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    return new ContentResponse<List<TaskModel>>()
                    {
                        HttpResponse = response,
                        Data = JsonConvert.DeserializeObject<List<TaskModel>>(json)
                    };
                }
            }
            else
            {
                return new ContentResponse<List<TaskModel>>()
                {
                    HttpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout)
                };
            }
        }

        public async Task<ContentResponse<TaskModel>> GetTaskById(string taskId)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                    string url = $"https://eafit.azurewebsites.net/tables/tasks/{taskId}";
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    var result = new ContentResponse<TaskModel>()
                    {
                        HttpResponse = response,
                        Data = JsonConvert.DeserializeObject<TaskModel>(json)
                    };

                    return result;
                }
            }
            else
            {
                return new ContentResponse<TaskModel>()
                {
                    HttpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout)
                };
            }
        }

        public async Task<ContentResponse<TaskModel>> DeleteTaskById(string taskId)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                    string url = $"https://eafit.azurewebsites.net/tables/tasks/{taskId}";
                    var response = await client.DeleteAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    var result = new ContentResponse<TaskModel>()
                    {
                        HttpResponse = response,
                        Data = JsonConvert.DeserializeObject<TaskModel>(json)
                    };

                    return result;
                }
            }
            else
            {
                return new ContentResponse<TaskModel>()
                {
                    HttpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout)
                };
            }
        }

        public async Task<ContentResponse<TaskModel>> Create(TaskModel taskModel)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                    string url = $"https://eafit.azurewebsites.net/tables/tasks";
                    StringContent body = new StringContent(JsonConvert.SerializeObject(taskModel), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, body);
                    var json = await response.Content.ReadAsStringAsync();

                    var result = new ContentResponse<TaskModel>()
                    {
                        HttpResponse = response,
                        Data = JsonConvert.DeserializeObject<TaskModel>(json)
                    };

                    return result;
                }
            }
            else
            {
                return new ContentResponse<TaskModel>()
                {
                    HttpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout)
                };
            }
        }

        public async Task<ContentResponse<TaskModel>> Update(TaskModel taskModel)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");

                    var method = new HttpMethod("PATCH");
                    string url = $"https://eafit.azurewebsites.net/tables/tasks/{taskModel.Id}";
                    StringContent body = new StringContent(JsonConvert.SerializeObject(taskModel), Encoding.UTF8, "application/json");

                    var request = new HttpRequestMessage(method, url)
                    {
                        Content = body
                    };

                    HttpResponseMessage response = new HttpResponseMessage();
                    response = await client.SendAsync(request);

                    var json = await response.Content.ReadAsStringAsync();

                    var result = new ContentResponse<TaskModel>()
                    {
                        HttpResponse = response,
                        Data = JsonConvert.DeserializeObject<TaskModel>(json)
                    };

                    return result;
                }
            }
            else
            {
                return new ContentResponse<TaskModel>()
                {
                    HttpResponse = new HttpResponseMessage(System.Net.HttpStatusCode.RequestTimeout)
                };
            }
        }
    }
}
