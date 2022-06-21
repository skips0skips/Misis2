using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misis2.Model
{

    public class Discipline //название дисциплины
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
    }
    public class Name //айди и отметка студента 
    {
        public string id { get; set; }
        public string mark { get; set; }
    }

    public class Enabled //айди и отметка студента 
    {
        public int id { get; set; }
        public bool mark { get; set; }
    }
    public class MaillRoot2 //классы для отправки на сервер данных об отметки
    {
        public List<Name> name { get; set; }
        //public DateTime date { get; set; }
        public string idCode { get; set; }
        public string id { get; set; }
        public string title { get; set; }
    }

    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "patronymic")]
        public string patronymic { get; set; }
    }
    public class MaillRoot
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "mark")]
        public string mark { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string firstName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string lastName { get; set; }
        [JsonProperty(PropertyName = "patronymic")]
        public string patronymic { get; set; }
        [JsonProperty(PropertyName = "data")]
        public DateTime data { get; set; }


    }
    /// <summary>
    public class Root // информация о человеке в группе
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
    public class NamePerson // информация о преподователе
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
    public class TimeFull3 //класс с выбранной группой
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class TimeFull2 //класс для отчета групп
    {
        public string name { get; set; }
        public string idCode { get; set; }
    }

    public class TimeFull //очное отделение
    {
        [JsonProperty(PropertyName = "groupName")]
        public string groupName { get; set; }
    }

    public class TimePart //заочное отделение
    {
        [JsonProperty(PropertyName = "groupName")]
        public string groupName { get; set; }
    }
    //public class ScheduleList
    //{
    //    public List<Schedule> schedulelist { get; set; }
    //    public string name { get; set; }

    //    public bool IsVisible { get; set; }

    //}

    public class ScheduleList
    {
        
        public string date { get; set; }
        public string number { get; set; }
        public string time { get; set; }
        public string group { get; set; }
        public string objectt { get; set; }

    }

    public class Schedule
    {
        public string name { get; set; }
        public string date { get; set; }
        public string number { get; set; }
        public string time { get; set; }
        public string group { get; set; }
        public string objectt { get; set; }

        public List<ScheduleList> schedulelist { get; set; }

        public bool IsVisible { get; set; }

    }
    //public class Disciplinee 
    //{
    //    public List<TimeFull> timeFull { get; set; }
    //    public List<TimePart> timePart { get; set; }
    //}

}
