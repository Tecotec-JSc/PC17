# 05. Triển khai & vận hành

## 5.1. Đóng gói & phát hành
> TODO: Build Release, tạo installer/bộ cài, danh sách file cần kèm (exe, DLL, driver, DB mẫu).

## 5.2. Cấu hình runtime
- Connection string SQLite: `Main.ConnectionStringSQLite` (`T3.Configuration`).
- Đường dẫn driver DLL: cấu hình theo Procedure/Step.
> TODO: Liệt kê file config, biến, đường dẫn cần thiết lập khi triển khai.

## 5.3. Cập nhật & nâng cấp
> TODO: Quy trình cập nhật phiên bản; migrate/khởi tạo schema SQLite; tương thích ngược dữ liệu.

## 5.4. Sao lưu & phục hồi
> TODO: Sao lưu file DB SQLite & dữ liệu kết quả; cách phục hồi.

## 5.5. Logging & chẩn đoán
- Log lỗi qua `Logger` (`T3.Configuration`); `SQLiteDataBase.GetDataTable` ghi log khi lỗi.
> TODO: Vị trí file log, mức log, cách bật/tắt, cách gửi log hỗ trợ.
