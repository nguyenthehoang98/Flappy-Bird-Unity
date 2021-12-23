# YÊU CẦU CHỈNH SỬA
1. Thay vì random prefab thì random AnimatorController.
2. Sử dụng color làm sprite mở thay vì dùng Shader [Em không biết dùng Shader cho 2d]
3. Sử dụng array config theo yêu cầu và sinh object theo yêu cầu.
4. Tính toán vị trí dựa vào công thức vật lý
# ĐÁNH GIÁ VÀ ĐỀ XUẤT
># ĐÁNH GIÁ
Uu điểm :
    + Triển khai nhanh trực quan
    + Thiết kế đơn giản | phù hợp với dự án kích thước nhỏ
Nhược điểm :
    + Tổ chức chưa được tốt => tất cả bị ném vào GameManager (khó quản lý + maintain)
    + Kết dính code nhiều => khó chỉnh sửa
># ĐỀ XUẤT
    + Sử dụng các SubManager thay vì 1 Manager lớn
    + Nên giảm lượng đối tượng ở Scene xuống => dễ chỉnh sửa (KISS principle)
    + Load object/prefab từ code => dễ kiểm soát và thay đổi đối với sll. Thay vì kéo trực tiếp vào scene
    + (Đối với project lớn) Nên giảm sử dụng Singleton mà thay vào bằng Dependency Injection
