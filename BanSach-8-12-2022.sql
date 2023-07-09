Create database QL_NhaSach
go
use QL_NhaSach
go


create table LoaiSach(
MaLoaiSach int primary key,
TenLoaiSach nvarchar(Max),
MoTa Nvarchar(max)
)
Go

create table TacGia(
MaTacGia int primary key,
TenTacGia nvarchar(max),
NgaySinh date ,
DiaChiTacGia nvarchar(max)
)
GO

create table Sach(
MaSach int primary key,
TenSach nvarchar(MAx),
SoLuong int ,
Anh char(10),
GiaSanPham float,
MaLoaiSach int,
MaTacGia int
)
Go
 Create table GioHang(
 MaGioHang int primary key,
 MaSach int
 )
 GO







 ----khoa ngoai
 alter table Sach
 add constraint StoLS
foreign key (MaLoaiSach)
references dbo.LoaiSach


 alter table Sach
 add constraint StoTG
foreign key (MaTacGia)
references dbo.TacGia

 alter table GioHang
 add constraint GHtoS
foreign key (MaSach)
references dbo.Sach


--du lieu
INSERT INTO LoaiSach VALUES('1',N'TRINH THÁM',N'Truyện trinh thám hay tiểu thuyết trinh thám (tiếng Pháp: roman détective) là một tiểu loại của tiểu thuyết phiêu lưu. Bản thân tên gọi thể loại đã làm nổi bật một vài đặc điểm riêng của nó.')
INSERT INTO LoaiSach VALUES('2',N'THIẾU NHI',N'Hướng dẫn thiếu nhi đọc sách trong thư viện là quá trình tổ chức lại hoạt động đọc, giúp các em hình thành, củng cố và phát triển nhu cầu đọc lành mạnh, điều chỉnh nhu cầu và hứng thú đọc lệch lạc, biến hoạt động đọc sách thành một loại hoạt động th­ường xuyên, có ích cho cuộc sống của các em; rèn luyện cho các em kỹ năng đọc sách: phư­ơng pháp đọc, khả năng lĩnh hội, vận dụng tri thức trong sách vào cuộc sống; đồng thời giáo dục các em thái độ đối xử có văn hoá với sách báo - sản phẩm tinh thần cao quý của nhân loại.
')
INSERT INTO LoaiSach VALUES('3',N'SÁCH GIÁO KHOA',N'Bên trong sách: có tên của những tác giả tham gia soạn sách được in ở đầu trang, trang tiếp theo là bảng giải thích các kí hiệu dùng trong sách và những người chịu trách nhiệm xuất bản cũng như về nội dung và hình thức của sách.')
INSERT INTO LoaiSach VALUES('4',N'Chính trị – pháp luật',N'Pháp luật là hệ thống các quy tắc xử sự do nhà nước ban hành và bảo đảm thực hiện. Các cuốn sách pháp luật chính trị thể hiện những nội dung về việc thực hiện quyền và nghĩa vụ của công dân khi sinh sống trong lãnh thổ Việt Nam.')
INSERT INTO LoaiSach VALUES('5',N'Khoa học công nghệ – Kinh tế',N'Bài viết sử dụng phương pháp nghiên cứu bàn viết để tổng quan về tình hình phát triển khoa học-công nghệ và tác động của nó đến tăng trưởng kinh tế ở Việt Nam và trên thế giới. Kết quả phân tích cho thấy rằng phát triển khoa học-công nghệ và đổi với sáng tạo đang là xu thế và là các yếu tố quan trọng trong mô hình tăng trưởng kinh tế hiện đại. ')
INSERT INTO LoaiSach VALUES('6',N'Văn học nghệ thuật',N'ăn học nghệ thuật là tinh hoa của văn hóa thẩm mỹ, là lĩnh vực phong phú và nhạy cảm của văn hóa. Các tác phẩm văn học nghệ thuật là hình ảnh chủ quan về thế giới khách quan.')
INSERT INTO LoaiSach VALUES('7',N'Văn hóa xã hội – Lịch sử',N'Lịch sử văn hóa kết hợp các cách tiếp cận của nhân học và lịch sử để xem xét các truyền thống văn hóa phổ biến và các diễn giải văn hóa về các kinh nghiệm lịch sử. Nó xem xét các ghi chép và mô tả tường thuật về vật chất trong quá khứ,')
INSERT INTO LoaiSach VALUES('8',N'Truyện, tiểu thuyết',N'Tiểu thuyết là một thể loại văn xuôi có hư cấu, thông qua nhân vật, hoàn cảnh, sự việc để phản ánh bức tranh xã hội rộng lớn và những vấn đề của cuộc sống con người, biểu hiện tính chất tường thuật, tính chất kể chuyện bằng ngôn ngữ văn xuôi theo những chủ đề xác định.')

INSERT INTO LoaiSach VALUES('10',N'Dạy nấu ăn – Cookbooks',N'rường dạy nấu ăn là cơ sở giáo dục đào tạo về nghệ thuật và áp dụng khoa học vào chế biến thực phẩm. Có nhiều loại hình trường dạy nấu ăn khác nhau trên khắp thế giới, một số đào tạo các đầu bếp chuyên nghiệp')
select * from LoaiSach


INSERT INTO TacGia VALUES('1',N'Ngô Tất Tố','1945-04-20',N'Bắc Ninh')
INSERT INTO TacGia VALUES('2',N'Nguyễn Du','1766-01-03',N'Hà Tĩnh.')
INSERT INTO TacGia VALUES('3',N'Kim Lân','1920-08-01',N'Phù Lưu')
INSERT INTO TacGia VALUES('4',N'Nam Cao','1915-10-29',N'Hà Nam')
INSERT INTO TacGia VALUES('5',N'Nhà Xuất Bản Và Giáo Dục','1916-10-02',N'Việt Nam')
INSERT INTO TacGia VALUES('6',N'Báo Trí','1916-10-02',N'Việt Nam')
SELECT *FROM TacGia

INSERT INTO Sach VALUES('1',N'Tắt đèn',23,'tatden.png','45000',8,1)
INSERT INTO Sach VALUES('2',N'Vợ Nhặt',10,'vonhat.png','32000',8,3)
INSERT INTO Sach VALUES('3',N'Sách Hóa Học 11',6,'HHoc11.png','1200',3,5)
INSERT INTO Sach VALUES('4',N'Sách Hóa Học 12',20,'HHoc12.png','23000',3,5)
INSERT INTO Sach VALUES('5',N'Sách Kinh Tế Chính Trị',12,'KTTri.png','120000',5,6)
INSERT INTO Sach VALUES('6',N'Sách Anh Văn 11',10,'AVan11.png','32000',3,5)
INSERT INTO Sach VALUES('7',N'Sách Tiếng Việt',5,'TV.png','15000',8,1)
INSERT INTO Sach VALUES('8',N'Tắt đèn',23,'tatden.png','45000',8,1)
INSERT INTO Sach VALUES('9',N'Tắt đèn',23,'tatden.png','45000',8,1)
INSERT INTO Sach VALUES('10',N'Tắt đèn',23,'tatden.png','45000',8,1)
select * from sach

 



