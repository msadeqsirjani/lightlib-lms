using System;
using System.Collections.Generic;
using System.Linq;
using LightLib.Data.Models;

namespace LightLib.Service.Helpers
{
    public static class DataHelpers
    {

        public static IEnumerable<string> HumanizeBusinessHours(IEnumerable<BranchHours> branchHours)
        {
            return (from time in branchHours
                let day = HumanizeDayOfWeek(time.DayOfWeek)
                let openTime = HumanizeTime(time.OpenTime)
                let closeTime = HumanizeTime(time.CloseTime)
                select $"{day} {openTime} to {closeTime}").ToList();
        }

        private static string HumanizeDayOfWeek(int number) => Enum.GetName(typeof(DayOfWeek), number);

        private static string HumanizeTime(int time) => TimeSpan.FromHours(time).ToString("hh':'mm");
    }
}