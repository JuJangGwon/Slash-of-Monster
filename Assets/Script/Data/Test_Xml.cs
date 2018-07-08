using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;

public class Test_Xml : MonoBehaviour{

    public static List<int> num_tb = new List<int>();
    public static List<int> level_tb = new List<int>();
    public static List<int> gainexp_tb = new List<int>();
    public static List<int> gaingold_tb = new List<int>();
    public static List<int> hp_tb = new List<int>();
    public static List<int> property_tb = new List<int>();

    void Awake () {
        createXML();
    }

    void createXML()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("monsterData");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList num_table = xmlDoc.GetElementsByTagName("num");
        foreach(XmlNode node in num_table)
        {
           num_tb.Add(int.Parse(node.InnerText));
        }

        XmlNodeList level_table = xmlDoc.GetElementsByTagName("level");
        foreach (XmlNode node in level_table)
        {
             level_tb.Add(int.Parse(node.InnerText));

        }
        //

        XmlNodeList gainexp_table = xmlDoc.GetElementsByTagName("gainexp");
        foreach (XmlNode node in gainexp_table)
        {
            gainexp_tb.Add(int.Parse(node.InnerText));
        }
        //

        XmlNodeList gaingold_table = xmlDoc.GetElementsByTagName("gaingold");
        foreach (XmlNode node in gaingold_table)
        {
             gaingold_tb.Add(int.Parse(node.InnerText));
        }
        //

        XmlNodeList hp_table = xmlDoc.GetElementsByTagName("hp");
        foreach (XmlNode node in hp_table)
        {
              hp_tb.Add(int.Parse(node.InnerText));
        }
        //

        XmlNodeList property_table = xmlDoc.GetElementsByTagName("property");
        foreach (XmlNode node in property_table)
        {
        //    property_tb.Add(int.Parse(node.InnerText));
        }
    }
}
