﻿using System;
using System.Xml;

namespace Habitat.Framework.SitecoreExtensions.Services
{
  public class XmlParserService
  {
    protected static XmlDocument ValidateAndReturnXmlDocument(string xml)
    {
      if (string.IsNullOrEmpty(xml))
        return null;
      var xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(xml);
      if (xmlDocument.FirstChild.Name != "image")
        throw new ArgumentException("Xml is not a valid image");
      return xmlDocument;
    }

    protected static string GetAttribute(XmlNode node, string attributeName)
    {
      return node.Attributes?[attributeName] == null 
        ? string.Empty 
        : node.Attributes[attributeName].Value;
    }
  }
}