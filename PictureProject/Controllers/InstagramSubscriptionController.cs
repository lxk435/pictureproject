using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.WebHooks;
using PictureProject.Instagram;


namespace PictureProject.Controllers
{
    [RoutePrefix("api/instagram")]
    public class InstagramSubscriptionController : ApiController
    {

        [Route("subscribe-user")]
        public async Task<IHttpActionResult> PostSubscribeUser()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Subscribe to a geo location, in this case within 5000 meters of Times Square in NY
            var sub = await client.SubscribeAsync(string.Empty, Url);

            return Ok(sub);
        }

        [Route("subscribe-tag")]
        public async Task<IHttpActionResult> PostSubscribeTag()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Subscribe to a geo location, in this case within 5000 meters of Times Square in NY
            var sub = await client.SubscribeAsync(string.Empty, Url, "#zonebristol");

            return Ok(sub);
        }

        [Route("subscribe")]
        public async Task<IHttpActionResult> PostSubscribe()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Subscribe to a geo location, in this case within 5000 meters of Times Square in NY
            var sub = await client.SubscribeAsync(string.Empty, Url, 51.455117, -2.584271, 5000);

            return Ok(sub);
        }

        [Route("unsubscribe")]
        public async Task PostUnsubscribeAll()
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Unsubscribe from all subscriptions for the client configuration with id="".
            await client.UnsubscribeAsync("");
        }

        [Route("unsubscribe/{subId}")]
        public async Task PostUnsubscribe(string subId)
        {
            // Get our WebHook Client
            InstagramWebHookClient client = Dependencies.Client;

            // Unsubscribe from the given subscription using client configuration with id="".
            await client.UnsubscribeAsync("", subId);
        }

    }
}
