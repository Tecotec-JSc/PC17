# ĐỐI CHIẾU CHỨC NĂNG T3ACS VỚI YÊU CẦU PHẦN MỀM KIỂM ĐỊNH/HIỆU CHUẨN

> Tài liệu đối chiếu chức năng hiện có của phần mềm **T3ACS** với **Bảng yêu cầu tính năng**
> "Phần mềm Kiểm định, hiệu chuẩn thiết bị đo" (theo ISO/IEC 17025) — nguồn `chucnangyc.jpg`.
> Ngày lập: 2026-08-19. Chỉ mang tính phân tích — không phản ánh thay đổi code.

## Bản chất hai bên

- **Yêu cầu trong ảnh** = một **hệ quản lý phòng thí nghiệm (LIMS)** cho lab kiểm định/hiệu chuẩn theo
  ISO/IEC 17025 — thiên về **quản lý nghiệp vụ lab** (khách hàng, đơn hàng, công nợ, vật tư, nhân sự,
  kiểm kê, chứng chỉ, phê duyệt, đa nền tảng, server/SSL/backup).
- **T3ACS hiện tại** = một **engine xây dựng & thực thi quy trình đo/hiệu chuẩn tự động** trên desktop:
  dựng procedure gồm các step gọi DLL thiết bị → chạy trên DUT → thu kết quả → xuất báo cáo Excel/PDF,
  có phân quyền người dùng.

→ T3ACS **phủ đúng phần lõi kỹ thuật** (đo – tính – ra kết quả/báo cáo), nhưng **phần lớn yêu cầu quản lý
nghiệp vụ lab thì chưa có**.

**Chú thích trạng thái:** 🟢 Có · 🟡 Một phần · 🔴 Chưa có · ⚪ Tiêu chí vận hành (không đánh giá qua source)

---

## A. Nhóm yêu cầu nền tảng/hạ tầng

| Yêu cầu | Trạng thái | Ghi chú (bằng chứng trong code) |
|---|---|---|
| Quản lý tài sản/thông tin Lab, hỗ trợ ISO/IEC 17025 | 🟡 Một phần | Có quản lý thiết bị đo (`DUT`) + quy trình, nhưng chưa phải hệ quản lý lab/hồ sơ ISO |
| Tuân thủ ISO 17025:2017, NĐ105/2016, TT24/2013 | 🔴 Chưa có | Không có module hồ sơ/kiểm soát tài liệu tuân thủ |
| Đa nền tảng (iOS/Android/Windows), đồng bộ | 🔴 Chưa có | Là WinForms .NET 8 — chỉ Windows; không có mobile/đồng bộ |
| Phân cấp cảnh báo bảo mật (admin/user/services) | 🟡 Một phần | Có phân quyền Admin/Operator/Reviewer/QA (`UserManager`), nhưng không có tầng "services/cảnh báo" |
| CSDL tập trung | 🔴 Chưa có | Dùng SQLite file cục bộ (`T3.db`), không phải DB tập trung client-server |
| Triển khai server LAN + truy cập Internet | 🔴 Chưa có | App desktop chạy cục bộ; pipe thiết bị cũng cục bộ |
| Bảo vệ bằng SSL | 🔴 Chưa có | Không có tầng mạng mã hóa |
| Hệ thống sao lưu dự phòng | 🔴 Chưa có | Không thấy module backup |
| Quy trình nghiệp vụ (báo giá, hợp đồng, phiếu nhận-trả, phân công, biên bản, chứng chỉ, bàn giao) | 🟡 Một phần nhỏ | Chỉ có "biên bản/chứng chỉ đo lường" dạng report Excel/PDF (`FormCreateReport`, `ExcelModel`, `ConvertExcelToPdf`). Không có báo giá/hợp đồng/phiếu nhận-trả/phân công/bàn giao |
| Phân cấp ký, xác nhận (soạn thảo → gửi duyệt → phê duyệt) | 🟡 Một phần | Có role Reviewer/QA + step Review (`FormCreateReview`/`FormEvaluateReview`) và trường `Status`. Chưa có state-machine duyệt + chữ ký điện tử cấp chứng chỉ |
| ≥4 đơn vị dùng bản quyền, ≥1000 chứng chỉ đã duyệt | ⚪ Tiêu chí vận hành | Không phải tính năng code — không đánh giá qua source |

---

## B. Nhóm "Yêu cầu tính năng của phần mềm"

