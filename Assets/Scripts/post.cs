using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using System;

public class post : MonoBehaviour
{


    [System.Serializable]
    public class Caption
    {
        public string text { get; set; }
        public double confidence { get; set; }
        public Caption()
        {

        }
        public Caption(string tex, double confide)
        {
            text = tex;
            confidence = confide;
        }
    }
    [System.Serializable]
    public class Description
    {
        public List<string> tags { get; set; }
        public List<Caption> captions { get; set; }

        public Description()
        {

        }

        public Description(List<string> tag, List<Caption> caption)
        {
            captions = caption;
            tags = tag;
        }
    }
    [System.Serializable]
    public class Metadata
    {
        public int width { get; set; }
        public int height { get; set; }
        public string format { get; set; }

        public Metadata()
        {

        }

        public Metadata(int w, int h, string f)
        {
            width = w;
            height = h;
            format = f;
        }
    }
    [System.Serializable]
    public class RootObject
    {
        public Description description { get; set; }
        public string requestId { get; set; }
        public Metadata metadata { get; set; }

        public RootObject()
        {

        }

        public RootObject(Description des, string request, Metadata meta)
        {
            description = des;
            requestId = request;
            metadata = meta;
        }
    }



    //With the @ before the string, we can split a long string in many lines without getting errors
    //private string json = @"{" +
    //    "\"url\":\"http://l7.alamy.com/zooms/dca7eca301d54050b9f1307ce6c9a575/rubbish-on-the-street-next-to-an-empty-trash-can-drnhcm.jpg\"}";
    public string result;
    public Dictionary<string, double> tags = new Dictionary<string, double>();
    private string json = @"{" +
      "\"url\":\"https://i.ytimg.com/vi/B7SgggfAOxM/hqdefault.jpg\"}";
    void Start()
    {
        doPost();
    }
    void doPost()
    {
        string URL = "https://westus.api.cognitive.microsoft.com/vision/v1.0/tag";
        //string myAccessKey = "myAccessKey";
        //string mySecretKey = "mySecretKey";

        ////Auth token for http request
        //string accessToken;
        ////Our custom Headers
        Dictionary<string, string> headers = new Dictionary<string, string>();
        ////Encode the access and secret keys
        //accessToken = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(myAccessKey + ":" + mySecretKey));
        //Add the custom headers

        headers.Add("Content-Type", "application/json");
        headers.Add("cache-control", "no-cache");
        headers.Add("ocp-apim-subscription-key", "8bc3eb0bcafc4f249de80867dd13fb9f");
        //headers.Add("application/json", json);
        //headers.Add("postman-token", "7f2b6dab-57af-1e93-7e13-c8594ff2265b");
        //Replace single ' for double " 
        //This is usefull if we have a big json object, is more easy to replace in another editor the double quote by singles one
        //json = json.Replace("'", "\"");
        //Encode the JSON string into a bytes
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //Now we call a new WWW request
        WWW www = new WWW(URL, postData, headers);
        //And we start a new co routine in Unity and wait for the response.
        StartCoroutine(WaitForRequest(www));
    }
    //Wait for the www Request
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            //Print server response
            Debug.Log(www.text);
            result = www.text;
            //print("Arpit".Substring(1, 3));
            decode(0);
            //deserial();
            foreach (KeyValuePair<string, double> keyval in tags)
            {
                print(keyval.Key);
                print(keyval.Value);
            }
        }
        else
        {
            //Something goes wrong, print the error response
            Debug.Log(www.error);
        }
    }
    public void decode(int nextIndex)
    {

        int indexofName = result.IndexOf("name", nextIndex);
        int indexofConfidence = result.IndexOf("confidence", nextIndex);
        string key = result.Substring(indexofName + 7, result.IndexOf("\"", indexofName + 7) - indexofName - 7);
        double value = Convert.ToDouble(result.Substring(indexofConfidence + 12, result.IndexOf("}", indexofConfidence + 12) - indexofConfidence - 12));
        //string value = result.Substring(indexofConfidence + 12, result.IndexOf("}", indexofConfidence + 12) - indexofConfidence -12);
        tags.Add(key, value);
        if (result.IndexOf("name", result.IndexOf("}", indexofConfidence + 12) - 1) >= 0)
            decode(result.IndexOf("}", indexofConfidence + 12) - 1);


//        { "tags":[{"name":"grass","confidence":0.99914407730102539},{"name":"abstract","confidence":0.99815255403518677},{"name":"outdoor","confidence":0.99132603406906128},{"name":"graffiti","confidence":0.75391668081283569},{"name":"painted","confidence":0.634589672088623},{"name":"colorful","confidence":0.37447750568389893},{"name":"painting","confidence":0.26040360331535339}],"requestId":"19851fef-8982-4cc1-819b-01959d994b17","metadata":{"width":480,"height":360,"format":"Jpeg"}}
//UnityEngine.Debug:Log(Object)
//<WaitForRequest>c__Iterator1:MoveNext() (at Assets/post.cs:131)
//UnityEngine.SetupCoroutine:InvokeMoveNext(IEnumerator, IntPtr)



        //return result.IndexOf("\"", indexofConfidence + 12) - 1;
    }
    //public void deserial()
    //{
    //    List<Caption> jsono = JsonReader.Deserialize<List<Caption>>(result);
    //    List<Description> desJson = JsonReader.Deserialize<List<Description>>(result);
    //    print("Ho gaya!!");
    //    int i = 0;
    //    for (i = 0; i < jsono.Count; i++)
    //    {
    //        print(jsono[i] + "  and i is: " + i);
    //    }
    //    for (i = 0; i < desJson.Count; i++)
    //    {
    //        print(jsono[i] + "  and for description is: " + i);
    //    }
    //    print(jsono);
    //    print(desJson);
    //}
}