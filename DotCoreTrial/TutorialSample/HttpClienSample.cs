using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SampleProgrames.TutorialSample
{
    class HttpClienSample
    {
        /**
         * sample:
         * {
  "id" : "local-1537158791158",
  "name" : "Spark Pi",
  "attempts" : [ {
    "startTime" : "2018-09-17T04:33:10.072GMT",
    "endTime" : "2018-09-17T04:38:06.666GMT",
    "lastUpdated" : "2018-09-17T04:38:06.000GMT",
    "duration" : 296594,
    "sparkUser" : "snow",
    "completed" : true,
    "appSparkVersion" : "2.3.1",
    "endTimeEpoch" : 1537159086666,
    "startTimeEpoch" : 1537158790072,
    "lastUpdatedEpoch" : 1537159086000
  }]
         * */
        public string getSparkApps()
        {
            using(var client=new HttpClient())
            {
                string url = @"http://10.172.88.67:18080/api/v1";
                string apps = url + "/applications";
                string appResult = null;
                try
                {
                    Task<HttpResponseMessage> task=client.GetAsync(apps);
                    HttpResponseMessage resp = task.Result;
                    if (resp.IsSuccessStatusCode)
                    {
                        appResult=resp.Content.ReadAsStringAsync().Result;
                        return appResult;
                    }
                }catch(HttpRequestException e)
                {

                }
                catch
                {
                    return null;
                }
                return null;

            }
            //return null;
        }
        private string getREST(string url)
        {
            string appResult = null;
            try
            {
                var client = new HttpClient();
                Task<HttpResponseMessage> task = client.GetAsync(url);
                HttpResponseMessage resp = task.Result;
                if (resp.IsSuccessStatusCode)
                {
                    appResult = resp.Content.ReadAsStringAsync().Result;
                    return appResult;
                }
            }
            catch (HttpRequestException e)
            {

            }
            catch
            {
                return null;
            }
            return null;
        }
        public Application[] getApps(string s)
        {
            if (string.IsNullOrEmpty(s)) return null;
            string format = "YYYY-MM-DDThh:mm:ss.s";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
           
            List<Application> result = JsonConvert.DeserializeObject<List<Application>>(s, dateTimeConverter);
            foreach(Application app in result)
            {
                Console.WriteLine($"App ID: {app.id}   App Name: {app.name}");
            }
            return result.ToArray();
        }
        /**
         * [ {
  "jobId" : 0,
  "name" : "reduce at SparkPi.scala:38",
  "submissionTime" : "2018-09-17T04:33:12.753GMT",
  "completionTime" : "2018-09-17T04:38:06.653GMT",
  "stageIds" : [ 0 ],
  "status" : "SUCCEEDED",
  "numTasks" : 200000,
  "numActiveTasks" : 0,
  "numCompletedTasks" : 200000,
  "numSkippedTasks" : 0,
  "numFailedTasks" : 0,
  "numKilledTasks" : 0,
  "numCompletedIndices" : 200000,
  "numActiveStages" : 0,
  "numCompletedStages" : 1,
  "numSkippedStages" : 0,
  "numFailedStages" : 0,
  "killedTasksSummary" : { }
} ]
         * */
        public string getJobStr(Application app)
        {
            if (app == null) return null;
            string url = @"http://10.172.88.67:18080/api/v1/applications/{0}/jobs";

            string resp = this.getREST(string.Format(url, app.id));
            return resp;
        }
    }
    class Application
    {
        public string id { get; set; }
        public string name { get; set; }
        public IList<Attempt> attempts;
    }
    class Attempt
    {
        public string startTime;
        public string endTime;
        public string lastUpdated;
        public long duration;
        public string sparkUser;
        public bool completed;
        public string appSparkVersion;
        public long endTimeEpoch;
        public long startTimeEpoch;
        public long lastUpdatedEpoch;
    }
}
