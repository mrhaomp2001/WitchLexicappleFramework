# Witch Lexicapple

Framework game cho Unity, tập trung vào tính tự động hoá dữ liệu, hệ thống chỉ số dùng chung, và các thành phần gameplay dựng sẵn (nhân vật, NPC, kẻ địch, hội thoại, inventory, game flow).

## Tiến độ

| Nhóm      | Hoàn thành |
| --------- | :--------: |
| Nền tảng  |    0/2     |
| Cốt lõi   |    0/12    |
| **Tổng**  |  **0/14**  |

## Nền tảng

- [x] 1. Vật thể trong game có thể tự lưu dữ liệu và trạng thái của chính nó một cách dễ dàng và tự động.
- [ ] 2. Có 1 danh sách chỉ số sử dụng chung dành cho nhà phát triển framework (`List<Stat> defaultStats`) hoạt động toàn cục.

## Cốt lõi

- [ ] 1. Nhân vật người chơi di chuyển được với thông số tốc độ (`DefaultStats["speed"]`).
- [ ] 2. Nhân vật người chơi có các chỉ số mặc định (`hp`, `hpMax`, ...).
- [ ] 3. Nhân vật người chơi có thể tấn công mặc định và các thành phần liên quan (`playerBullet`, `playerBulletGroup`, ...).
- [ ] 4. Người dùng có thể tạo NPC, có move set có sẵn hoặc cài đặt route tùy chỉnh (sử dụng Nav Agent 2D mới của Unity 6).
- [ ] 5. Người dùng có thể tạo kẻ địch, trùm, có move set có sẵn hoặc move set tự thiết kế (sử dụng hệ thống chưa nghĩ tới).
- [ ] 6. Hệ thống cho phép người dùng hiển thị hình ảnh trong các sự kiện khác nhau.
- [ ] 7. Hệ thống cho phép người dùng phát âm thanh (dễ).
- [ ] 8. Hệ thống nói chuyện `ShowText()`, hệ thống hiển thị lựa chọn `ShowChoice()`.
- [ ] 9. Hệ thống inventory và items, các sự kiện liên quan đến item (nhặt item lên, sử dụng item, vứt item ra ngoài thế giới, ...).
- [x] 10. Hệ thống chuyển đổi text/string dạng phép tính sang thẳng kết quả.
    - Ví dụ: `"((1+1)/2)+3"` sẽ cho ra kết quả `4`.
    - Hỗ trợ: `+`, `-`, `*`, `/` (div), `%` (mod), `player.stat` (lấy bất kỳ chỉ số nào của nhân vật), `target.stat` (lấy bất kỳ chỉ số nào của bên thứ 3).
    - Hiện chưa hỗ trợ player.stat + target.stat, nhưng sẽ hỗ trợ trong tương lai, vẫn đang nghĩ cách.
- [ ] 11. Thiết kế một danh sách công tắc, một danh sách biến để người dùng tự tạo các chỉ số riêng và thiết kế game flow.
- [ ] 12. Thiết kế các component giúp gọi if-else, while, random để hỗ trợ game flow.
    - Ví dụ: nếu công_tắc(1) là true, thì NPC 2 sẽ xuất hiện.
    - Hoặc: nếu biến(3) >= 4 thì NPC 12 sẽ xuất hiện.
