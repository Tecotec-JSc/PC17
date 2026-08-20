# 04. Tài liệu lập trình viên

## 4.1. Dựng môi trường build
- .NET 8 SDK; Visual Studio 2022 / MSBuild.
- `T3.ServerHost` là .NET Framework 4.8 → cần MSBuild (không build bằng `dotnet` thuần với một số cấu hình).
> TODO: Các bước clone, restore, build solution `T3ACS.sln`; biến môi trường/đường dẫn cần thiết.

## 4.2. Quy ước code
- Trả lời/diễn giải & comment: tiếng Việt. Định danh (class/method/property/API): tiếng Anh.
- Không tự thêm/gỡ NuGet khi chưa được duyệt; giữ nguyên kiến trúc phân lớp.
> TODO: Bổ sung quy ước đặt tên, format, xử lý lỗi/log.

## 4.3. Cấu trúc solution
> TODO: Bảng project & vai trò (tham chiếu 03-Kien-truc-thiet-ke.md §3.2).

## 4.4. Hướng dẫn viết Driver / Step mới
> TODO: Điểm mở rộng, interface cần implement, cách đóng gói DLL driver, đặt vào thư mục nào,
> quy ước tên class/method mà `T3Call.CallFunction` gọi (functionType, functionName).

## 4.5. API/Interface nội bộ
- `IMain` (`T3.Configuration`), `IFormService`/`IFormMainService` (`T3ACS.Service`),
  `IT3Call` (`T3.CallDevices`), `IDataBase` + các `I*Manager` (`T3ACS.Data`).
> TODO: Mô tả từng phương thức chính.

## 4.6. Quy trình Git
> TODO: Branch model, quy ước commit, PR & review, CI (nếu có).
