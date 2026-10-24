# BÁO CÁO BÀI LAB 7: SDI, MDI VÀ ỨNG DỤNG NHIỀU FORM TRONG C# WINFORMS
**Môn học:** COMP1019 - Lập trình trên Windows  
**Dự án:** ShopManagerMini (Hệ thống Quản lý Cửa hàng Mini)

---

## 1. THÔNG TIN DỰ ÁN
- **Cấu trúc thư mục:**
  - `Models/`: Chứa các lớp thực thể `User.cs`, `Product.cs`, `Customer.cs` và `DataStore.cs` (quản lý dữ liệu mẫu trong bộ nhớ).
  - `Forms/`:
    - `FrmLogin.cs`: Màn hình Đăng nhập (Modal Dialog), kiểm tra tài khoản mẫu, phân quyền.
    - `FrmMain.cs`: Màn hình chính MDI Container, MenuStrip, StatusStrip, kiểm tra chống mở trùng form.
    - `FrmProduct.cs`: Màn hình Quản lý sản phẩm (CRUD đầy đủ, tìm kiếm, validation dữ liệu).
    - `FrmCustomer.cs`: Màn hình Quản lý khách hàng (CRUD đầy đủ, kiểm tra SĐT, validation dữ liệu).
    - `FrmAbout.cs`: Màn hình Giới thiệu đồ án/thông tin sinh viên.
  - `Program.cs`: Luồng khởi chạy ứng dụng, xử lý điều hướng Đăng nhập -> MDI Main -> Đăng xuất/Thoát.
  - `Screenshots/`: Chứa ảnh chụp thực tế các màn hình khi chạy.

---

## 2. TRẢ LỜI 5 CÂU HỎI NỘP KÈM (MỤC 10)

### Câu 1: SDI và MDI khác nhau như thế nào?
- **SDI (Single Document Interface):**
  - Mỗi cửa sổ Form là một thực thể độc lập trên màn hình desktop, không nằm trong form cha nào.
  - Mỗi khi mở một tài liệu hoặc giao diện mới, hệ điều hành hiển thị một cửa sổ tách rời riêng lẻ (ví dụ: Notepad, Calculator).
  - Khó quản lý tập trung khi ứng dụng có nhiều màn hình chức năng.
- **MDI (Multiple Document Interface):**
  - Có một Form cha lớn (`MdiParent`) bao bọc toàn bộ giao diện (`IsMdiContainer = true`).
  - Các Form con (`MdiChildren`) luôn hiển thị, di chuyển, thu nhỏ hoặc phóng to bên trong không gian của Form cha.
  - Khi Form cha thu nhỏ hoặc đóng, tất cả Form con bên trong cũng bị thu nhỏ hoặc đóng theo (ví dụ: Visual Studio, Photoshop, ERP). Giúp giao diện gọn gàng, chuyên nghiệp và quản lý tập trung.

---

### Câu 2: Vì sao Form đăng nhập nên dùng `ShowDialog()`?
- `ShowDialog()` mở Form dưới dạng **Modal Dialog** (hộp thoại chặn tương tác):
  1. **Bảo mật và ép buộc luồng nghiệp vụ:** Chặn hoàn toàn tương tác của người dùng với các cửa sổ khác của ứng dụng cho đến khi việc xác thực hoàn tất.
  2. **Thực thi đồng bộ (Synchronous):** Hàm gọi `ShowDialog()` sẽ tạm dừng luồng tại đó cho đến khi Form đóng lại, giúp code điều phối dễ đọc và kiểm soát.
  3. **Thuận tiện nhận kết quả trả về (`DialogResult`):** `ShowDialog()` trả về `DialogResult.OK` khi đăng nhập đúng hoặc `DialogResult.Cancel` khi hủy/thoát. Nhờ đó, chương trình tại `Program.cs` có thể kiểm tra: chỉ khi `result == DialogResult.OK` thì mới khởi tạo và chạy `FrmMain`, ngược lại thì thoát hoàn toàn chương trình.

