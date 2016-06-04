using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirebaseSharp.Portable;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp;
using FireSharp.Response;
using FireSharp.EventStreaming;
using FireSharp.Extensions;


namespace GrabAndGo
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static readonly IFirebaseConfig Config = new FirebaseConfig
        {
            AuthSecret = "gU2Gw8mbC2k2cwKUGm54krL1WGItmkjaN8ksUIjp",
            BasePath = "https://grabngo-fc1e4.firebaseio.com/"
        };

        private IFirebaseClient _client = new FirebaseClient(Config);

        // set
        private async void SetDataToFirebase(string text)
        {
          var todo = new BOUser{Name = "", Address = ""};
            SetResponse response = await _client.SetAsync("todos/set", todo);
            BOUser result = response.ResultAs<BOUser>(); //The response will contain the data written
        }
        //Push
        private async void PushDataToFirebase(string text)
        {
            var todo = new BOUser { Name = "", Address = "" };
            PushResponse response =await  _client.PushAsync("todos/push", todo);
            string dis = response.Result.name;
        }
        //Get
        private async void GetDataToFirebase(string text)
        {
            FirebaseResponse response = await _client.GetAsync("todos/set");
            BOUser todo = response.ResultAs<BOUser>(); //The response will contain the data being retreived
        }
        //Update
        private async void UpdateDataToFirebase()
        {
            var todo = new BOUser { Name = "", Address = "" };
            FirebaseResponse response = await _client.UpdateAsync("todos/set", todo);
            var res = response.ResultAs<BOUser>(); //The response will contain the data written
        }
        //Delete
        private async void DeleteDataToFirebase()
        {
            FirebaseResponse response = await _client.DeleteAsync("todos"); //Deletes todos collection
            Console.WriteLine(response.StatusCode);
        }
        ////Listen Streaming from the REST API
        //private async void ListenStreamingFirebase()
        //{
        //    EventStreamResponse response = await _client.OnAsync("chat", (sender, args) =>
        //    {
        //        Console.WriteLine(args.Data);
        //    });

        //    //Call dispose to stop listening for events
        //    response.Dispose();
        //}
    }
}