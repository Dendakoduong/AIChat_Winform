using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using DTO;

namespace gemini
{
    public class HolidayService
    {
        private readonly List<SolarHoliday> solarHolidays;
        private readonly List<LunarHoliday> lunarHolidays;
        private readonly ChineseLunisolarCalendar lunarCalendar;

        public HolidayService(List<SolarHoliday> solarHolidays, List<LunarHoliday> lunarHolidays)
        {
            this.solarHolidays = solarHolidays;
            this.lunarHolidays = lunarHolidays;
            this.lunarCalendar = new ChineseLunisolarCalendar();
        }

        public string GetTodayHolidayInfo(DateTime today)
        {
            int lunarYear = lunarCalendar.GetYear(today);
            int lunarMonth = lunarCalendar.GetMonth(today);
            int lunarDay = lunarCalendar.GetDayOfMonth(today);

            // Start with the basic date information (both solar and lunar)
            string info = $"{today:dd/MM/yyyy} ({lunarDay}/{lunarMonth} ÂL)";

            // Check today's solar holiday
            var solarHolidayToday = solarHolidays.FirstOrDefault(h => h.d == today.Day && h.m == today.Month);
            if (solarHolidayToday != null)
            {
                info += $" - {solarHolidayToday.i}";
            }
            else
            {
                // Check today's lunar holiday
                var lunarHolidayToday = lunarHolidays.FirstOrDefault(h => h.Day == lunarDay && h.Month == lunarMonth);
                if (lunarHolidayToday != null)
                {
                    info += $" - {lunarHolidayToday.Name} (Âm lịch)";
                }
            }

            return info;
        }
    }
}
