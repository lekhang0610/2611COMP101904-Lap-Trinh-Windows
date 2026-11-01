# Test case – StudentCardPrinter

| STT | Chức năng | Các bước | Kết quả mong đợi | Kết quả thực tế |
|---|---|---|---|---|
| 1 | Khởi động | Chạy chương trình | Form hiển thị đủ control; ComboBox có giá trị mặc định; thẻ preview hiện khung trống | Pass |
| 2 | Preview tự cập nhật | Nhập MSSV, họ tên, khóa | Thẻ bên phải hiển thị đúng dữ liệu ngay khi gõ | Pass |
| 3 | Chọn ảnh hợp lệ | Bấm Chọn ảnh, chọn file JPG | Ảnh hiện trong PictureBox và trên thẻ, không méo | Pass |
| 4 | Chọn file không phải ảnh | Đổi filter "All files", chọn file .txt đổi đuôi .jpg | Báo lỗi "File được chọn không phải ảnh hợp lệ", ảnh cũ giữ nguyên | Pass |
| 5 | Đổi ảnh nhiều lần | Chọn ảnh A, rồi B, rồi C; xóa file A trong Explorer | Không treo, không lỗi, xóa được file A (không bị khóa) | Pass |
| 6 | Thiếu MSSV | Để trống MSSV, bấm Xem trước in | Báo "Vui lòng nhập mã sinh viên", không mở Preview | Pass |
| 7 | Thiếu họ tên | Nhập MSSV, để trống họ tên, bấm In | Báo "Vui lòng nhập họ tên", không mở PrintDialog | Pass |
| 8 | Thiếu ảnh | Nhập đủ MSSV, họ tên, chưa chọn ảnh, bấm Xem trước in | Báo "Vui lòng chọn ảnh sinh viên" | Pass |
| 9 | Print Preview | Nhập đủ dữ liệu + ảnh, bấm Xem trước in | Mở Preview, thẻ có khung, tiêu đề, ảnh, thông tin giống preview | Pass |
| 10 | Ảnh không méo | Chọn ảnh ngang (landscape) và ảnh dọc | Ảnh giữ tỉ lệ trên preview và bản in | Pass |
| 11 | In ra PDF | Bấm In, chọn Microsoft Print to PDF | Tạo file PDF có thẻ đúng nội dung | Pass |
| 12 | Làm mới | Bấm Làm mới | Ô nhập rỗng, combo về mục đầu, ngày sinh = hôm nay, ảnh xóa, con trỏ ở MSSV | Pass |
| 13 | Preview nhiều lần | Bấm Xem trước in 3 lần liên tiếp | Thẻ chỉ được vẽ một lần, không bị lặp | Pass |

> Cột "Kết quả thực tế": hãy tự chạy và điền lại theo kết quả của bạn trước khi nộp.
