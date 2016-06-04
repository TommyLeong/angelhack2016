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

        private readonly IFirebaseClient _client = new FirebaseClient(Config);

        // set
        private async void SetDataToFirebase()
        {
          var todo = new BOUser
          {
              address = "set",
              carPlate = "set1234",
              carType = "set1234",
              contactnumber = "2352353263",
              ic = "53532543525",
              licenseNo = "23234ADS",
              name = "set",
              password = "12345",
              status = "set",
              username = "set",
              email = "",
              isDriver = false
          };
            SetResponse response = await _client.SetAsync("User/1", todo);
            BOUser result = response.ResultAs<BOUser>(); //The response will contain the data written
        }
        //Push
        private async void PushDataToFirebase()
        {
            var todo = new BOUser
            {
                address = "update",
                carPlate = "gtfghgf",
                carType = "update",
                contactnumber = "update",
                ic = "update",
                licenseNo = "update",
                name = "update1",
                password = "update",
                status = "update",
                username = "update",
            };
            PushResponse response = await _client.PushAsync("User/1", todo);
            string dis = response.Result.name;
        }
        //Get
        private async void GetDataToFirebase()
        {
            FirebaseResponse response = await _client.GetAsync("User/1");
            BOUser todo = response.ResultAs<BOUser>(); //The response will contain the data being retreived
            Console.WriteLine(todo);
        }
        //Update
        private async void UpdateDataToFirebase()
        {
            var todo = new BOUser
            {
                address = "update",
                carPlate = "gtfghgf",
                carType = "update",
                contactnumber = "update",
                ic = "update",
                licenseNo = "update",
                name = "update1",
                password = "update",
                status = "update",
                username = "update",
            };

            var response = await _client.UpdateAsync("User/1", todo);
            var res = response.ResultAs<BOUser>(); //The response will contain the data written
            Console.WriteLine(res);
        }
        //Delete
        private async void DeleteDataToFirebase()
        {
            FirebaseResponse response = await _client.DeleteAsync("User/1"); //Deletes todos collection
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
        protected void btnTest1_OnClick(object sender, EventArgs e)
        {
            SetDataToFirebase();
        }

        protected void btnTest2_OnClick(object sender, EventArgs e)
        {
            PushDataToFirebase();
        }

        protected void btnTest3_OnClick(object sender, EventArgs e)
        {
            GetDataToFirebase();
        }

        protected void btnTest4_OnClick(object sender, EventArgs e)
        {
            UpdateDataToFirebase();
        }

        protected void btnTest5_OnClick(object sender, EventArgs e)
        {
            DeleteDataToFirebase();
        }
    }
}