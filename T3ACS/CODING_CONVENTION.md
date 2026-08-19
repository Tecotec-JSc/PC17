# CODING CONVENTION — T3ACS (C# WinForms .NET)

> File này định nghĩa quy tắc coding convention áp dụng cho toàn bộ project.
> Claude Code và mọi thành viên khi sửa/viết code đều phải tuân theo các quy tắc dưới đây.
> Đây là quy tắc về **style/format**, không phải quy tắc thay đổi logic nghiệp vụ hay kiến trúc
> (xem thêm `CLAUDE.md` cho quy tắc kiến trúc và quy trình làm việc).

---

## 1. Naming Convention

| Đối tượng                     | Quy tắc              | Ví dụ                          |
|--------------------------------|-----------------------|---------------------------------|
| Class, Interface, Enum, Struct | PascalCase            | `DeviceService`, `IDeviceRepository` |
| Interface                      | Bắt đầu bằng `I`      | `IUserService`                 |
| Method                         | PascalCase             | `GetUserById()`                |
| Property                       | PascalCase             | `public string UserName { get; set; }` |
| Public field (hạn chế dùng)    | PascalCase             | `public int MaxRetryCount`     |
| Private field                  | camelCase, prefix `_`  | `private readonly ILogger _logger;` |
| Local variable, parameter      | camelCase              | `int userId`, `string deviceCode` |
| Constant                       | PascalCase             | `const int MaxTimeoutSeconds = 30;` |
| Enum member                    | PascalCase             | `enum DeviceStatus { Online, Offline }` |
| Namespace                      | PascalCase, theo folder| `T3ACS.Service.Device`         |
| File name                      | Trùng tên class chính  | `DeviceService.cs`             |
| WinForms control                | camelCase, prefix theo loại control | `btnSave`, `txtUserName`, `cboDeviceType`, `dgvUsers` |
| Event handler method           | `<Control>_<Event>`    | `btnSave_Click`, `frmMain_Load` |
| Async method                   | Suffix `Async`         | `GetUserByIdAsync()`           |

**Không dùng:**
- Viết tắt tùy tiện (`usr`, `dvc`, `mgr` mơ hồ) — chỉ dùng viết tắt phổ biến, rõ nghĩa (`Id`, `Db`, `Ui`).
- Hungarian notation cho biến thường (không dùng `strName`, `intCount`), **trừ** control WinForms (đã quy ước ở trên).
- Tên class/method/property/variable/API bằng tiếng Việt — **giữ nguyên tiếng Anh** theo `CLAUDE.md`.

---

## 2. Formatting

- **Indentation:** 4 spaces, không dùng tab.
- **Dấu ngoặc `{ }`:** xuống dòng (Allman style) — theo chuẩn mặc định của Visual Studio C#.
  ```csharp
  public void DoSomething()
  {
      if (condition)
      {
          // ...
      }
  }
  ```
- **Độ dài dòng:** khuyến nghị ≤ 120 ký tự.
- **File:** mỗi file chỉ chứa 1 class/interface/enum chính (trừ private nested class hoặc partial class).
- **using directive:** đặt trên đầu file, sắp xếp: `System.*` trước, rồi đến thư viện third-party, rồi đến namespace nội bộ project — mỗi nhóm cách nhau 1 dòng trống.
- **Khoảng trắng:** 1 dòng trống giữa các method, không để nhiều hơn 1 dòng trống liên tiếp.
- **var:** dùng `var` khi kiểu dữ liệu đã rõ ràng từ vế phải; dùng kiểu tường minh khi cần làm rõ ý nghĩa (ví dụ khi gọi method trả về `int`/`bool` mà tên method không rõ nghĩa).

---

## 3. Comment

- **Ngôn ngữ comment:** tiếng Việt (theo `CLAUDE.md` mục 7).
- **XML doc comment** (`/// <summary>`) cho toàn bộ public class, public method, public property trong Service/Model/Data layer — mô tả bằng tiếng Việt.
  ```csharp
  /// <summary>
  /// Lấy thông tin thiết bị theo mã thiết bị.
  /// </summary>
  /// <param name="deviceCode">Mã thiết bị cần tìm.</param>
  /// <returns>Thông tin thiết bị, null nếu không tìm thấy.</returns>
  public async Task<Device?> GetDeviceByCodeAsync(string deviceCode)
  ```
