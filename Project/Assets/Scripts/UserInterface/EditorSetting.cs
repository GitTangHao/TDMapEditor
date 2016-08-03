using UnityEngine;
using UnityEditor;
using System.Collections;

using System.IO;
using System.Xml;


public class EditorSetting
{
    static readonly string sFilePath = Application.persistentDataPath + @"/EditorSettings.xml";

    public static bool sDrawTiledFrame;



    public static void Load()
    {
        if (File.Exists(sFilePath))
        {
            string tXmlContent = File.ReadAllText(sFilePath);
            XmlDocument tDoc = new XmlDocument();
            tDoc.LoadXml(tXmlContent);

            sDrawTiledFrame = bool.Parse(tDoc.FirstChild.SelectSingleNode("DrawTiledFrame").Attributes["value"].Value);
        }
        else
        {
            Save(); // create if there is not one.
        }
    }

    public static void Save()
    {
        XmlDocument tDoc = new XmlDocument();
        XmlElement tRoot = tDoc.CreateElement("EdtiorSetting");

        XmlElement tDrawTiledFrame = tDoc.CreateElement("DrawTiledFrame");
        tDrawTiledFrame.SetAttribute("value", sDrawTiledFrame.ToString());
        tRoot.AppendChild(tDrawTiledFrame);

        tDoc.AppendChild(tRoot);

        tDoc.Save(sFilePath);
    }

}
