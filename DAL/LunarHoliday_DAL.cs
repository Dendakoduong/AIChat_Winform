using System;
using System.Collections.Generic;
using DTO;

namespace DAL
{
    public static class LunarHolidays
    {
        public static List<LunarHoliday> GetHolidays()
        {
            return new List<LunarHoliday>
            {
                new LunarHoliday { Day = 1, Month = 1, Name = "Tết Nguyên Đán" },
                new LunarHoliday { Day = 2, Month = 1, Name = "Mùng 2 Tết" },
                new LunarHoliday { Day = 3, Month = 1, Name = "Mùng 3 Tết" },
                new LunarHoliday { Day = 10, Month = 1, Name = "Ngày Vía Thần Tài" },
                new LunarHoliday { Day = 15, Month = 1, Name = "Rằm tháng Giêng (Tết Nguyên Tiêu)" },


                new LunarHoliday { Day = 1, Month = 2, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 2, Month = 2, Name = "Lễ hội miếu Ông Địa" },
                new LunarHoliday { Day = 15, Month = 2, Name = "Ngày rằm" },
                new LunarHoliday { Day = 19, Month = 2, Name = "Lễ hội Quán Thế Âm" },

                new LunarHoliday { Day = 1, Month = 3, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 3, Month = 3, Name = "Tết Hàn Thực" },
                new LunarHoliday { Day = 5, Month = 3, Name = "Tết Thanh Minh" },
                new LunarHoliday { Day = 10, Month = 3, Name = "Giỗ Tổ Hùng Vương" },
                new LunarHoliday { Day = 15, Month = 3, Name = "Ngày rằm" },
                new LunarHoliday { Day = 25, Month = 3, Name = "Ngày Giỗ Tổ Bành Đức" },

                new LunarHoliday { Day = 1, Month = 4, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 15, Month = 4, Name = "Lễ Phật Đản" },
                new LunarHoliday { Day = 15, Month = 4, Name = "Ngày rằm" },
                new LunarHoliday { Day = 25, Month = 4, Name = "Giỗ Gióng" },

                new LunarHoliday { Day = 1, Month = 5, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 5, Month = 5, Name = "Tết Đoan Ngọ" },
                new LunarHoliday { Day = 15, Month = 5, Name = "Ngày rằm" },

                new LunarHoliday { Day = 1, Month = 6, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 15, Month = 6, Name = "Ngày rằm" },
                new LunarHoliday { Day = 24, Month = 6, Name = "Lễ hội Katê" },

                new LunarHoliday { Day = 1, Month = 7, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 7, Month = 7, Name = "Ngày Thất Tịch" },
                new LunarHoliday { Day = 15, Month = 7, Name = "Lễ Vu Lan" },

                new LunarHoliday { Day = 1, Month = 8, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 15, Month = 8, Name = "Tết Trung Thu" },
                new LunarHoliday { Day = 19, Month = 8, Name = "Lễ hội đền Trần" },

                new LunarHoliday { Day = 1, Month = 9, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 15, Month = 9, Name = "Ngày rằm" },

                new LunarHoliday { Day = 1, Month = 10, Name = "Tết Hàn Thực" },
                new LunarHoliday { Day = 14, Month = 10, Name = "Tết Hạ Nguyên" },
                new LunarHoliday { Day = 15, Month = 10, Name = "Tết Trung Nguyên" },

                new LunarHoliday { Day = 1, Month = 3, Name = "Ngày mồng một" },
                new LunarHoliday { Day = 15, Month = 11, Name = "Lễ hội đền Kỳ Cùng" },
                new LunarHoliday { Day = 18, Month = 11, Name = "Lễ hội đền Hùng" },

                new LunarHoliday { Day = 1, Month = 12, Name = "Ngày mồng 1" },
                new LunarHoliday { Day = 15, Month = 12, Name = "Ngày rằm" },
                new LunarHoliday { Day = 23, Month = 12, Name = "Tết ông Công ông Táo" },
                new LunarHoliday { Day = 30, Month = 12, Name = "Lễ Tất Niên, Giao Thừa" }
            };
        }
    }
}
