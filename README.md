# ZLShop - Hệ thống Backend Thương mại Điện tử
Hệ thống **ZLShop-BE** là ứng dụng Backend được xây dựng bằng **.NET 8 Web API**, cung cấp các RESTful APIs cho nền tảng thương mại điện tử ZLShop.

## 🛠 Công nghệ & Thư viện sử dụng
- **Framework**: .NET 8 (ASP.NET Core Web API)
- **Ngôn ngữ**: C#
- **Cơ sở dữ liệu**: MySQL
- **ORM**: Entity Framework Core (`Pomelo.EntityFrameworkCore.MySql`)
- **Xác thực & Phân quyền**: JSON Web Token (JWT Bearer)
- **Mã hóa mật khẩu**: BCrypt.Net-Next
- **Dependency Injection**: Scrutor (Tự động quét và đăng ký các Services)
- **Tài liệu API**: Swagger / OpenAPI

## 📂 Cấu trúc dự án
- `Controllers/`: Chứa các API endpoints để tiếp nhận và xử lý request từ client (Auth, Categories, Products, ProductVariant, Color, Size,...).
- `Models/Entities/`: Chứa cấu trúc dữ liệu và các thực thể Database (User, Role, Permission, Category, Product, ProductVariant, Cart, CartItem, Color, Size,...).
- `Services/`: Chứa các Service xử lý logic nghiệp vụ, giao tiếp với Database (được thiết kế qua pattern Interfaces / Implementations).
- `DTOs/`: Data Transfer Objects - đóng gói dữ liệu đầu vào/đầu ra giữa API và Client.
- `Data/`: Chứa cấu hình ngữ cảnh kết nối `AppDbContext` của Entity Framework.
- `Migrations/`: Lưu trữ lịch sử tạo và cập nhật cấu trúc bảng Database.
- `Exceptions/`: Quản lý và tùy biến xử lý các lỗi ngoại lệ trả về cho người dùng nhanh chóng, an toàn.

## 🏢 Các tính năng / Phân hệ chức năng chính
1. **Xác thực & Phân quyền**:
   - Quản lý tài khoản `User`, `Role`, `Permission`, `UserAddress`, và `RefreshToken`.
   - Cơ chế cấp phát và gia hạn JWT token an toàn.
2. **Sản phẩm & Danh mục**:
   - Quản trị danh mục hệ thống `Category`.
   - Quản lý sản phẩm `Product` và các tùy chọn/biến thể `ProductVariant` (giá, tồn kho theo từng tùy chọn).
   - Quản lý thuộc tính chung như `Color`, `Size`.
3. **Giỏ hàng**:
   - Quản lý quá trình chọn mua hàng của người dùng thông qua `Cart` và `CartItem`.

## 🚀 Hướng dẫn thiết lập & Chạy dự án
1. **Yêu cầu tiên quyết**:
   - Cài đặt [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
   - Cài đặt MySQL Server.
2. **Cấu hình thông tin Kết nối**:
   - Mở file `appsettings.json` (hoặc `appsettings.Development.json`) và thiết lập `DefaultConnection` tới database MySQL của bạn:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Port=3306;Database=ZLShopDb;User=root;Password=YOUR_PASSWORD;"
     }
     ```
3. **Cập nhật Database**:
   - Chạy lệnh sau để apply các thiết lập Migrations và tạo/cập nhật các bảng mới nhất vào database:
     ```bash
     dotnet ef database update
     ```
4. **Khởi động dự án**:
   - Tại thư mục gốc `d:\ZLShop\ZLShop`, chạy lệnh:
     ```bash
     dotnet run
     ```
   - Server sẽ tự động khởi chạy. Bạn có thể truy cập `https://localhost:<port>/swagger` (cổng thực tế hiển thị ở console) để xem giao diện tài liệu API, tương tác và gửi request kiểm thử trực tiếp!
