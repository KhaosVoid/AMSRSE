using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace AMSRSE.InfoXml
{
    public class BMSSVInfo
    {
        #region Members

        private string _bmssvInfoXmlPath;
        private XmlDocument _bmssvInfoXml;

        #endregion Members

        #region Ctor

        private BMSSVInfo()
        {

        }

        #endregion Ctor

        #region Methods

        public static BMSSVInfo Load(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            BMSSVInfo bmssvInfo = new BMSSVInfo();
            bmssvInfo._bmssvInfoXmlPath = path;
            bmssvInfo._bmssvInfoXml = new XmlDocument();
            bmssvInfo._bmssvInfoXml.Load(path);

            return bmssvInfo;
        }

        public void AddName(string sectionName, uint id, string value = null)
        {
            AddName(sectionName, id.ToString("X8"), value);
        }

        public void AddName(string sectionName, string id, string value = null)
        {
            var section = _bmssvInfoXml.SelectSingleNode($"/BMSSVInfo/{sectionName}");
            var newElement = _bmssvInfoXml.CreateElement("Name");
            var idAttr = _bmssvInfoXml.CreateAttribute("id");
            var valueAttr = _bmssvInfoXml.CreateAttribute("value");

            idAttr.Value = id;
            valueAttr.Value = value;

            newElement.Attributes.Append(idAttr);
            newElement.Attributes.Append(valueAttr);

            section.AppendChild(newElement);

            _bmssvInfoXml.Save(_bmssvInfoXmlPath);
        }

        public string GetName(string sectionName, uint id)
        {
            return GetName(sectionName, id.ToString("X8"));
        }

        public string GetName(string sectionName, string id)
        {
            var element = _bmssvInfoXml.SelectSingleNode($"/BMSSVInfo/{sectionName}/Name[@id='{id}']") as XmlElement;

            return element?.GetAttribute("value");
        }

        public void SetName(string sectionName, uint id, string value)
        {
            SetName(sectionName, id.ToString("X8"), value);
        }

        public void SetName(string sectionName, string id, string value)
        {
            var element = _bmssvInfoXml.SelectSingleNode($"/BMSSVInfo/{sectionName}/Name[@id='{id}']") as XmlElement;

            element.SetAttribute("value", value);

            _bmssvInfoXml.Save(_bmssvInfoXmlPath);
        }

        public void RemoveName(string sectionName, uint id)
        {
            RemoveName(sectionName, id.ToString("X8"));
        }

        public void RemoveName(string sectionName, string id)
        {
            var section = _bmssvInfoXml.SelectSingleNode($"/BMSSVInfo/{sectionName}");
            var element = _bmssvInfoXml.SelectSingleNode($"/BMSSVInfo/{sectionName}/Name[@id='{id}']");

            section.RemoveChild(element);

            _bmssvInfoXml.Save(_bmssvInfoXmlPath);
        }

        #endregion Methods
    }
}
