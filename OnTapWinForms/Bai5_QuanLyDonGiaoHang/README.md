# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN
- **Họ và tên:** Nguyễn Văn A
- **Mã số sinh viên:** 20123456
- **Lớp:** 20DTHxx
- **Tên môn học:** Lập trình C# / Windows Forms
- **Tên bài tập:** Bài 5 - Bảng điều khiển Quản lý Đơn giao hàng

---

## CHỨC NĂNG ĐÃ THỰC HIỆN
- SplitContainer: trái là TabControl (Khách hàng / Vận chuyển) + khung Thêm nhanh; phải là DataGridView.
- Thành tiền tự tính; StatusStrip hiển thị đồng hồ (Timer), Tổng SL, Tổng KL, Tổng tiền – cập nhật ngay khi sửa ô.
- ErrorProvider báo đỏ khi Số lượng / Trọng lượng ≤ 0 (ô nhập và ô trong lưới).
- Phím tắt: F2 thêm dòng mới, Delete xóa dòng đang chọn.

---

## KẾT QUẢ THỰC HÀNH

### 1. Ảnh màn hình Giao diện chính
_Giao diện chính_

![Ảnh màn hình Giao diện chính](./screenshots/main_ui.png)

### 2. Ảnh màn hình Chức năng thực thi / Kết quả
_Thêm dòng bằng F2 – tổng cộng cập nhật trên StatusStrip_

![Ảnh màn hình Chức năng thực thi / Kết quả](./screenshots/execution_result.png)

### 3. Ảnh màn hình Kiểm tra lỗi (Validation)
_ErrorProvider khi Số lượng / Trọng lượng ≤ 0_

![Ảnh màn hình Kiểm tra lỗi (Validation)](./screenshots/validation_error.png)
