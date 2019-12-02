using System;

namespace Zebble.Device
{
    public partial class Sharing
    {
        public partial class Twitter
        {
            public static void Tweet(string text)
            {
                var link = "https://twitter.com/intent/tweet?text=" + text.UrlEncode();
                OS.OpenBrowser(link);
            }

            public static void TweetPhoto(string text, byte[] photo)
            {
                throw new NotImplementedException();
            }

            public static void TweetLink(string text, string url) => Tweet(url + text.WithPrefix(" "));

            public static void Retweet(string tweetId)
            {
                OS.OpenBrowser("https://twitter.com/intent/retweet?tweet_id=" + tweetId);
            }
        }
    }
}
