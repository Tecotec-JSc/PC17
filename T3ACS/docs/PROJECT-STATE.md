# PROJECT STATE — PC17 / T3ACS (context để tiếp tục làm việc)

> **Mục đích file này:** nơi Claude (và người mới) đọc đầu mỗi phiên để hiểu nhanh dự án,
> biết đã làm gì, đang ở đâu, và tiếp tục từ chỗ nào. Cập nhật file này sau mỗi mốc công việc.
> Cập nhật lần cuối: 2026-08-20. Trạng thái build: **xanh (0 errors)**.

---

## 1. Dự án là gì
- **PC17** (bản triển khai hiện tại = solution **`T3ACS`**): ứng dụng **desktop .NET 8 Windows Forms**
  tự động hoá kiểm thử/đo lường phần cứng (**DUT** — Device Under Test).
- Mô hình định hướng kiểu **OpenTAP** (Core + plugin: Test Step / Instrument / Result Listener / UI),
  xem `Sơ đồ phân rã mức 0.drawio` và `docs/PC17-Design-Document.md`.
- **Lưu ý:** repo **KHÔNG** dùng OpenTAP thật — chỉ mượn ý tưởng kiến trúc.

## 2. Kiến trúc & project (phụ thuộc một chiều)
```
T3ACS (UI, WinExe net8) ─► T3ACS.Controls, T3ACS.Model, T3ACS.Service
T3ACS.Service ─► T3.CallDevices, T3ACS.Model
T3ACS.Model  ─► T3.Configuration, T3ACS.Data, T3ACS.Util
T3ACS.Data   ─► T3.Configuration              (SQLite)
T3ACS.Controls ─► T3.Configuration, T3ACS.Model
T3.CallDevices (WinExe net8)  — nạp động driver DLL thiết bị (in-process, T3Call)
T3.Configuration              — Main, Session, Logger, Registry, IMain, ThemeManager
T3ACS.Util                    — PasswordHasher, tiện ích
T3.ServerHost (WinExe .NET 4.8) — host thiết bị out-of-process (DỰ PHÒNG, hiện chưa dùng)
T3ACS.FormService             — service biến thể/legacy (trùng vai trò T3ACS.Service)
```
Chi tiết: `docs/03-Kien-truc-thiet-ke.md`.

## 3. Luồng khởi động (Program.cs)
`License → FormLoadScreen (splash ~5s) → FormLogin (đăng nhập) → FormMain`
- Đăng nhập OK ⇒ `FormLogin.login()` set `Main.Permission`, `Session.CurrentUserId`, `Session.CurrentUserName`.
- Không đăng nhập ⇒ thoát app.

## 4. Build & Run (đặc thù môi trường)
- **T3ACS.* (net8):** `dotnet build T3ACS/T3ACS.csproj -c Debug`
- **T3.ServerHost (.NET Framework 4.8):** phải dùng MSBuild:
  `& "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" T3.ServerHost/T3.ServerHost.csproj /t:Build /p:Configuration=Debug`
- Máy này: **không có** `sqlite3` CLI, **không có** `pwsh` (chỉ Windows PowerShell 5.1 — không nạp được assembly .NET 8). Muốn thao tác DB bằng code → viết console net8 tham chiếu `T3ACS.Model` (xem mẫu ở scratchpad `CreateAdmin`).

## 5. Database & tài khoản
- SQLite. Connection = `Main.ConnectionStringSQLite`. Registry `HKCU\SOFTWARE\T3\linkDBSQLite` **chưa set**
  ⇒ mặc định `AppDomain.BaseDirectory + "\T3.db"` = **`T3ACS/bin/Debug/net8.0-windows/T3.db`** (file app đang dùng).
- Còn `Database/T3.db` trong repo (KHÔNG được csproj copy vào bin).
- **Tài khoản đăng nhập:** `Admin` / `123456`, `Permission = "Admin"`, `UserId = 1` (mật khẩu lưu hash).

## 6. Quy tắc làm việc (bắt buộc)
- `CLAUDE.md`: trả lời **tiếng Việt**; giữ định danh code **tiếng Anh**; **không tự sửa file khi chưa yêu cầu**;
  giải thích nguyên nhân+nội dung mỗi khi sửa; **không tự thêm NuGet**; **không đổi kiến trúc**; comment tiếng Việt.
- `CODING_CONVENTION.md`: PascalCase (kể cả `const`), `_camelCase` private field, Allman, ≤120 cột,
  nhóm using (System → third-party → nội bộ), XML doc tiếng Việt cho public ở Service/Model/Data, không code chết,
  magic string/number → const.

## 7. Đã làm trong các phiên gần đây (changelog)
1. **Loading khi chạy procedure**
   - `T3ACS/FormRunLoading.cs`(+Designer): form loading progress+status (dùng `CustomProgressBar`).
   - `FormMainRunStep.RunProcedureId`: mở `FormBlur` (mờ nền, tái dùng cơ chế `ShowFormDialog`) + `FormRunLoading`,
     **giữ hiển thị tối thiểu 1.5s** (chống nháy), đóng trong `finally`.
   - `FormRunMain.RunProcedureId(int, IProgress<(int,string)>=null)`: báo tiến trình mốc 10/60/80/100%.
   - `CustomProgressBar.SetValue(double)` (0..1).
