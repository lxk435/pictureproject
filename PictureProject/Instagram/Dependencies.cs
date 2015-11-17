using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.WebHooks;

namespace PictureProject.Instagram
{
    public static class Dependencies
    {
        private static InstagramWebHookClient _client;


        public static void Initialize(HttpConfiguration config)
        {
            _client = new InstagramWebHookClient(config);
        }


        public static InstagramWebHookClient Client
        {
            get { return _client; }
        }
    }
}