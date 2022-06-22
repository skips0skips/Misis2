using Misis2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Misis2.ModelView
{
    public class FifthPageModel
    {
        public ObservableCollection<Schedule> Schedsules { get; set; }
       // public List<Schedule> Scheduless { get; set; }
        //public ObservableCollection<ScheduleList> scheduleLists { get; set; }

        private Schedule oldSchedule;
        //private ScheduleList oldScheduleList;
        public FifthPageModel()
        {

            Schedsules = new ObservableCollection<Schedule>
            {
                new Schedule
                {
                    name = "Понедельник",
                    date = "16.05.2022",
                    schedulelist = new List<ScheduleList>
                    {
                        new ScheduleList {
                                            number12 = "1",
                                            time12 =  "08:30-10:15",
                                            group12 = "БПИ-20",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "2",
                                            time12 =  "10:30-12:00",
                                            group12 = "БПИ-20",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "3",
                                            time12 =  "12:45-14:15",
                                            group12 = "БПИ-19",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "4",
                                            time12 =  "14:45-16:20",
                                            group12 = "БПИ-19",
                                            objectt12 ="Информатика" }


                    },

                },
                new Schedule
                {
                    name = "Вторник",
                    date = "17.05.2022",
                    schedulelist = new List<ScheduleList>
                    {
                        new ScheduleList {
                                            number12 = "1",
                                            time12 =  "08:30-10:15",
                                            group12 = "БПИ-18",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "2",
                                            time12 =  "10:30-12:00",
                                            group12 = "БПИ-18",
                                            objectt12 ="Информатика" }


                    },

                },
                new Schedule
                {
                    name = "Среда",
                    date = "18.05.2022",
                    schedulelist = new List<ScheduleList>
                    {
                        new ScheduleList {
                                            number12 = "1",
                                            time12 =  "08:30-10:15",
                                            group12 = "БПИ-19",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "2",
                                            time12 =  "10:30-12:00",
                                            group12 = "БПИ-19",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "3",
                                            time12 =  "12:45-14:15",
                                            group12 = "БПИ-20",
                                            objectt12 ="Информатика" }


                    },

                },
                new Schedule
                {
                    name = "Четверг",
                    date = "19.05.2022",
                    schedulelist = new List<ScheduleList>
                    {
                        new ScheduleList {
                                            number12 = "1",
                                            time12 =  "08:30-10:15",
                                            group12 = "БПИ-20",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "2",
                                            time12 =  "10:30-12:00",
                                            group12 = "БПИ-20",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "3",
                                            time12 =  "12:45-14:15",
                                            group12 = "БПИ-18",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "4",
                                            time12 =  "14:45-16:20",
                                            group12 = "БПИ-18",
                                            objectt12 ="Информатика" }


                    },

                },
                new Schedule
                {
                    name = "Пятница",
                    date = "20.05.2022",
                    schedulelist = new List<ScheduleList>
                    {
                        new ScheduleList {
                                            number12 = "1",
                                            time12 =  "08:30-10:15",
                                            group12 = "БПИ-18",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "2",
                                            time12 =  "10:30-12:00",
                                            group12 = "БПИ-18",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "3",
                                            time12 =  "12:45-14:15",
                                            group12 = "БПИ-19",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "4",
                                            time12 =  "14:45-16:20",
                                            group12 = "БПИ-19",
                                            objectt12 ="Информатика" },
                        new ScheduleList {
                                            number12 = "5",
                                            time12 =  "16:30-18:05",
                                            group12 = "БПИ-20",
                                            objectt12 ="Информатика" }


                    },

                }
            };

            //scheduleLists = new ObservableCollection<ScheduleList>
            //{
            //    new ScheduleList
            //    {
            //        name = "Понедельник",
            //        schedulelist = new List<Schedule>
            //        {
            //            new Schedule
            //            {
            //                 number = "1",
            //                 time =  "14:45-16:20",
            //                 group = "БПИ-19",
            //                 objectt ="Информатика"
            //            }
            //        },

            //    },
            //    new ScheduleList
            //    {
            //        name = "Вторник",
            //        schedulelist = new List<Schedule>
            //        {
            //            new Schedule
            //            {
            //                 number = "1",
            //                 time =  "14:45-16:20",
            //                 group = "БПИ-19",
            //                 objectt ="Информатика"
            //            }
            //        },

            //    }
            //};
        }
        //public void HideOrShowSchedule(ScheduleList schedule)
        //{
        //    if (oldScheduleList == schedule)
        //    {
        //        schedule.IsVisible = !schedule.IsVisible;
        //        UpdateMusic(schedule);
        //    }
        //    else
        //    {
        //        if (oldScheduleList != null)
        //        {
        //            oldScheduleList.IsVisible = false;
        //            UpdateMusic(oldScheduleList);
        //        }
        //        schedule.IsVisible = true;
        //        UpdateMusic(schedule);
        //    }
        //    oldScheduleList = schedule;
        //}
        public void HideOrShowSchedule(Schedule schedule)
        {
            if (oldSchedule == schedule)
            {
                schedule.IsVisible = !schedule.IsVisible;
                UpdateMusic(schedule);
            }
            else
            {
                if (oldSchedule != null)
                {
                    oldSchedule.IsVisible = false;
                    UpdateMusic(oldSchedule);
                }
                schedule.IsVisible = true;
                UpdateMusic(schedule);
            }
            oldSchedule = schedule;
        }
        //public void UpdateMusic(ScheduleList schedule)
        //{
        //    var index = scheduleLists.IndexOf(schedule);
        //    scheduleLists.Remove(schedule);
        //    scheduleLists.Insert(index, schedule);
        //}
        public void UpdateMusic(Schedule schedule)
        {
            var index = Schedsules.IndexOf(schedule);
            Schedsules.Remove(schedule);
            Schedsules.Insert(index, schedule);
        }
    }
}
