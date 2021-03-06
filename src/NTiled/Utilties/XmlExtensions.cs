﻿// ﻿
// Copyright (c) 2013 Patrik Svensson
// 
// This file is part of NTiled.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NTiled
{
    internal static class XmlExtensions
    {
        public static XElement GetDocumentRoot(this XDocument document, string name, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if (document.Root != null)
            {
                var rootName = document.Root.Name.LocalName;
                if (rootName.Equals(name, comparison))
                {
                    return document.Root;
                }
            }
            return null;
        }

        public static bool HasElement(this XElement element, string name, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return GetElement(element, name, comparison) != null;
        }

        public static XElement GetElement(this XElement element, string name, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return element.Elements().FirstOrDefault(e => e.Name.LocalName.Equals(name, comparison));
        }

        public static IEnumerable<XElement> GetElements(this XElement element, string name, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return element.Elements().Where(e => e.Name.LocalName.Equals(name, comparison));
        }

        public static bool HasAttribute(this XElement element, string name)
        {
            if (element != null)
            {
                XAttribute attribute = element.Attribute(name);
                return attribute != null;
            }
            return false;
        }

        public static T ReadAttribute<T>(this XElement element, string name, T defaultValue)
        {
            if (element != null)
            {
                XAttribute attribute = element.Attribute(name);
                if (attribute != null)
                {
                    return attribute.Value.Convert(defaultValue);
                }
            }
            return defaultValue;
        }
    }
}
