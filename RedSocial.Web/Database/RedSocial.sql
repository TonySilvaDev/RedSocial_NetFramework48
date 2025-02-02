/*
######################################################
Crear en SQL la base de datos RedSocialDB
######################################################
*/

USE [RedSocialDB]
GO
/****** Object:  StoredProcedure [dbo].[USP_ReportePublicacionesPorUsuario]    Script Date: 08/05/2014 10:01:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_ReportePublicacionesPorUsuario]
AS
BEGIN
	SELECT 
		u.id, 
		Nombre + ' ' + Apellido Nombre, 
		Sexo, 
		FechaNacimiento,
		COUNT(p.id) Publicaciones
	FROM Usuario u
	INNER JOIN Publicacion p
	ON u.id = p.De
	GROUP BY u.id, u.Nombre, u.Apellido, u.Sexo, u.FechaNacimiento
	ORDER BY Publicaciones DESC

END
GO
/****** Object:  Table [dbo].[Conocimiento]    Script Date: 08/05/2014 10:01:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Conocimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Imagen] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Conocimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Foto]    Script Date: 08/05/2014 10:01:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Foto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Relacion] [varchar](20) NOT NULL,
	[Foto1] [varchar](20) NOT NULL,
	[Foto2] [varchar](20) NOT NULL,
	[Foto3] [varchar](20) NOT NULL,
	[FechaRegistro] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Foto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Publicacion]    Script Date: 08/05/2014 10:01:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Publicacion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Para] [int] NOT NULL,
	[De] [int] NOT NULL,
	[Contenido] [text] NOT NULL,
	[FechaRegistro] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Publicacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 08/05/2014 10:01:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Admin] [tinyint] NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Contrasena] [varchar](32) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Sexo] [tinyint] NULL,
	[FechaNacimiento] [varchar](10) NULL,
	[Url] [varchar](200) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioConocimiento]    Script Date: 08/05/2014 10:01:48 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioConocimiento](
	[Conocimiento_id] [int] NOT NULL,
	[Usuario_id] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioConocimiento] PRIMARY KEY CLUSTERED 
(
	[Conocimiento_id] ASC,
	[Usuario_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Conocimiento] ON 

INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (1, N'PHP', N'php.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (2, N'C#', N'csharp.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (3, N'JAVA', N'java.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (4, N'SQL Server', N'sqlserver.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (5, N'Project Manager', N'pmanager.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (6, N'ITIL', N'itil.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (7, N'PMI', N'pmi.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (8, N'CMMI', N'cmmi.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (9, N'ASP.NET MVC', N'mvc.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (10, N'jQuery', N'jquery.png')
INSERT [dbo].[Conocimiento] ([id], [Nombre], [Imagen]) VALUES (11, N'MySQL', N'mysql.png')
SET IDENTITY_INSERT [dbo].[Conocimiento] OFF
SET IDENTITY_INSERT [dbo].[Foto] ON 

INSERT [dbo].[Foto] ([id], [Relacion], [Foto1], [Foto2], [Foto3], [FechaRegistro]) VALUES (3, N'U3', N'20140429160308.JPG', N'1-20140429160308.JPG', N'2-20140429160308.JPG', N'2014/04/29 16:03:08')
INSERT [dbo].[Foto] ([id], [Relacion], [Foto1], [Foto2], [Foto3], [FechaRegistro]) VALUES (4, N'U4', N'20140429161022.JPG', N'1-20140429161022.JPG', N'2-20140429161022.JPG', N'2014/04/29 16:10:22')
INSERT [dbo].[Foto] ([id], [Relacion], [Foto1], [Foto2], [Foto3], [FechaRegistro]) VALUES (7, N'U1', N'20140508161452.jpg', N'1-20140508161452.jpg', N'2-20140508161452.jpg', N'2014/05/08 16:14:52')
SET IDENTITY_INSERT [dbo].[Foto] OFF
SET IDENTITY_INSERT [dbo].[Publicacion] ON 

INSERT [dbo].[Publicacion] ([id], [Para], [De], [Contenido], [FechaRegistro]) VALUES (1, 1, 1, N'probando', N'2014/05/07 19:47:14')
INSERT [dbo].[Publicacion] ([id], [Para], [De], [Contenido], [FechaRegistro]) VALUES (2, 1, 1, N'hola mundo', N'2014/05/08 17:07:40')
INSERT [dbo].[Publicacion] ([id], [Para], [De], [Contenido], [FechaRegistro]) VALUES (3, 1, 1, N'probando soy vegeta el principe de los sajajines ... :p', N'2014/05/08 17:12:48')
INSERT [dbo].[Publicacion] ([id], [Para], [De], [Contenido], [FechaRegistro]) VALUES (4, 3, 1, N'hola como estas bill', N'2014/05/08 17:15:49')
SET IDENTITY_INSERT [dbo].[Publicacion] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [Admin], [Correo], [Contrasena], [Nombre], [Apellido], [Sexo], [FechaNacimiento], [Url]) VALUES (1, 1, N'demo@demo.com', N'e10adc3949ba59abbe56e057f20f883e', N'Demo', N'Demo', 1, N'1989/02/01', N'vegeta-saijajin-1')
INSERT [dbo].[Usuario] ([id], [Admin], [Correo], [Contrasena], [Nombre], [Apellido], [Sexo], [FechaNacimiento], [Url]) VALUES (3, 0, N'lhuaman@hotmail.com', N'e10adc3949ba59abbe56e057f20f883e', N'Bill', N'Gates', 1, N'1970/05/05', N'bill-gates-3')
INSERT [dbo].[Usuario] ([id], [Admin], [Correo], [Contrasena], [Nombre], [Apellido], [Sexo], [FechaNacimiento], [Url]) VALUES (5, 0, N'aperez@gmai.com', N'e10adc3949ba59abbe56e057f20f883e', N'Alberto', N'Diaz Perez', NULL, NULL, N'alberto-diaz-perez-5')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (1, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (1, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (2, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (2, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (3, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (3, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (4, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (4, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (5, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (6, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (7, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (8, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (9, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (9, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (10, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (10, 3)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (11, 1)
INSERT [dbo].[UsuarioConocimiento] ([Conocimiento_id], [Usuario_id]) VALUES (11, 3)
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Rol]  DEFAULT ((0)) FOR [Admin]
GO
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [DF_Usuario_Sexo]  DEFAULT ((0)) FOR [Sexo]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Usuario] FOREIGN KEY([Para])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Usuario]
GO
ALTER TABLE [dbo].[Publicacion]  WITH CHECK ADD  CONSTRAINT [FK_Publicacion_Usuario1] FOREIGN KEY([De])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Publicacion] CHECK CONSTRAINT [FK_Publicacion_Usuario1]
GO
ALTER TABLE [dbo].[UsuarioConocimiento]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioConocimiento_Conocimiento] FOREIGN KEY([Conocimiento_id])
REFERENCES [dbo].[Conocimiento] ([id])
GO
ALTER TABLE [dbo].[UsuarioConocimiento] CHECK CONSTRAINT [FK_UsuarioConocimiento_Conocimiento]
GO
ALTER TABLE [dbo].[UsuarioConocimiento]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioConocimiento_Usuario] FOREIGN KEY([Usuario_id])
REFERENCES [dbo].[Usuario] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioConocimiento] CHECK CONSTRAINT [FK_UsuarioConocimiento_Usuario]
GO
USE [master]
GO
ALTER DATABASE [RedSocialDB] SET  READ_WRITE 
GO
