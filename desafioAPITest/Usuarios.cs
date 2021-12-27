using System;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;
using Faker;

namespace desafioAPITest
{
    public class Usuarios
    {
        string baseUrl = "https://serverest.dev/usuarios/";
        string email = InternetFaker.Email();
        

        public string getID()
        {
            var restResponse = getUsuarios(baseUrl);
            var a = restResponse.Content;
            var c = a.Substring(218).Remove(16);//recorta o id do primeiro usuario retornado
            Console.WriteLine(c);

            return c;
        }

        public void postUsuario()
        {
            RestClient restClient = new RestClient(baseUrl);

            JObject jsonBody = new JObject();
            jsonBody.Add("nome", "usuarioTESTE");
            jsonBody.Add("email", email);//muda o email a cada teste
            jsonBody.Add("password", "teste");
            jsonBody.Add("administrador", "true");


            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(true, restResponse.IsSuccessful);
            Assert.IsTrue(restResponse.Content.Contains("Cadastro realizado com sucesso"));
        }

        public IRestResponse getUsuarios(string url)
        {
            RestClient restClient = new RestClient(url);
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(true, restResponse.IsSuccessful);

            return restResponse;
        }

        public IRestResponse getUsuarioEspecifico(string id)
        {
            RestClient restClient = new RestClient(baseUrl + id);
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            Assert.AreEqual(true, restResponse.IsSuccessful);
            Assert.IsTrue(restResponse.Content.Contains(id));

            return restResponse;
        }

        public void putUsuarios(string id)
        {
            RestClient restClient = new RestClient(baseUrl + id);

            JObject jsonBody = new JObject();
            jsonBody.Add("nome", "usuarioAlterado2");
            jsonBody.Add("email", email);
            jsonBody.Add("password", "testealterado");
            jsonBody.Add("administrador", "true");


            RestRequest restRequest = new RestRequest(Method.PUT);
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        public void deleteUsuarios(string id)
        {
            RestClient restClient = new RestClient(baseUrl + id);
            RestRequest restRequest = new RestRequest(Method.DELETE);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }
    }
}
