# PHÂN TÍCH SÂU PROJECT T3ACS

> Tài liệu phân tích kiến trúc & chất lượng codebase. Chỉ mang tính báo cáo — không phản ánh thay đổi code.
> Ngày lập: 2026-08-18.

## Mục lục
1. [Cấu trúc tổng quan](#1-cấu-trúc-tổng-quan)
2. [Phân tích từng layer](#2-phân-tích-từng-layer)
3. [Pattern & kiến trúc](#3-pattern--kiến-trúc)
4. [Chất lượng code](#4-chất-lượng-code)
5. [NuGet packages](#5-nuget-packages)
6. [Tổng kết](#6-tổng-kết)

---

## 1. CẤU TRÚC TỔNG QUAN

### 1.1. Danh sách project con (10 project trong `T3ACS.sln`)

| Project | Loại | Target | Vai trò |
|---|---|---|---|
| **T3ACS** | WinExe | net8.0-windows | Ứng dụng UI chính + entry point |
| **T3ACS.Controls** | Library | net8.0-windows | Thư viện custom WinForms control |
| **T3ACS.Service** | WinExe* | net8.0-windows | Lớp điều phối nghiệp vụ giữa UI và Model/Device |
| **T3ACS.Model** | Library | net8.0-windows | Model nghiệp vụ + ViewModel/DTO |
| **T3ACS.Data** | Library | net8.0-windows | Lớp truy cập dữ liệu SQLite |
| **T3ACS.Util** | Library | net8.0-windows | Tiện ích file/XML, validate đo lường |
| **T3.Configuration** | Library | net8.0-windows | Cấu hình toàn cục, Registry, theme |
| **T3.CallDevices** | WinExe* | net8.0-windows | Lớp gọi thiết bị (reflection + named-pipe client) |
| **T3.ServerHost** | WinExe | **.NET Framework 4.8** | Process riêng host named-pipe, load DLL thiết bị |
| **T3ACS.FormService** | WinExe | net8.0 | Stub gần như rỗng (`Application.Run()`) |

\* Một số library bị đặt nhầm `OutputType=WinExe` với `Main` rỗng — là scaffolding thừa, không phải exe thật.

### 1.2. Quan hệ reference giữa các project

- `T3ACS` → `T3ACS.Controls`, `T3ACS.Model`, `T3ACS.Service`
- `T3ACS.Service` → `T3.CallDevices`, `T3ACS.Model`
- `T3ACS.Model` → `T3ACS.Data`, `T3ACS.Util`, `T3.Configuration`
- `T3ACS.Data` → `T3.Configuration`
- `T3ACS.Controls` → `T3.Configuration`, `T3ACS.Model`
- `T3.CallDevices` → *(không reference project nào — độc lập)*
- `T3.ServerHost` → `T3ACS.Model` *(nhưng KHÔNG ai reference nó — nó bị khởi chạy như process con qua tên file `T3.ServerHost.exe`)*

### 1.3. Sơ đồ luồng phụ thuộc

```
┌─────────────────────────────────────────────────────────────┐
│                          T3ACS (UI)                          │
│   FormMain, FormRunMain, FormTableInspections, StepDefault/  │
└───────────┬───────────────────────────┬─────────────────────┘
            │ dùng                       │ dùng
            ▼                            ▼
   ┌─────────────────┐         ┌───────────────────┐
   │ T3ACS.Controls  │         │   T3ACS.Service   │
   │ (custom control)│         │ FormService,      │
   └────────┬────────┘         │ FormMainService   │
            │                  └─────┬───────────┬──┘
            │                        │           │
            ▼                        ▼           ▼
   ┌─────────────────┐      ┌──────────────┐  ┌────────────────────┐
   │  T3ACS.Model    │◄─────┤              │  │  T3.CallDevices    │
   │ ProcedureModel, │      │              │  │ T3Call (reflection)│
   │ DUTModel...     │      └──────────────┘  │ T3Client (pipe)    │
   └────────┬────────┘                        └─────────┬──────────┘
            │ dùng                                       │ named pipe (JSON)
            ▼                                            ▼
   ┌─────────────────┐                        ┌────────────────────┐
   │   T3ACS.Data    │                        │  T3.ServerHost     │
   │ SQLiteDataBase, │                        │ (.NET 4.8, process │
   │ *Manager        │                        │  riêng) → load DLL │
   └────────┬────────┘                        │  thiết bị          │
            │                                 └─────────┬──────────┘
            ▼                                           ▼
   ┌─────────────────┐                        ┌────────────────────┐
   │  SQLite (T3.db) │                        │ DLL thiết bị (.dll)│
   └─────────────────┘                        └────────────────────┘

  Xuyên suốt: T3.Configuration (Main static, Registry, Theme) — dùng bởi mọi layer
```

> **Lưu ý quan trọng:** Luồng lý tưởng `UI → Service → Model → Data → T3.CallDevices` **không đúng hoàn toàn với thực tế**. `T3.CallDevices` không nằm *sau* Data mà là một nhánh song song do Service gọi. Đồng thời một số Form ở UI gọi thẳng Model, và có Form tự thực hiện reflection (chi tiết ở mục 3.2).

---

## 2. PHÂN TÍCH TỪNG LAYER

### 2.1. UI (project `T3ACS`, ~50 Form)

Kiến trúc **WinForms cổ điển, mỗi màn hình một Form**, không dùng MVVM/MVP thực sự (thư mục `Controller`/`ViewModel` tồn tại nhưng `FMainController` rỗng).

| Form/Control | Chức năng | Cách gọi xuống dưới |
|---|---|---|
| `Program.cs` | Entry point: check license → splash → shell | Gọi `Main.LoadVariablesFromRegistry`, `LicenseModel` |
| `FormMain` (khai báo trong `FormMainRunStep.cs`) | Shell chính, menu tool động, host các Form con | `IFormMainService` (`GetTools`, `CallTool`) |
| `FormRunMain` (**1.410 dòng**) | Engine chạy procedure theo từng step | `IFormService.CallFunctionLoad/Save/Stop/CallFunction` |
| `FormTableInspections` (1.043) | Danh sách/quản lý procedure, inspection | Qua Model |
| `FormDUTManager` (840) | Quản lý DUT (thiết bị kiểm thử) | `DUTModel` |
| `FormEditProcedure` (803) | Soạn/sửa procedure | Model + Service |
| `FormCreateStepType` (710) | Tạo loại step | Model |
| `CreateFunction` (671) | Cấu hình hàm gọi thiết bị cho step | Service |
| `FormulaEvaluator` (647) | Engine tính biểu thức cho step Calculation | Nội bộ |
| `StepDefault/FormEvaluate*` | Các màn hình thực thi từng loại step (Number, Boolean, String, Calculation, Correction, DUTInformation, Report, BrowserURL, FileAttach…) | `IFormService` |
| `FormBrowser`, `FormLoadBrowserURL` | Nhúng WebView2 | Có dùng async |

Cách gọi điển hình: Form giữ một tham chiếu `IFormService _service` hoặc `IFormMainService _service`, rồi gọi các method `CallFunction*`. Riêng `FormEvaluateCorrection` **tự cài lại** logic reflection `CallFunction` (vi phạm layer — xem mục 3.2/4.1).

### 2.2. Service (project `T3ACS.Service`)

| Class/Interface | Trách nhiệm |
|---|---|
| `IFormService` / `FormService` | Điều phối việc chạy step: `CallFunctionLoad/Save/Stop`, `CallFunction` (gọi thiết bị qua `T3Call`), `ExportReport` (xuất Excel/PDF qua `ExcelModel` + `FileServices`). Có method `ConvertFromVariable` map biến theo type (`Float/Int/Double/String/Boolean/PathFile`). |
| `IFormMainService` / `FormMainService` | Quản lý tool menu: `GetTools` (qua `PackageModel`), `CallTool` (parse chuỗi `Content` bằng `Split(',')` rồi reflection-invoke qua `T3Call`). |

Nhận xét: Service **trộn nhiều trách nhiệm** — vừa gọi thiết bị (reflection), vừa xuất báo cáo (Excel/PDF), vừa map/convert dữ liệu. `FormService.CallFunctionSave` chứa một khối `switch` type dài lặp lại nhiều lần.

### 2.3. Model (project `T3ACS.Model`)

Gồm 2 nhóm: **Model** (bọc Manager của Data) và **ViewModel/DTO** (đối tượng truyền dữ liệu).

- **Model**: `ProcedureModel`, `DUTModel`, `UserModel`, `PackageModel`, `LicenseModel`, `ExcelModel`, `ExcelOpenXml`. Mỗi Model `new` trực tiếp một Manager của Data (ví dụ `ProcedureModel` tạo `ProcedureManager` + `ProcedureDetailManager`), rồi ánh xạ `DataTable` → ViewModel.

- **Quan hệ entity chính** (xoay quanh Procedure — cấu trúc lồng nhau):
  ```
  ProcedureViewModel (1 procedure/template)
   ├─ ProcedureInfoViewModel        (metadata)
   ├─ ProcedureVariableViewModel[]  (biến toàn cục của procedure)
   └─ ProcedureDetailViewModel[]    (các STEP)
        ├─ ProcedureDetaiVariableViewModel[]     (biến của step)
        ├─ ProcedureDetailValueViewModel[]       (giá trị đo/nhập)
        │     └─ ValueInputFromDetailViewModel[]
        └─ ProcedureDetailFunction[]             (hàm gọi thiết bị)
              ├─ ProcedureDetailFunctionValue[]  (Input/Output map)
              └─ ProcedureDetailFunctionVariable[]
  ```
  - `TemplateViewModel`/`TableProcedureViewModel` là model runtime mà engine `FormRunMain` dùng khi chạy.
  - `DUTViewModel`/`TenDUTViewModel`, `UserViewModel`, `PackageViewModel`/`ToolsViewModel`, `CorrectionViewModel`, `ConfigurationViewModel` là các nhóm phụ.
- Điểm yếu: nhiều property kiểu `string` cho dữ liệu số (`Min`, `Max`, `Value`), và có lỗi chính tả trong tên định danh (`ProcedureDetaiVariableViewModel`, `Averate`, `Extesnion`, `Packgage`, `Interger`) — khó sửa sau này vì đã lan rộng.

### 2.4. Data (project `T3ACS.Data`)

- **Công nghệ**: ADO.NET thuần với `Microsoft.Data.Sqlite` (KHÔNG dùng ORM, dù có tham chiếu `SQLiteNetExtensions` — gần như không dùng).
- **Pattern**: Kiểu **Manager-per-entity** (gần giống Repository nhưng không có interface Repository thống nhất, không có Unit of Work, không có transaction). Mỗi Manager (`ProcedureManager` 449 dòng, `ProcedureDetailManager`, `DUTManager`, `UserManager`, `PackageManager`, `ConfigurationManager`) tự `new SQLiteDataBase()`.
- **`SQLiteDataBase : IDataBase`**: bọc thao tác `ExecuteInsert/ExecuteNonQuery/GetDataTable/Insert/Update/Delete`, mở/đóng connection mỗi lần gọi. Có sẵn cơ chế **parameterized** (`SqliteParameter`) và bộ dựng SQL `CoreSelect/` (`SQLSelect`, `SQLFilter`, `SQLRelation`, `SQLWhereClause`).
- **Vấn đề lớn**: Phần lớn Manager **bỏ qua cơ chế parameterized** và **nối chuỗi SQL trực tiếp** với input người dùng (xem `UserManager`, `ProcedureManager`). Cơ chế `checkDLL` (so khớp một GUID cứng) khiến nhiều method âm thầm trả về `-1`/`null` nếu chưa set GUID. `GetDataTable` chỉ chặn ghi bằng cách `.Contains("update"/"insert"/...)` — rất dễ bị lách và dễ false-positive.

### 2.5. T3.CallDevices — giao tiếp thiết bị phần cứng

Thiết bị được nạp dưới dạng **DLL ngoài** và gọi bằng **reflection**. Có **2 cơ chế song song**:

**Cơ chế A — Reflection in-process (đang dùng thực tế):**
- `T3Call` (Singleton, implement `IT3Call`): `Assembly.LoadFrom(pathDll)` → `Activator.CreateInstance(type)` → `MethodInfo.Invoke(obj, var)`, có cache assembly/type qua `AssembyViewModel`/`TypeViewModel`.
- Luồng: `FormRunMain` → `IFormService.CallFunctionLoad/Save/Stop` → `FormService.CallFunction` → `T3Call.Instance.CallFunction(pathDll, function, "Assembly.Type", vars)`.
- Cấu hình mỗi hàm thiết bị lưu trong DB: `{PathDll, Assembly, AssemblyType, Function/Value, FunctionVariables}` với các type `LoadView / SaveData / Stop / Run…`.

**Cơ chế B — Named pipe out-of-process (dành cho DLL .NET Framework cũ):**
- `T3Client.Invoke<T>()` serialize `InvokeRequest` (JSON) qua `NamedPipeClientStream`, đọc `InvokeResponse`.
- `T3.ServerHost` (process .NET 4.8, được `StartSeverT3` khởi chạy bằng `Process.Start("T3.ServerHost.exe")`) nhận request, cũng `Assembly.LoadFrom` + reflection-invoke rồi trả JSON.

**Điểm bất nhất nghiêm trọng giữa 2 cơ chế** (rủi ro treo/không kết nối):
- `StartSeverT3` kiểm tra process tên `"T3"` nhưng lại khởi chạy `T3.ServerHost.exe`.
- `T3Client` kết nối pipe tên `"T3"` trong khi `T3Server` lắng nghe trên `"T3.ServerHost"`.
- `T3Server` xử lý **1 request / vòng lặp** (không đồng thời), ghi lỗi cứng vào `D:\T3Error.txt`.

---

## 3. PATTERN & KIẾN TRÚC

### 3.1. Các design pattern đang áp dụng

| Pattern | Nơi dùng | Nhận xét |
|---|---|---|
| **Singleton** | `T3Call.Instance` | Trạng thái toàn cục, khó test |
| **Layered architecture** | UI/Service/Model/Data | Có phân lớp về ý tưởng nhưng lỏng lẻo (mục 3.2) |
| **Manager/Repository (biến thể)** | `*Manager` trong Data | Không có interface Repository chung, không Unit of Work |
| **Interface segregation (một phần)** | `IFormService`, `IFormMainService`, `IDataBase`, `IT3Call`, `I*Manager` | Có interface nhưng vẫn `new` trực tiếp implementation |
| **Plugin/Reflection invocation** | `T3Call`, `T3Server` | Nạp DLL động theo cấu hình DB |
| **Facade (nhẹ)** | Model bọc Manager | |
| **Static global config** | `T3.Configuration.Main` | Anti-pattern (global mutable state) |

**KHÔNG có**: Dependency Injection container (mọi phụ thuộc đều `new` cứng), Factory thực sự, Observer/event bus, Unit of Work, async pattern ở tầng dữ liệu.

### 3.2. Mức độ tuân thủ phân lớp — **có vi phạm layer**

1. **UI tự làm việc của lớp Device**: `FormEvaluateCorrection` (dòng 76+) **tự cài lại** `CallFunction` với `Assembly.LoadFrom`/`Activator`/`MethodInfo` — đáng lẽ phải qua Service/`T3.CallDevices`. Đây là code trùng lặp và phá vỡ phân lớp.
2. **UI gọi thẳng Model**: nhiều Form (`FormDUTManager` → `DUTModel`, các Form tạo procedure → Model) bỏ qua Service. Không nhất quán: có luồng qua Service, có luồng đi thẳng Model.
3. **Model gắn cứng Data**: Model `new` trực tiếp Manager cụ thể (không inject) → không thay được implementation, khó test.
4. **`checkDLL` (GUID) nằm ở Data** nhưng logic license lại ở Model (`LicenseModel`) và Configuration — trách nhiệm bảo mật bị phân tán.
5. **UI trực tiếp đọc `T3.Configuration.Main`** (biến static) — mọi layer đều phụ thuộc global state.

Kết luận: phân lớp mang tính **quy ước, không được cưỡng chế**. Không có rào cản nào ngăn UI chạm Data/Device.

---

## 4. CHẤT LƯỢNG CODE

### 4.1. Code trùng lặp / God Class / method quá dài

- **God Class / God Form**:
  - `FormRunMain` — **1.410 dòng** (trộn UI + điều phối + gọi thiết bị + nghiệp vụ).
  - `FormTableInspections` — 1.043 dòng.
  - `FormDUTManager` — 840 dòng; `FormEditProcedure` — 803; `FormCreateStepType` — 710.
  - `ProcedureManager` — 449 dòng (Data).
- **Code trùng lặp rõ rệt**:
  - Logic reflection `CallFunction` xuất hiện ở **3 nơi**: `T3Call`, `T3Server`, và bản copy trong `FormEvaluateCorrection`.
  - Khối `switch(type)` map `Float/Int/Double/String/Boolean/List` bị lặp trong `FormService.CallFunctionSave` và `ConvertFromVariable`.
  - Mẫu `GetMax/GetMin/GetCountInDataTable` trong `SQLiteDataBase` gần như copy-paste.
- **Method dài**: `FormService.CallFunctionSave` (~85 dòng với switch lồng), `SQLiteDataBase.Update` (~60 dòng dựng SQL thủ công).

### 4.2. Thiếu xử lý exception / thiếu async

- **Nuốt exception**: `GetDataTable`, nhiều `Insert/Update/Delete` trong Manager dùng `catch { return 0/false/null; }` — **che giấu lỗi**, rất khó debug. `ExecuteNonQuery` dùng `throw ex;` (reset stack trace, nên dùng `throw;`).
- **Thiếu async/await hoàn toàn ở I/O nặng**: Toàn bộ truy cập DB (`SQLiteDataBase`), file (`ExportReport`, `FileServices`), và gọi thiết bị (`T3Call`, pipe `T3Client.Connect(3000)`) đều **đồng bộ**, chạy trên UI thread → dễ **treo UI** khi thiết bị/DB chậm. `async/await` chỉ xuất hiện ở vài Form liên quan WebView2 (`FormBrowser`, `FormLoadBrowserURL`, `FormLoadScreen`).
- **Không có transaction**: chuỗi insert Procedure + Detail + Variable không bọc transaction → dễ dữ liệu dở dang nếu lỗi giữa chừng.
- **Không quản lý vòng đời tài nguyên nhất quán**: mở/đóng connection thủ công trong `try/finally` (ổn), nhưng `GetDataTable(SQLSelect)` gọi `reader.Close()` trong `finally` khi `reader` có thể `null` → nguy cơ NRE.

### 4.3. Magic string / magic number cần refactor

- **Chuỗi type nghiệp vụ rải rác**: `"LoadView"`, `"SaveData"`, `"Stop"`, `"Prepare"`, `"Run"`, `"Float"/"Integer"/"Double"/"String"/"Boolean"/"PathFile"` — lặp khắp Service/UI, nên chuyển thành `enum`/hằng số.
- **GUID cứng**: `"{49D91D63-B25D-415D-8ACA-B595DB67F2CA}"` (checkDLL) và key license `"AKLYG-G157T-L46ZY-D158S-NRU45"` hard-code trong source.
- **Đường dẫn cứng**: `D:\T3Error.txt` (T3Server), `T3.db`, `TemplateExcel.xlsx`, `"T3.ServerHost.exe"`.
- **Magic number**: `pipe.Connect(3000)`, `Thread.Sleep(2000)`, `TopRecord = 0`, index `vm.CurrentStep - 1` rải rác.
- **Parse chuỗi cấu hình bằng `Split(',')`** với index cứng (`col[0]`, `col[1]`, `col[3]`) trong `FormMainService.CallTool` — dễ vỡ.
- **Parse số không `InvariantCulture`**: `float.Parse/double.Parse` trong `ConvertFromVariable` → lỗi trên máy locale khác (dấu phẩy thập phân).

---

## 5. NUGET PACKAGES (toàn solution)

| Package | Version | Project | Mục đích |
|---|---|---|---|
| `Microsoft.Data.Sqlite.Core` | 10.0.0 | T3ACS.Data | Driver ADO.NET cho SQLite |
| `SQLitePCLRaw.bundle_e_sqlite3` | 3.0.2 | T3ACS.Data | Native SQLite engine đóng gói |
| `SQLitePCLRaw.core` | 3.0.2 | T3ACS.Data | Lõi P/Invoke cho SQLitePCLRaw |
| `SQLiteNetExtensions` | 2.1.0 | T3ACS.Data | ORM quan hệ cho sqlite-net (**gần như không dùng**) |
| `EPPlus` | 8.6.0 | T3ACS.Model | Đọc/ghi Excel (xuất báo cáo) |
| `Newtonsoft.Json` | 13.0.1 | T3ACS.Model | Serialize/deserialize JSON |
| `Microsoft.Web.WebView2` | 1.0.4022.49 | T3ACS | Nhúng trình duyệt (step BrowserURL) |
| `LibreOfficeLibrary` | 1.0.7 | T3ACS | Chuyển Excel → PDF |

Ngoài ra `T3.ServerHost` (.NET 4.8) tham chiếu DLL qua `HintPath` trỏ tới thư mục `..\..\..\CTMT2025\...\packages\` (Microsoft.Data.OData, System.Spatial, System.Text.Json 8.0.6, Newtonsoft.Json 6.0 bản riêng…) — **phụ thuộc đường dẫn tuyệt đối theo máy, rất dễ vỡ khi build máy khác**.

> Lưu ý phiên bản: `EPPlus 8.x` yêu cầu cấu hình license (`LicenseContext`) và là bản thương mại — cần kiểm tra ràng buộc bản quyền. `Newtonsoft.Json` tồn tại 2 phiên bản khác nhau (13.0.1 ở Model, 6.0 ở ServerHost) → nguy cơ xung đột khi truyền dữ liệu giữa 2 process.

---

## 6. TỔNG KẾT

### 6.1. Đánh giá sức khỏe tổng thể

**Điểm mạnh:**
- Có **phân lớp về ý tưởng** và dùng **interface** ở các ranh giới chính (`IFormService`, `IDataBase`, `IT3Call`) — nền tảng để refactor.
- **Kiến trúc plugin thiết bị linh hoạt**: nạp DLL động theo cấu hình DB cho phép mở rộng thiết bị mà không sửa core.
- **Cấu trúc dữ liệu procedure/step được mô hình hóa khá chi tiết**, phản ánh đúng nghiệp vụ đo kiểm.
- Có xử lý exception toàn cục ở `Program.Main` và có `Logger`.

**Điểm yếu (rủi ro cao):**
- **Bảo mật**: SQL injection lan rộng (nối chuỗi input), thực thi DLL tùy ý không xác thực (cả in-process lẫn pipe không ACL), **mật khẩu user lưu plaintext** (`UserManager.InsertUser`), license/GUID hard-code.
- **Ổn định**: 2 cơ chế gọi thiết bị bất nhất (sai tên pipe/process) → có thể không kết nối được; nuốt exception che giấu lỗi; không transaction; không async → treo UI.
- **Bảo trì**: God Form hàng nghìn dòng, code trùng lặp (reflection 3 bản), lỗi chính tả định danh lan rộng, global static state, không DI, project stub/thừa, phụ thuộc `HintPath` theo máy ở `T3.ServerHost`.

**Kết luận:** Codebase **chạy được nhưng nợ kỹ thuật cao**, rủi ro lớn nhất nằm ở **bảo mật** và **độ ổn định của lớp gọi thiết bị**.

### 6.2. Đề xuất 3–5 việc ưu tiên (xếp theo rủi ro/tác động)

1. **[Rủi ro rất cao — Bảo mật] Chặn SQL injection & băm mật khẩu.**
   Chuyển toàn bộ Manager sang **parameterized query** (dùng lại `SqliteParameter`/`SQLFilter` đã có sẵn — không cần thêm package). Băm mật khẩu (ví dụ PBKDF2 có sẵn trong .NET). *Tác động: bảo vệ dữ liệu, không đổi kiến trúc.*

2. **[Rủi ro rất cao — Ổn định] Hợp nhất & sửa lớp gọi thiết bị `T3.CallDevices`.**
   Thống nhất tên pipe/process (`T3` vs `T3.ServerHost`), chọn **một** cơ chế (in-process hoặc pipe) làm chuẩn, gỡ bản copy reflection trong `FormEvaluateCorrection`. *Tác động: khắc phục nguy cơ mất kết nối thiết bị.*

3. **[Rủi ro cao — Ổn định dữ liệu] Ngừng nuốt exception & thêm transaction.**
   Bỏ `catch { return null; }` âm thầm, log/propagate hợp lý; bọc chuỗi insert Procedure/Detail/Variable trong transaction. *Tác động: dữ liệu nhất quán, dễ debug.*

4. **[Rủi ro trung bình — Trải nghiệm] Đưa I/O nặng sang async / off-UI-thread.**
   Cho DB, file, gọi thiết bị chạy nền (`Task.Run` hoặc async) để tránh treo UI khi thiết bị chậm. *Tác động: UI mượt, giảm crash "Not Responding".*

5. **[Rủi ro trung bình — Bảo trì] Tách nhỏ God Form & rút magic string thành enum/hằng.**
   Bắt đầu từ `FormRunMain`: tách phần điều phối step ra khỏi UI; gom `"LoadView"/"SaveData"/"Float"/...` thành `enum`/hằng số. *Tác động: giảm nợ kỹ thuật, dễ mở rộng.*
