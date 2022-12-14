USE [17T1021107NguyenDucHuy]
GO
/****** Object:  Table [dbo].[DanhBa]    Script Date: 10/28/2022 11:08:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhBa](
	[MaLienLac] [bigint] IDENTITY(1,1) NOT NULL,
	[TenLienLac] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[SoDienThoai] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[MaNhom] [bigint] NOT NULL,
 CONSTRAINT [PK_DanhBa] PRIMARY KEY CLUSTERED 
(
	[MaLienLac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nhom]    Script Date: 10/28/2022 11:08:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhom](
	[MaNhom] [bigint] IDENTITY(1,1) NOT NULL,
	[TenNhom] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Nhom] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[DanhBa] ON 

INSERT [dbo].[DanhBa] ([MaLienLac], [TenLienLac], [Email], [SoDienThoai], [DiaChi], [MaNhom]) VALUES (1, N'Huy', N'huy@gmail.com', N'02255563', N'DN', 1)
INSERT [dbo].[DanhBa] ([MaLienLac], [TenLienLac], [Email], [SoDienThoai], [DiaChi], [MaNhom]) VALUES (4, N'Nguen', N'nguyen@gmail.com', N'022555455', N'Hue', 2)
INSERT [dbo].[DanhBa] ([MaLienLac], [TenLienLac], [Email], [SoDienThoai], [DiaChi], [MaNhom]) VALUES (5, N'Duc', N'Duc@gmail.com', N'4324325', N'Hue', 3)
SET IDENTITY_INSERT [dbo].[DanhBa] OFF
SET IDENTITY_INSERT [dbo].[Nhom] ON 

INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (1, N'Bạn Bè')
INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (2, N'Công việc')
INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (3, N'Gia Đình')
INSERT [dbo].[Nhom] ([MaNhom], [TenNhom]) VALUES (5, N'HI')
SET IDENTITY_INSERT [dbo].[Nhom] OFF
ALTER TABLE [dbo].[DanhBa]  WITH CHECK ADD  CONSTRAINT [FK_DanhBa_Nhom1] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[Nhom] ([MaNhom])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DanhBa] CHECK CONSTRAINT [FK_DanhBa_Nhom1]
GO
