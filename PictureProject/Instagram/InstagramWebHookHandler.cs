using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNet.WebHooks; 
using Newtonsoft.Json.Linq;
using PictureProject.Models;


namespace PictureProject.Instagram
{
    public class InstagramWebHookHandler : WebHookHandler
    {
        private PictureProjectContext db = new PictureProjectContext();

        public InstagramWebHookHandler()
        {
            this.Receiver = "instagram";
        }

        public override async Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Get the WebHook client
            InstagramWebHookClient client = Dependencies.Client;

            // Convert the incoming data to a collection of InstagramNotifications
            var notifications = context.GetDataOrDefault<IEnumerable<InstagramNotification>>();
            foreach (var notification in notifications)
            {
                // Use WebHook client to get detailed information about the posted media
                var entries = await client.GetRecentGeoMedia(context.Id, notification.ObjectId);
                foreach (JToken entry in entries)
                {
                    InstagramPost post = entry.ToObject<InstagramPost>();
                    
                    // Image information 
                    if (post.Images != null)
                    {
                        InstagramMedia thumbnail = post.Images.Thumbnail;
                        InstagramMedia lowRes = post.Images.LowResolution;
                        InstagramMedia stdRes = post.Images.StandardResolution;

                        var InstImage = new InstagramImage();
                        InstImage.Address = stdRes.Address.ToString();
                        InstImage.Height = stdRes.Height;
                        InstImage.Width = stdRes.Width;
                        
                        SaveImage(InstImage);

                    }
                }
            }
        }

        // Non-post, non-api save image to database
        [ResponseType(typeof(InstagramImage))]
        public async void SaveImage(InstagramImage instagramImage)
        {
            db.InstagramImages.Add(instagramImage);
            await db.SaveChangesAsync();
        }
    }
}