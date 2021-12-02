using System;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;


class Program
{
    static void Main(string[] args)
    {
        var fileName = @"E:\Projects\Assesment\bonus_endpoints.json";

        Root Endpoint1 = JsonConvert.DeserializeObject<Root>(File.ReadAllText(fileName));
        foreach (var service in Endpoint1.services)
        {
            foreach (var endpoint in service.endpoints)
            {    
                var fullUrl = service.baseURL + endpoint.resource;


                using (WebClient wc = new System.Net.WebClient())
                {
                    try
                    {
                        var json = wc.DownloadString(fullUrl);

                        Console.WriteLine(json);
                        dynamic jsonFile = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                        if (jsonFile.name == "Luke Skywalker")
                        {
                            Console.WriteLine("************************************************************");
                            Console.WriteLine(jsonFile.name + "\n");
                            Console.WriteLine("************************************************************");
                        }
                        else
                        {
                            continue;
                        }
                        try
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<GeoPlugin>), new XmlRootAttribute("GeoPlugin"));
                            StringReader stringReader = new StringReader(jsonFile);
                            List<GeoPlugin> productList = (List<GeoPlugin>)serializer.Deserialize(stringReader);

                            Console.WriteLine(productList);
                        }
                        catch (Exception t) 
                        {
                            continue; 
                        }
                    }
                    catch(Exception e)
                    {
                        continue;
                    }

                }
            }
        }
    }
}

public class Response
    {
        public string element { get; set; }
        public string regex { get; set; }
        public string identifier { get; set; }
    }

    public class Endpoint
    {
        public bool enabled { get; set; }
        public string resource { get; set; }
        public List<Response> response { get; set; }
    }

    public class Service
    {
        public string baseURL { get; set; }
        public bool enabled { get; set; }
        public List<Endpoint> endpoints { get; set; }
    }

    public class Root
    {
        public List<Service> services { get; set; }
    }

    public class GetRequestedValues
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<object> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
    
    [XmlRoot(ElementName="geoPlugin")]
public class GeoPlugin { 

	[XmlElement(ElementName="geoplugin_request")] 
	public string GeopluginRequest { get; set; } 

	[XmlElement(ElementName="geoplugin_status")] 
	public int GeopluginStatus { get; set; } 

	[XmlElement(ElementName="geoplugin_delay")] 
	public string GeopluginDelay { get; set; } 

	[XmlElement(ElementName="geoplugin_credit")] 
	public string GeopluginCredit { get; set; } 

	[XmlElement(ElementName="geoplugin_city")] 
	public string GeopluginCity { get; set; } 

	[XmlElement(ElementName="geoplugin_region")] 
	public string GeopluginRegion { get; set; } 

	[XmlElement(ElementName="geoplugin_regionCode")] 
	public string GeopluginRegionCode { get; set; } 

	[XmlElement(ElementName="geoplugin_regionName")] 
	public string GeopluginRegionName { get; set; } 

	[XmlElement(ElementName="geoplugin_areaCode")] 
	public object GeopluginAreaCode { get; set; } 

	[XmlElement(ElementName="geoplugin_dmaCode")] 
	public object GeopluginDmaCode { get; set; } 

	[XmlElement(ElementName="geoplugin_countryCode")] 
	public string GeopluginCountryCode { get; set; } 

	[XmlElement(ElementName="geoplugin_countryName")] 
	public string GeopluginCountryName { get; set; } 

	[XmlElement(ElementName="geoplugin_inEU")] 
	public int GeopluginInEU { get; set; } 

	[XmlElement(ElementName="geoplugin_euVATrate")] 
	public object GeopluginEuVATrate { get; set; } 

	[XmlElement(ElementName="geoplugin_continentCode")] 
	public string GeopluginContinentCode { get; set; } 

	[XmlElement(ElementName="geoplugin_continentName")] 
	public string GeopluginContinentName { get; set; } 

	[XmlElement(ElementName="geoplugin_latitude")] 
	public double GeopluginLatitude { get; set; } 

	[XmlElement(ElementName="geoplugin_longitude")] 
	public double GeopluginLongitude { get; set; } 

	[XmlElement(ElementName="geoplugin_locationAccuracyRadius")] 
	public int GeopluginLocationAccuracyRadius { get; set; } 

	[XmlElement(ElementName="geoplugin_timezone")] 
	public string GeopluginTimezone { get; set; } 

	[XmlElement(ElementName="geoplugin_currencyCode")] 
	public string GeopluginCurrencyCode { get; set; } 

	[XmlElement(ElementName="geoplugin_currencySymbol")] 
	public string GeopluginCurrencySymbol { get; set; } 

	[XmlElement(ElementName="geoplugin_currencySymbol_UTF8")] 
	public string GeopluginCurrencySymbolUTF8 { get; set; } 

	[XmlElement(ElementName="geoplugin_currencyConverter")] 
	public double GeopluginCurrencyConverter { get; set; } 
}

