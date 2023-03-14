using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022UserArtuhinArsenii
{
    public class Calculations
    {
        public TimeSpan[] startTimes { get; set; }
        public int[] durations { get; set; }
        public TimeSpan beginWorkingTime { get; set; }
        public TimeSpan endWorkingTime { get; set; }
        public int consultationTime { get; set; }


        public Calculations(TimeSpan[] startTimes, int[] durations, TimeSpan beginWorkingTime, TimeSpan endWorkingTime, int consultationTime)
        {
            this.startTimes = startTimes;
            this.durations = durations;
            this.beginWorkingTime = beginWorkingTime;
            this.endWorkingTime = endWorkingTime;
            this.consultationTime = consultationTime;
        }

        public string[] AvailablePeriods()
        {
            List<string> freeTime = new List<string>();
            TimeSpan tmp = beginWorkingTime;
            while(tmp + TimeSpan.FromMinutes(consultationTime) <= endWorkingTime)
            {
                TimeSpan tmp2 = tmp + TimeSpan.FromMinutes(consultationTime);
                bool check = true;
                for (int i = 0; i < startTimes.Length; i++)
                {
                    TimeSpan endConsultationTime = startTimes[i] + TimeSpan.FromMinutes(durations[i]);
                    //if (consultationTime < durations[i])
                    //{
                    //    endConsultationTime = startTimes[i] + TimeSpan.FromMinutes(durations[i]);
                    //}
                    //else
                    //{
                    //    endConsultationTime = startTimes[i] + TimeSpan.FromMinutes(consultationTime);
                    //}
                    //Console.WriteLine($"Время приёма: {startTimes[i].ToString(@"hh\:mm")}-{endConsultationTime.ToString(@"hh\:mm")}");
                    if (tmp >= startTimes[i] && tmp < endConsultationTime)
                    {
                        if (durations[i] != consultationTime)
                        {
                            if (i < startTimes.Length - 1)
                            {
                                if ((startTimes[i + 1] - endConsultationTime).Minutes < consultationTime)
                                {
                                    tmp2 = startTimes[i + 1] + TimeSpan.FromMinutes(durations[i + 1]);
                                    //Console.WriteLine($"1 {tmp.ToString(@"hh\:mm")}");
                                }
                                else
                                {
                                    tmp2 = endConsultationTime;
                                }
                            }
                            else
                            {
                                tmp2 = endConsultationTime;
                                //Console.WriteLine($"2 {tmp2.ToString(@"hh\:mm")}");
                            }
                        }
                        check = false;
                        break;
                    }
                    else if (tmp + TimeSpan.FromMinutes(consultationTime) > startTimes[i] && tmp < endConsultationTime)
                    {
                        tmp2 = endConsultationTime;
                        check = false; break;
                    }
                }
                
                
                if (check)
                {
                    freeTime.Add($"{tmp.ToString(@"hh\:mm")}-{tmp2.ToString(@"hh\:mm")}");
                }
                tmp = tmp2;
            }
            return freeTime.ToArray();
            //return new string[] { beginWorkingTime.ToString(@"hh\:mm") };
        }
    }
}
