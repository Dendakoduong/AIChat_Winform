using DTO;
using System.Collections.Generic;

namespace DAL
{
    public static class LE
    {
        public static List<SolarHoliday> solar = new List<SolarHoliday>
        {
            // January
            new SolarHoliday { d = 1, m = 1, i = "Tết Dương lịch" },
            new SolarHoliday { d = 9, m = 1, i = "Ngày Học sinh - Sinh viên Việt Nam" },
            new SolarHoliday { d = 21, m = 1, i = "Ngày ôm quốc gia" }, 

            // February
            new SolarHoliday { d = 3, m = 2, i = "Ngày thành lập Đảng Cộng sản Việt Nam" },
            new SolarHoliday { d = 4, m = 2, i = "Ngày Thế giới Phòng chống Ung thư" },
            new SolarHoliday { d = 14, m = 2, i = "Ngày lễ Tình nhân (Valentine)" },
            new SolarHoliday { d = 15, m = 2, i = "Ngày Nhận thức Độc thân" },
            new SolarHoliday { d = 27, m = 2, i = "Ngày Thầy thuốc Việt Nam" },

            // March
            new SolarHoliday { d = 3, m = 3, i = "Ngày truyền thống Bộ đội Biên phòng" },
            new SolarHoliday { d = 8, m = 3, i = "Ngày Quốc tế Phụ nữ" },
            new SolarHoliday { d = 12, m = 3, i = "Ngày trồng cây Việt Nam" },
            new SolarHoliday { d = 14, m = 3, i = "Ngày Valentine Trắng" },
            new SolarHoliday { d = 20, m = 3, i = "Ngày Quốc tế Hạnh phúc" },
            new SolarHoliday { d = 26, m = 3, i = "Ngày thành lập Đoàn Thanh niên Cộng sản Hồ Chí Minh" },
            new SolarHoliday { d = 27, m = 3, i = "Ngày Thể thao Việt Nam" },
            new SolarHoliday { d = 31, m = 3, i = "Ngày Sao lưu Thế giới" },

            // April
            new SolarHoliday { d = 1, m = 4, i = "Ngày Cá tháng Tư" },
            new SolarHoliday { d = 14, m = 4, i = "Ngày Valentine Đen" },
            new SolarHoliday { d = 30, m = 4, i = "Ngày Giải phóng miền Nam, thống nhất đất nước" },

            // May
            new SolarHoliday { d = 1, m = 5, i = "Ngày Quốc tế Lao động" },
            new SolarHoliday { d = 3, m = 5, i = "Ngày Tự do Báo chí Thế giới" },
            new SolarHoliday { d = 7, m = 5, i = "Ngày Chiến thắng Điện Biên Phủ" },
            new SolarHoliday { d = 8, m = 5, i = "Ngày Chữ thập đỏ Quốc tế" },
            new SolarHoliday { d = 13, m = 5, i = "Ngày kỷ niệm giải phóng Hải Phòng" },
            new SolarHoliday { d = 15, m = 5, i = "Ngày thành lập Đội Thiếu niên Tiền phong Hồ Chí Minh" },
            new SolarHoliday { d = 19, m = 5, i = "Ngày sinh Chủ tịch Hồ Chí Minh" },
            new SolarHoliday { d = 20, m = 5, i = "Ngày Nhận thức về Khả năng tiếp cận Toàn cầu" }, 

            // June
            new SolarHoliday { d = 1, m = 6, i = "Ngày Quốc tế Thiếu nhi" },
            new SolarHoliday { d = 5, m = 6, i = "Ngày Môi trường Thế giới" },
            new SolarHoliday { d = 18, m = 6, i = "Ngày Quốc tế Người khuyết tật" },
            new SolarHoliday { d = 21, m = 6, i = "Ngày Báo chí Cách mạng Việt Nam" },
            new SolarHoliday { d = 28, m = 6, i = "Ngày Gia đình Việt Nam" },
            new SolarHoliday { d = 30, m = 6, i = "Ngày Tiểu hành tinh" }, 

            // July
            new SolarHoliday { d = 1, m = 7, i = "Ngày Bảo hiểm Y tế Việt Nam" },
            new SolarHoliday { d = 15, m = 7, i = "Ngày truyền thống Thanh niên xung phong" },
            new SolarHoliday { d = 27, m = 7, i = "Ngày Thương binh Liệt sĩ" },
            new SolarHoliday { d = 28, m = 7, i = "Ngày thành lập Công đoàn Việt Nam" },

            // August
            new SolarHoliday { d = 1, m = 8, i = "Ngày Tình bạn" },
            new SolarHoliday { d = 10, m = 8, i = "Ngày vì nạn nhân chất độc màu da cam Việt Nam" },
            new SolarHoliday { d = 19, m = 8, i = "Ngày Cách mạng tháng Tám" },
            new SolarHoliday { d = 20, m = 8, i = "Ngày sinh Chủ tịch Tôn Đức Thắng" },
            new SolarHoliday { d = 25, m = 8, i = "Ngày sinh của Đại tướng Võ Nguyên Giáp" },

            // September
            new SolarHoliday { d = 2, m = 9, i = "Ngày Quốc khánh" },
            new SolarHoliday { d = 5, m = 9, i = "Ngày Khai giảng cả nước" },
            new SolarHoliday { d = 7, m = 9, i = "Ngày thành lập Đài Tiếng nói Việt Nam" },
            new SolarHoliday { d = 10, m = 9, i = "Ngày thành lập Mặt trận Tổ quốc Việt Nam" },
            new SolarHoliday { d = 21, m = 9, i = "Ngày Hòa bình Thế giới" }, 

            // October 
            new SolarHoliday { d = 1, m = 10, i = "Ngày Quốc tế Người cao tuổi" },
            new SolarHoliday { d = 10, m = 10, i = "Ngày Giải phóng Thủ đô" },
            new SolarHoliday { d = 10, m = 10, i = "Ngày Truyền thống Luật sư Việt Nam" },
            new SolarHoliday { d = 13, m = 10, i = "Ngày Doanh nhân Việt Nam" },
            new SolarHoliday { d = 14, m = 10, i = "Ngày thành lập Hội Nông dân Việt Nam" },
            new SolarHoliday { d = 15, m = 10, i = "Ngày Truyền thống Hội Liên hiệp Thanh niên Việt Nam" },
            new SolarHoliday { d = 20, m = 10, i = "Ngày Phụ nữ Việt Nam" },
            new SolarHoliday { d = 23, m = 10, i = "Ngày Mol" },
            new SolarHoliday { d = 26, m = 10, i = "Ngày Điều dưỡng Việt Nam" },
            new SolarHoliday { d = 31, m = 10, i = "Lễ hội Halloween" },

            // November
            new SolarHoliday { d = 9, m = 11, i = "Ngày Pháp luật Việt Nam" },
            new SolarHoliday { d = 11, m = 11, i = "Ngày lễ độc thân" },
            new SolarHoliday { d = 18, m = 11, i = "Ngày thành lập Mặt trận Tổ quốc Việt Nam" },
            new SolarHoliday { d = 20, m = 11, i = "Ngày Nhà giáo Việt Nam" },
            new SolarHoliday { d = 23, m = 11, i = "Ngày thành lập Hội chữ thập đỏ Việt Nam" },
            new SolarHoliday { d = 28, m = 11, i = "Lễ Tạ ơn" },

            // December
            new SolarHoliday { d = 1, m = 12, i = "Ngày Thế giới phòng chống bệnh AIDS" },
            new SolarHoliday { d = 3, m = 12, i = "Ngày Quốc tế Người khuyết tật" },
            new SolarHoliday { d = 6, m = 12, i = "Ngày Hội Cựu chiến binh Việt Nam" },
            new SolarHoliday { d = 10, m = 12, i = "Ngày Nhân quyền Quốc tế" },
            new SolarHoliday { d = 19, m = 12, i = "Ngày Toàn quốc Kháng chiến" },
            new SolarHoliday { d = 22, m = 12, i = "Ngày thành lập Quân đội Nhân dân Việt Nam" },
            new SolarHoliday { d = 24, m = 12, i = "Lễ Giáng Sinh" },

        };
    }
}
