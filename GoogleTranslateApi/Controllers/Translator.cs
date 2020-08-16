using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleTranslateApi
{
    class Translator
    {
        public static string Translate(string word)
        {
            using (HttpClient client = new HttpClient())
            {
                string res;
                GoogleKeyTokenGenerator googleKeyTokenGenerator = new GoogleKeyTokenGenerator();
                var token = googleKeyTokenGenerator.GenerateAsync(word).Result;
                var wordEncoded = HttpUtility.UrlEncode(word, Encoding.UTF8);
                try
                {
                    string resJson = client.GetStringAsync(new Uri($@"https://translate.google.ru/translate_a/single?client=webapp&sl=auto&q={wordEncoded}&tl=ru&hl=ru&dt=at&dt=bd&dt=ex&dt=ld&dt=md&dt=qca&dt=rw&dt=rm&dt=sos&dt=ss&dt=t&source=bh&ssel=0&tsel=0&xid=45662847&kc=1&tk={token}")).Result;
                    res = GetTranslation(resJson);
                }
                catch(AggregateException ex)
                {
                    res = ex.Message + ":" + ex.InnerException;
                }
                return res;
            }
        }

        private static string GetTranslation(string resJson)
        {
            JArray data = (JArray)JsonConvert.DeserializeObject(resJson);
            var res = data.First().First().First().ToString();
            return res;
        }
    }
}
