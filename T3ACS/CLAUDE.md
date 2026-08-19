# CLAUDE.md

Hướng dẫn dành cho Claude Code khi làm việc trong repository này.

## Ngữ cảnh dự án

T3ACS là ứng dụng desktop .NET 8 Windows Forms dùng để tự động hoá kiểm thử/đo lường
phần cứng (DUT — Device Under Test). Solution gồm nhiều project: `T3ACS` (UI),
`T3ACS.Service`, `T3ACS.Model`, `T3ACS.Data` (SQLite), `T3.CallDevices`,
`T3.ServerHost`, `T3.Configuration`, `T3ACS.Controls`, `T3ACS.Util`.

## Quy tắc bắt buộc

1. **Ngôn ngữ trả lời:** Luôn trả lời tôi bằng **tiếng Việt**.

2. **Định danh code giữ nguyên tiếng Anh:** Giữ nguyên tên `class`, `method`,
   `property`, `variable` và API bằng tiếng Anh. Không dịch hay đổi tên các định danh
   này sang tiếng Việt.

3. **Không tự ý sửa file:** Không chỉnh sửa, tạo, hay xoá file khi tôi chưa yêu cầu
   rõ ràng. Khi được hỏi để phân tích/đánh giá, chỉ đọc và giải thích — không thay đổi.

4. **Giải thích khi sửa code:** Mỗi khi sửa code, phải giải thích **nguyên nhân** và
   **nội dung thay đổi** bằng tiếng Việt.

5. **Không tự ý thêm NuGet package:** Không thêm, gỡ, hay nâng cấp NuGet package khi
   chưa được tôi đồng ý. Ưu tiên dùng các thư viện đã có sẵn trong project.

6. **Không tự ý thay đổi architecture:** Giữ nguyên kiến trúc phân lớp hiện tại
   (UI → Service → Model → Data, và lớp gọi thiết bị `T3.CallDevices`). Không tái cấu
   trúc, đổi pattern, hay di chuyển trách nhiệm giữa các layer khi chưa được yêu cầu.

7. **Comment bằng tiếng Việt:** Luôn viết comment trong code bằng **tiếng Việt**.
   Riêng tên định danh (`class`, `method`, `property`, `variable`, API) vẫn giữ nguyên
   tiếng Anh theo quy tắc số 2.
