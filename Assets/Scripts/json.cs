using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
public class json : MonoBehaviour {

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
    // Use this for initialization
    void Start () {
        post po = new post();

        Caption caption = new Caption();
        caption.text = "23";
        caption.confidence = 22.22f;
        Caption caption1 = new Caption();
        caption1.text = "24";
        caption1.confidence = 99.99f;
        Description d = new Description();
        d.tags = new List<string>();
        d.tags.Add("Arpit");
        d.tags.Add("Arpit");
        d.captions = new List<Caption>();
        d.captions.Add(caption);
        d.captions.Add(caption1);
        string json = JsonWriter.Serialize(d);
        print(json);

        //List<Caption> jsono = JsonReader.Deserialize<List<Caption>>(po.result);
        print(po.result);

    }
    //void get()
    //{
    //    var client = new RestClient("https://westus.api.cognitive.microsoft.com/vision/v1.0/tag");
    //    var request = new RestRequest(Method.POST);
    //    request.AddHeader("postman-token", "3277b2f0-4075-885a-4500-293fc434ccd6");
    //    request.AddHeader("cache-control", "no-cache");
    //    request.AddHeader("ocp-apim-subscription-key", "8bc3eb0bcafc4f249de80867dd13fb9f");
    //    request.AddHeader("content-type", "application/json");
    //    request.AddParameter("application/json", "{\"url\":\"http://l7.alamy.com/zooms/dca7eca301d54050b9f1307ce6c9a575/rubbish-on-the-street-next-to-an-empty-trash-can-drnhcm.jpg\"}", ParameterType.RequestBody);
    //    IRestResponse response = client.Execute(request);
    //}
    // Update is called once per frame
    void Update () {
	
	}
}
