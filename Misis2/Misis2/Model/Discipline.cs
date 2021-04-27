using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misis2.Model
{
    public class Discipline
    {
        public string Name { get; set; }
    }

    public class MaillRoot
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "mark")]
        public bool mark { get; set; }


    }
    /// <summary>
    public class Root
    {
        [JsonProperty(PropertyName = "firstName")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "patronymic")]
        public string patronymic { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "mark")]
        public bool mark { get; set; }
    }
    /// </summary>
    public class NamePerson
    {

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "patronymic")]
        public string Patronymic { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }



    public class SubjectArea
    {
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }

    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
   
    public class TimeFull
    {
        [JsonProperty(PropertyName = "groupName")]
        public string groupName { get; set; }
    }

    public class TimePart
    {
        [JsonProperty(PropertyName = "groupName")]
        public string groupName { get; set; }
    }

    public class Disciplinee
    {
        public List<TimeFull> timeFull { get; set; }
        public List<TimePart> timePart { get; set; }
    }

}
