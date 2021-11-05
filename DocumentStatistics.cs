﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab5
{
    [DataContract(Name = "documentStatistics")]
    public class DocumentStatistics
    {
        [DataMember(Name = "documentCount")]
        public int DocumentCount { get; set; }
        [DataMember(Name = "documents")]
        public List<string> Documents { get; set; }
        [DataMember(Name = "wordCount")]
        public Dictionary<string, int> WordCounts { get; set; }
        public DocumentStatistics()
        {
            DocumentCount = 0;
            Documents = new List<string>();
            WordCounts = new Dictionary<string, int>();
        }
    }
}
