using UnityEngine;
using System;
using System.IO;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
////Request library
//using System.Net;
//using System.IO;
//using System;
//using System.Net.Http.Headers;
//using System.Text;
using System.Net;
using System.Collections;
//using System.Web;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Image image;
    // Use this for initialization
    void Start()
    {
        //byte[] bit;
        //using (MemoryStream ms = new MemoryStream())
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    bf.Serialize(ms, texture);
        //    bit = ms.ToArray();
        //}
        //print(bit);
        //HttpWebRequest client = new HttpWebRequest(url);

    }

    // Update is called once per frame
    void Update()
    {

    }
    //public string ImageToBase64(Image image,
    //      System.Drawing.Imaging.ImageFormat format)
    //{
    //    using (MemoryStream ms = new MemoryStream())
    //    {
    //        // Convert Image to byte[]
    //        image.Save(ms, format);
    //        byte[] imageBytes = ms.ToArray();

    //        // Convert byte[] to Base64 String
    //        string base64String = Convert.ToBase64String(imageBytes);
    //        return base64String;
    //    }
    //}
    protected string get(string url)
    {
        try
        {
            string rt;

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            rt = reader.ReadToEnd();

            Console.WriteLine(rt);

            reader.Close();
            response.Close();

            return rt;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}