- Comment giải thích **"tại sao"** (why) chứ không lặp lại **"cái gì"** (what) đã quá rõ từ code.
- Không để lại code chết (commented-out code) trong codebase — xóa hẳn, dùng git để lưu lịch sử.
- TODO/FIXME ghi rõ: `// TODO: <mô tả> - <người ghi> - <ngày>`

---

## 4. Async/Await cho thao tác I/O

- **Bắt buộc dùng `async/await`** cho mọi thao tác I/O: gọi database, đọc/ghi file, gọi API/network, giao tiếp thiết bị qua `T3.CallDevices`.
- Method async phải có suffix `Async` và trả về `Task` hoặc `Task<T>` (không trả `void`, trừ event handler).
- **Không block async bằng `.Result` hoặc `.Wait()`** — gây deadlock trong WinForms UI thread.
- Trong event handler WinForms, dùng `async void` **chỉ** cho handler, kèm try-catch đầy đủ vì exception trong `async void` không thể catch từ bên ngoài:
  ```csharp
  private async void btnSave_Click(object sender, EventArgs e)
  {
      try
      {
          btnSave.Enabled = false;
          await _deviceService.SaveDeviceAsync(device);
      }
      catch (Exception ex)
      {
          _logger.LogError(ex, "Lỗi khi lưu thiết bị");
          MessageBox.Show("Không thể lưu thiết bị: " + ex.Message);
      }
      finally
      {
          btnSave.Enabled = true;
      }
  }
  ```
- Dùng `ConfigureAwait(false)` trong Service/Data layer (không cần quay lại UI context); **không** dùng `ConfigureAwait(false)` trong code trực tiếp thao tác UI control.
- Truyền `CancellationToken` cho các thao tác I/O dài (gọi thiết bị, batch xử lý dữ liệu) khi có thể.

---

## 5. Exception Handling

- Không dùng `catch (Exception) { }` (nuốt lỗi im lặng) — luôn log hoặc xử lý cụ thể.
- Bắt exception cụ thể trước, `Exception` chung để cuối cùng (nếu cần).
- Lớp gọi thiết bị (`T3.CallDevices`) phải luôn có xử lý lỗi kết nối/timeout riêng, không để exception phần cứng làm crash toàn UI.
- Không dùng exception để điều khiển luồng logic thông thường (business flow) — chỉ dùng cho tình huống ngoại lệ thật sự.
- Sử dụng `using` / `using var` cho các resource cần dispose (`IDisposable`): connection, stream, v.v.

---

## 6. Kiến trúc & Phân lớp (nhắc lại từ CLAUDE.md)

- **UI** chỉ được gọi xuống **Service**, không gọi thẳng xuống **Data** hay **Model** logic nghiệp vụ.
- **Service** xử lý nghiệp vụ, gọi **Data** để truy xuất dữ liệu và gọi **T3.CallDevices** khi cần thao tác thiết bị.
- **Model** chỉ chứa dữ liệu (entity/DTO), không chứa logic nghiệp vụ phức tạp.
- Không thêm NuGet package mới khi chưa được yêu cầu.
- Không refactor kiến trúc/pattern khi chưa được yêu cầu — kể cả khi đang "dọn code convention".

---

## 7. Null-check & Nullable Reference Type

- Khuyến khích bật `<Nullable>enable</Nullable>` nếu project đã/đang hỗ trợ (kiểm tra trong `.csproj` trước khi áp dụng toàn bộ).
- Kiểm tra null tường minh cho input từ bên ngoài (user input, kết quả gọi thiết bị, dữ liệu từ DB).
- Ưu tiên dùng `?.`, `??`, `??=` thay vì if-else lồng nhau khi phù hợp.

---

## 8. Khác

- **Magic number/string:** đưa vào `const` hoặc `enum` có tên rõ nghĩa, không để số/chuỗi "trần" trong logic.
- **LINQ:** ưu tiên dùng khi làm code rõ ràng hơn, tránh lạm dụng LINQ phức tạp khó đọc trên tập dữ liệu lớn (ảnh hưởng performance).
- **Region (`#region`):** hạn chế dùng để che giấu code dài — nên refactor tách method/class thay vì dùng region để "gọn" giả tạo.

---

## Cách áp dụng convention này cho code cũ

Khi yêu cầu Claude Code sửa code theo convention này:
- Chỉ định rõ **phạm vi** (ví dụ: 1 thư mục/1 layer mỗi lần), không sửa toàn bộ solution trong 1 lệnh.
- Yêu cầu Claude **chỉ sửa style/convention, không đổi logic nghiệp vụ**.
- Luôn `git diff` review sau mỗi lượt sửa trước khi merge tiếp.