2. **Nạp plugin/driver ổn định kiểu OpenTAP**
   - `T3.CallDevices/T3Call.cs` (net8): `AssemblyLoadContext.Default.LoadFromAssemblyPath` + resolver trung tâm
     (`.Resolving` + `AppDomain.AssemblyResolve`), chuẩn hoá path, dedup theo tên, `lock`, bọc lỗi.
   - `T3.ServerHost/T3Server.cs` (net4.8): class `PluginLoader` (AppDomain.AssemblyResolve + LoadFrom); `FormMain.cs` dùng chung.
   - **Không unload driver in-process** (giống OpenTAP) vì driver trả object sống (Form). Reload thật ⇒ dùng host out-of-process.
3. **Tài liệu**: thư mục `docs/` (00→08) + `docs/PC17-Design-Document.md` (SDD) + `docs/03-Kien-truc-thiet-ke.md`.
4. **Audit "User + timestamp trên mọi entry"**
   - `T3.Configuration/Session.cs`: `CurrentUserId` / `CurrentUserName` toàn cục.
   - `T3ACS.Data/AuditStamp.cs`: chèn `CreatedBy/CreatedAt/ModifiedBy/ModifiedAt` vào INSERT/UPDATE (lấy user từ Session).
   - `T3ACS.Data/SchemaMigration.cs`: **auto ALTER** thêm 4 cột audit khi khởi động (idempotent) cho 8 bảng chính:
     `Procedure, ProcedureDetail, ProcedureVariable, StepType, ResultProcedure, DUT, User, Packages`.
   - Móc migration trong ctor `SQLiteDataBase` (chạy 1 lần/tiến trình).
   - Đã stamp INSERT/UPDATE ở: `ProcedureManager`, `DUTManager`, `UserManager`, `PackageManager`, `ProcedureDetailManager`.
5. **Đăng nhập**
   - `IUserManager.GetByUserName` + `UserManager.GetByUserName`; `UserModel.GetBy` = tra username + `VerifyPassword`.
   - `FormLogin.cs` sửa để compile (dùng `Session`, `FormNotiAll`) + nối vào `Program.cs`.
6. **Sửa build hỏng**: `T3ACS/FormLoadScreen.resx` bị hỏng Base-64 ⇒ thay bằng resx rỗng hợp lệ
   (**mất ảnh nền splash** — gán lại sau nếu cần; `OnPaint` đã null-safe).

## 8. Trạng thái hiện tại
- **Build toàn chuỗi T3ACS: 0 errors.** `T3.ServerHost` build MSBuild OK.
- Đăng nhập Admin/123456 (Permission=Admin) hoạt động (đã verify bằng `UserModel.GetBy`).
- Cột audit đã được thêm vào `bin/.../T3.db` (migration đã chạy).

## 9. TIẾP TỤC TỪ ĐÂU (next steps)
- [x] **Nghiệm thu audit (2026-08-19):** đã verify qua Data layer với `Session.CurrentUserId=1` —
      CREATE ghi `CreatedBy/ModifiedBy=1` + `CreatedAt/ModifiedAt`; UPDATE giữ CreatedAt, đổi ModifiedAt.
      (Còn tuỳ chọn: chạy GUI thật để xác nhận trực quan luồng login → tạo bản ghi.)
- [ ] (Tuỳ chọn) Gán lại ảnh nền cho `FormLoadScreen` (đã mất khi tạo lại resx).
- [ ] (Tuỳ chọn) Điền tiếp tài liệu: ERD SQLite (`docs/PC17-Design-Document.md` §5), Detailed design (§6),
      hướng dẫn viết Driver/Step (`docs/04` §4.4).
- [ ] (Tuỳ chọn) Dọn `T3ACS.FormService` trùng vai trò với `T3ACS.Service`.
- [ ] (Tuỳ chọn) Nếu cần reload driver lúc app chạy: nối lời gọi qua host `T3.ServerHost` (`StartSeverT3`/`T3Client`) rồi restart host.

## 10. Bẫy cần nhớ (gotchas)
- **Người dùng thường sửa file song song trong lúc làm việc** (đã gặp: `FormLogin`, `UserManager`, `FormMainRunStep`).
  ⇒ **Đọc lại file trước khi sửa**, đừng tin bản đọc cũ.
- Migration audit **chỉ** áp cho 8 bảng thực thể chính; **bỏ qua bảng liên kết/junction** (DUTProcedure, VesselProcedure, …) — có chủ đích.
- `Session.CurrentUserId` chỉ được set khi **đăng nhập qua FormLogin**; chạy code ngoài app (console) thì null ⇒ audit ghi user = NULL.
- File thử nghiệm (`RunLoadingDemo`, `CreateAdmin`) nằm ở **scratchpad**, KHÔNG trong repo.
- SQLite `ALTER TABLE` không có `ADD COLUMN IF NOT EXISTS` ⇒ `SchemaMigration` tự kiểm `PRAGMA table_info` trước.
