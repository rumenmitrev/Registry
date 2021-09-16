﻿using System;
using Newtonsoft.Json.Linq;

namespace Registry.Web.Models.DTO
{
    public class MetaDto
    {
        public string Id { get; set; }

        public JObject Data { get; set; }

        public DateTime ModifiedTime { get; set; }
    }
}