| Yêu cầu | Trạng thái | Ghi chú |
|---|---|---|
| Quản lý khách hàng | 🔴 Chưa có | Không có bảng/khái niệm Customer |
| Quản lý đơn hàng (tình trạng đơn hàng) | 🔴 Chưa có | Không có Order |
| Quản lý công – nợ | 🔴 Chưa có | Không có kế toán/công nợ |
| Quản lý nhà thầu phụ/nhà cung cấp (hoá chất, mẫu chuẩn, vật tư, dụng cụ, đào tạo) | 🔴 Chưa có | Không có Supplier/vật tư |
| Quản lý nhân sự thực hiện đơn hàng + lịch công tác | 🔴 Chưa có | `User` chỉ để đăng nhập/phân quyền, không có lịch công tác |
| Quản lý giao & nhận phương tiện đo | 🟡 Một phần | Có quản lý `DUT` (thêm/sửa/xóa, `CalibrationDate/CalibrationDue`) nhưng không có luồng giao–nhận/nhận–trả |
| Quản lý chuẩn đo lường & chất chuẩn bằng QRCode/RFID | 🔴 Chưa có | Không có QRCode/RFID, không có "chuẩn/chất chuẩn" |
| Quản lý kiểm kê (xuất–nhập–tồn) bằng QRCode/RFID | 🔴 Chưa có | Không có kho/kiểm kê |
| Kiểm soát chất lượng QA/QC + phê duyệt trực tuyến | 🟡 Một phần | Role QA/QC + step Review cục bộ; chưa "trực tuyến" |
| Quản lý phương pháp/quy trình (TCVN/QCVN/ĐLVN) theo từng phương tiện đo | 🟡 Một phần | Có `Procedure` + `Category/Version` + gán DUT (`DUTProcedure`). Chưa gắn cấu trúc chuẩn TCVN/QCVN/ĐLVN |
| Quản lý kết quả đo lường (biên bản, chứng chỉ) | 🟢 Có | Cốt lõi hiện có: `ResultProcedure`/`ResultProcedureStep` + xuất report |
| Tính toán & công bố CMC (khả năng đo & hiệu chuẩn) | 🔴 Chưa có | Có step tính toán/công thức chung (`FormEvaluateCalculation`, `FormulaEvaluator`) nhưng không có độ KĐBĐ/CMC; cột "Uncertainty" hiện để "N/A" |
| Tính toán phân bổ chi phí (nhân công, NVL, thiết bị) | 🔴 Chưa có | Không có module chi phí |
| Cập nhật năng lực phòng thử nghiệm (quy trình, hiện trạng thiết bị – ngày hiệu chỉnh, hoá chất–vật tư) | 🟡 Một phần | `DUT` có `CalibrationDate/CalibrationDue`; chưa có hoá chất/vật tư/bức tranh năng lực tổng thể |
| Phân quyền người dùng | 🟢 Có | `UserManager` + permission Admin/Operator/Reviewer/QA |

---

## C. Kết luận

**Đã có (lõi kỹ thuật đo/hiệu chuẩn):**
- Dựng & thực thi quy trình đo (procedure/step, gọi DLL thiết bị), quản lý DUT, thu & lưu kết quả,
  xuất biên bản/chứng chỉ Excel/PDF, phân quyền người dùng, có mầm mống QA/review.

**Còn thiếu (đa số yêu cầu — phần quản lý nghiệp vụ lab):**
1. **Nghiệp vụ kinh doanh:** khách hàng, đơn hàng, công nợ, nhà cung cấp, phân bổ chi phí.
2. **Quản lý tài sản/kho:** chuẩn đo lường & chất chuẩn, kiểm kê xuất-nhập-tồn, QRCode/RFID,
   giao–nhận phương tiện đo, hoá chất–vật tư.
3. **Nhân sự & lịch công tác.**
4. **Quy trình phê duyệt điện tử** (soạn thảo → gửi duyệt → phê duyệt + chữ ký) và **QA/QC trực tuyến**.
5. **Tính toán độ KĐBĐ & công bố CMC** (rất quan trọng với ISO/IEC 17025).
6. **Hạ tầng:** kiến trúc client-server/CSDL tập trung, truy cập web/di động, SSL, sao lưu dự phòng —
   đây là thay đổi kiến trúc lớn (app hiện là desktop + SQLite cục bộ).

**Nhận định mức độ đáp ứng:** T3ACS hiện đáp ứng khoảng **2 mục "Có" trọn vẹn + ~6 mục "Một phần"**
trên tổng ~25 dòng yêu cầu — tức phủ **phần lõi đo lường**, còn **toàn bộ lớp quản lý lab và hạ tầng
đa nền/tập trung/bảo mật thì cần xây mới**.
