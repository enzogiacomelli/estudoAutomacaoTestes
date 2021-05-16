using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;
using Faker;

namespace desafioAPITest
{
    public class Usuarios
    {
        string baseUrl = "https://serverest.dev/usuarios/";
        string deleteID = "8nEPy4gyjlqoyKw2";
        string editID = "wlwqbbmleLQwwHDa";
        string email = Faker.InternetFaker.Email();

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

            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(true, restResponse.IsSuccessful);
            Assert.IsTrue(restResponse.Content.Contains("Cadastro realizado com sucesso"));
        }

        public void getUsuarios()
        {
            RestClient restClient = new RestClient(baseUrl);
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(true, restResponse.IsSuccessful);
        }

        public void getUsuarioEspecifico()
        {
            RestClient restClient = new RestClient(baseUrl + editID);
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse = restClient.Execute(restRequest);

            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(true, restResponse.IsSuccessful);
            Assert.IsTrue(restResponse.Content.Contains(editID));
        }

        public void putUsuarios()
        {
            RestClient restClient = new RestClient(baseUrl + editID);

            JObject jsonBody = new JObject();
            jsonBody.Add("nome", "usuarioAlterado");
            jsonBody.Add("email", email);
            jsonBody.Add("password", "testealterado");
            jsonBody.Add("administrador", "true");


            RestRequest restRequest = new RestRequest(Method.PUT);
            restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            IRestResponse restResponse = restClient.Execute(restRequest);

            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(true, restResponse.IsSuccessful);
            Assert.IsTrue(restResponse.Content.Contains("Registro alterado com sucesso"));
        }

        public void deleteUsuarios()
        {
            RestClient restClient = new RestClient(baseUrl + deleteID);
            RestRequest restRequest = new RestRequest(Method.DELETE);

            IRestResponse restResponse = restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(true, restResponse.IsSuccessful);
            Assert.IsTrue(restResponse.Content.Contains("Registro excluído com sucesso"));
        }
    }
}