---

### Câu 3: Trong bài lab này, dữ liệu user được truyền từ FrmLogin sang FrmMain bằng cách nào?
- Dữ liệu `User` được truyền kết hợp giữa **Public Property** trên `FrmLogin` và **Constructor** của `FrmMain`:
  1. Khi người dùng bấm nút **Đăng nhập** thành công trên `FrmLogin`, đối tượng người dùng hợp lệ được lưu vào thuộc tính:
     ```csharp
     public User? LoggedInUser { get; private set; }
     ```
     Sau đó thiết lập `this.DialogResult = DialogResult.OK;` và đóng `FrmLogin`.
  2. Tại `Program.cs`, sau khi `loginForm.ShowDialog()` trả về `DialogResult.OK`, ta đọc thuộc tính `loginForm.LoggedInUser` và truyền trực tiếp vào Constructor của `FrmMain`:
     ```csharp
     FrmMain mainForm = new FrmMain(loginForm.LoggedInUser);
     Application.Run(mainForm);
     ```
  3. Trong `FrmMain`, Constructor nhận đối tượng `User` và lưu vào biến thành viên/thuộc tính `CurrentUser`, đồng thời gán thông tin lên thanh `StatusStrip`:
     ```csharp
     lblUserStatus.Text = $"Người dùng: {CurrentUser.FullName} | Vai trò: {CurrentUser.Role}";
     ```

---

### Câu 4: Nếu người dùng bấm menu sản phẩm nhiều lần, chương trình xử lý như thế nào để không mở trùng Form?
- Chương trình duyệt danh sách các Form con MDI hiện đang mở thông qua thuộc tính `this.MdiChildren`:
  ```csharp
  private void OpenChildForm<T>() where T : Form, new()
  {
      // 1. Duyệt tất cả Form con đang mở
      foreach (Form child in this.MdiChildren)
      {
          // 2. Nếu Form con cùng loại đang mở
          if (child is T existingChild)
          {
              // 3. Kích hoạt đưa Form cũ lên trước mặt người dùng
              existingChild.Activate();
              if (existingChild.WindowState == FormWindowState.Minimized)
              {
                  existingChild.WindowState = FormWindowState.Normal;
              }
              return; // Dừng hàm, không tạo mới
          }
      }

      // 4. Nếu chưa mở thì mới khởi tạo Form con mới
      T newChild = new T();
      newChild.MdiParent = this;
      newChild.Show();
  }
  ```
- Cách xử lý generic này đảm bảo an toàn tuyệt đối: Nếu `FrmProduct` đã mở, việc click menu chỉ đơn thuần là `Activate()` lại cửa sổ đó, hoàn toàn không sinh thêm instance mới.

---

### Câu 5: Khi nào nên dùng constructor, khi nào nên dùng property để truyền dữ liệu giữa các Form?
- **Nên dùng Constructor:**
  - Khi dữ liệu truyền sang là **bắt buộc và tiên quyết** để Form đích có thể khởi tạo và hoạt động bình thường (ví dụ: `FrmMain` bắt buộc phải có `User` đăng nhập; `FrmChiTiet` bắt buộc phải có `id` sản phẩm để nạp dữ liệu).
  - Giúp bảo vệ tính đóng gói và an toàn dữ liệu: ngăn ngừa việc khởi tạo đối tượng ở trạng thái thiếu dữ liệu (incomplete state).
- **Nên dùng Property:**
  - Khi dữ liệu truyền sang là **tùy chọn (optional)**, Form vẫn có thể chạy bình thường nếu thiếu dữ liệu đó.
  - Khi cần truyền dữ liệu theo chiều **ngược lại** (từ Form con/Modal trả về cho Form gọi nó, ví dụ: `loginForm.LoggedInUser`).
  - Khi dữ liệu cần được cập nhật nhiều lần trong suốt thời gian Form đang hiển thị mà không cần tạo lại instance của Form.
