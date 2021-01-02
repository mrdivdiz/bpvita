using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public class AchievementData : Singleton<AchievementData>
{
    public string FileName
    {
        get
        {
            return this.m_fileName;
        }
        set
        {
            this.m_fileName = value;
        }
    }

    private void OnApplicationPause(bool paused)
    {
        if (paused)
        {
            this.Save();
        }
    }

    public void Save()
    {
        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
        xmlWriterSettings.Indent = true;
        xmlWriterSettings.IndentChars = "  ";
        xmlWriterSettings.NewLineChars = "\r\n";
        xmlWriterSettings.NewLineHandling = NewLineHandling.Replace;
        xmlWriterSettings.Encoding = Encoding.UTF8;
        MemoryStream memoryStream = new MemoryStream();
        XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("data");
        foreach (KeyValuePair<string, AchievementDataHolder> keyValuePair in this.m_achievementData)
        {
            xmlWriter.WriteStartElement("Achievement");
            xmlWriter.WriteAttributeString("id", keyValuePair.Key);
            xmlWriter.WriteAttributeString("progress", keyValuePair.Value.progress.ToString());
            xmlWriter.WriteAttributeString("completed", keyValuePair.Value.completed.ToString());
            xmlWriter.WriteAttributeString("synced", keyValuePair.Value.synced.ToString());
            xmlWriter.WriteEndElement();
        }
        xmlWriter.WriteEndElement();
        xmlWriter.WriteEndDocument();
        xmlWriter.Close();
        byte[] array = memoryStream.ToArray();
        if (!this.m_useEncryption)
        {
            FileStream fileStream = new FileStream(this.m_fileName, FileMode.Create);
            fileStream.Write(array, 0, array.Length);
            fileStream.Close();
        }
        else
        {
            byte[] array2 = this.m_crypto.Encrypt(array);
            byte[] array3 = CryptoUtility.ComputeHash(array2);
            FileStream fileStream2 = new FileStream(this.m_fileName, FileMode.Create);
            fileStream2.Write(array3, 0, array3.Length);
            fileStream2.Write(array2, 0, array2.Length);
            fileStream2.Close();
        }
    }

    public bool Load()
    {
        if (!File.Exists(this.m_fileName))
        {
            return false;
        }
        try
        {
            FileStream fileStream = new FileStream(this.m_fileName, FileMode.Open);
            byte[] array = new byte[fileStream.Length];
            fileStream.Read(array, 0, array.Length);
            fileStream.Close();
            byte[] buffer;
            if (this.m_useEncryption)
            {
                if (array.Length < 20)
                {
                    throw new IOException("Corrupted data file: could not read hash");
                }
                byte[] array2 = this.m_crypto.ComputeHash(array, 20, array.Length - 20);
                for (int i = 0; i < 20; i++)
                {
                    if (array2[i] != array[i])
                    {
                        throw new IOException("Corrupted data file");
                    }
                }
                buffer = this.m_crypto.Decrypt(array, 20);
            }
            else
            {
                buffer = array;
            }
            MemoryStream stream = new MemoryStream(buffer);
            this.LoadXml(stream);
            return true;
        }
        catch
        {
        }
        return false;
    }

    private void LoadXml(Stream stream)
    {
        XDocument xdocument = XDocument.Load(stream);
        this.m_achievementData.Clear();
        foreach (XElement xelement in xdocument.Element("data").Elements("Achievement"))
        {
            XAttribute xattribute = xelement.Attribute("id");
            XAttribute xattribute2 = xelement.Attribute("progress");
            XAttribute xattribute3 = xelement.Attribute("completed");
            XAttribute xattribute4 = xelement.Attribute("synced");
            AchievementDataHolder adh;
            if (xattribute2 != null)
            {
                double.TryParse(xattribute2.Value, out adh.progress);
            }
            else
            {
                adh.progress = 0.0;
            }
            if (xattribute3 != null)
            {
                bool.TryParse(xattribute3.Value, out adh.completed);
            }
            else
            {
                adh.completed = false;
            }
            if (xattribute4 != null)
            {
                bool.TryParse(xattribute4.Value, out adh.synced);
            }
            else
            {
                adh.synced = false;
            }
            this.SetAchievement(xattribute.Value, adh);
        }
    }

    public void SetAchievement(string id, AchievementDataHolder adh)
    {
        this.m_achievementData[id] = adh;
        this.Save();
    }

    public AchievementDataHolder GetAchievement(string id)
    {
        if (this.m_achievementData.ContainsKey(id))
        {
            return this.m_achievementData[id];
        }
        return default(AchievementDataHolder);
    }

    public Dictionary<string, AchievementDescriptor> AchievementsLimits
    {
        get
        {
            return this.m_achievementLimits;
        }
    }

    public Dictionary<string, double> AchievementsProgress
    {
        get
        {
            Dictionary<string, double> dictionary = new Dictionary<string, double>();
            foreach (KeyValuePair<string, AchievementDataHolder> pair in this.m_achievementData)
            {
                dictionary.Add(pair.Key, pair.Value.progress);
            }
            return dictionary;
        }
    }

    private void InitializeAchievementLimits()
    {
        foreach (AchievementDescriptor achievementDescriptor in this.m_achievementList)
        {
            this.m_achievementLimits.Add(achievementDescriptor.id, achievementDescriptor);
        }
        this.m_limitsInitialized = true;
    }

    public int GetAchievementLimit(string id)
    {
        if (!this.m_limitsInitialized)
        {
            this.InitializeAchievementLimits();
        }
        AchievementDescriptor achievementDescriptor;
        if (this.m_achievementLimits.TryGetValue(id, out achievementDescriptor))
        {
            return (int)achievementDescriptor.limit;
        }
        throw new KeyNotFoundException("Non-existant achievement: " + id);
    }

    private void Awake()
    {
        base.SetAsPersistant();
        this.m_fileName = Application.persistentDataPath + "/Achievements.xml";
        this.m_useEncryption = true;
        this.m_crypto = new CryptoUtility("fHHg5#%3RRfnJi78&%lP?65");
        this.InitializeAchievementLimits();
        bool flag = !this.Load();
        if (flag)
        {
            foreach (KeyValuePair<string, AchievementDescriptor> keyValuePair in this.m_achievementLimits)
            {
                AchievementDataHolder value;
                value.progress = 0.0;
                value.completed = false;
                value.synced = false;
                this.m_achievementData.Add(keyValuePair.Key, value);
            }
            this.Save();
        }
    }

    private bool m_limitsInitialized;

    private string m_fileName;

    private bool m_useEncryption;

    private CryptoUtility m_crypto;

    private Dictionary<string, AchievementDataHolder> m_achievementData = new Dictionary<string, AchievementDataHolder>();

    [SerializeField]
    private List<AchievementDescriptor> m_achievementList = new List<AchievementDescriptor>();

    private Dictionary<string, AchievementDescriptor> m_achievementLimits = new Dictionary<string, AchievementDescriptor>();

    public struct AchievementDataHolder
    {
        public double progress;

        public bool completed;

        public bool synced;
    }

    [Serializable]
    public class AchievementDescriptor
    {
        public string id;

        public string iconFileName;

        public double limit;

        public double debugLimit;
    }
}
