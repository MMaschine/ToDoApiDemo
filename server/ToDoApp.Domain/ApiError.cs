﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace ToDoApp.Domain
{
    public class ApiError
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Creates the string that represents the current ApiError
        /// </summary>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });
        }
    }
}
