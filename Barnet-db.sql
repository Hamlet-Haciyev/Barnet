USE [Barnet2]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Financial Planning')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Creative Invention')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Business Consulting')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Startup Investment')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Professional Approach')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [Email]) VALUES (1, N'Hamlet', N'hamilet75@gmail.com')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Blogs] ON 

INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (2, N'a5d7b0d2-c40a-44de-81a6-9ebd4b0837c8-20211218163452-1.jpg', N'Hamlet', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore222', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 5)
INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (4, N'37a35bc3-b5fd-4754-96b5-ad28010222e4-20211218183527-25.jpg', N'Zeka', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (5, N'c18490a7-c278-457a-ac95-ef12de133784-20211218133300-17.jpg', N'Asif', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 2)
INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (7, N'3d0a8214-7d41-4b37-b76a-05a028eb4902-20211218133338-20.jpg', N'Eli', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (9, N'a67ef91e-da19-423c-a0a8-8e4da457091a-20211218134223-3.jpg', N'Fuad', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 4)
INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (10, N'9d139e5c-e280-4dc9-add0-918d3fb574d7-20211218184949-21.jpg', N'Bahadur', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore', CAST(N'2021-12-18T18:49:49.3028927' AS DateTime2), 1, 1)
INSERT [dbo].[Blogs] ([Id], [Image], [Title], [Description], [CreatedDate], [UserId], [CategorieId]) VALUES (11, N'bb1482e0-c14c-45b0-87f4-af40b9581d8b-20211218185128-10.jpg', N'Emin', N'Lorem ipsum dolor sit amet adipelit sed eius mtempor encid dolore', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 3)
SET IDENTITY_INSERT [dbo].[Blogs] OFF
GO
SET IDENTITY_INSERT [dbo].[Service_Categories] ON 

INSERT [dbo].[Service_Categories] ([Id], [Name]) VALUES (1, N'Startup Investment')
INSERT [dbo].[Service_Categories] ([Id], [Name]) VALUES (2, N'Professional Aproach')
INSERT [dbo].[Service_Categories] ([Id], [Name]) VALUES (3, N'Market Analysis')
INSERT [dbo].[Service_Categories] ([Id], [Name]) VALUES (4, N'Growth Tracking')
INSERT [dbo].[Service_Categories] ([Id], [Name]) VALUES (5, N'Planning Strategies')
INSERT [dbo].[Service_Categories] ([Id], [Name]) VALUES (6, N'Successful Marketing')
SET IDENTITY_INSERT [dbo].[Service_Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (1, N'2bcd58c7-5943-409c-ba53-3c31e507d992-20211218214735-27.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 2)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (3, N'9d9e27db-0a31-4854-817e-150465f3ebe8-20211218230041-18.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 1)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (4, N'6ec4d0c5-589f-4bd9-b468-6a700d9a4d22-20211218230050-5.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 4)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (5, N'8edf2293-e819-467d-a22e-261811b6887d-20211218235812-3.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 2)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (6, N'573c6b86-5f88-41b0-8add-d8fa1007cb82-20211218230110-27.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 6)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (7, N'33a98341-e01e-40a0-9e2b-1838e0b33ccf-20211218230119-3.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 4)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (8, N'53c8302d-fb2a-4616-bfbd-d7310ebd31ca-20211218230132-26.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 5)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (9, N'd4165c4c-2981-45df-8e25-b26d64545dd1-20211218230147-4.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 5)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (10, N'bdeb4729-efd7-4a1c-bf0b-2693f17a4607-20211218230203-6.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 1)
INSERT [dbo].[Services] ([Id], [Image], [Content], [Icon], [Service_Category_Id]) VALUES (11, N'0ff01bb4-dd5d-417e-9387-9d84ce5f6d8c-20211218230222-21.jpg', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'fas fa-chart-bar', 3)
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[serv_Project_Categories] ON 

INSERT [dbo].[serv_Project_Categories] ([Id], [Name]) VALUES (1, N'Design')
INSERT [dbo].[serv_Project_Categories] ([Id], [Name]) VALUES (2, N'Graphic')
INSERT [dbo].[serv_Project_Categories] ([Id], [Name]) VALUES (3, N'Photography')
SET IDENTITY_INSERT [dbo].[serv_Project_Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Service_Projects] ON 

INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (1, N'48484e6a-da2f-4726-8083-5bed38ea2b73-20211219222815-18.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 2)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (2, N'f3535966-2efe-42c8-9c4e-5af6ef3cfe52-20211219222852-3.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 2)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (3, N'c88e02ec-3503-4a93-a7d9-15b3faf05778-20211219222914-1.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 1)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (4, N'4564f0d7-31aa-488b-ab04-58e72852be69-20211219222933-10.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 3)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (7, N'02561478-bb2a-4e5b-a5ff-7d24a84fad15-20211219223529-24.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 1)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (8, N'687a522f-6ccf-4eff-a31e-0f311a614f4e-20211219223540-23.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 3)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (9, N'3da5d0f4-0ee7-4ccc-8d48-58ae27e37acc-20211219223554-10.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 2)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (10, N'fe2e9e63-b3cf-4703-a15c-3464cab20ea9-20211219223612-2.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 3)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (11, N'a7008c34-9713-4322-a3ce-a6cefeb7707c-20211219223629-25.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 2)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (12, N'138f2798-af42-41fb-a6b5-7a37ab311795-20211219223644-16.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim veniam quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 1)
INSERT [dbo].[Service_Projects] ([Id], [Image], [SubTitle], [Title], [Content], [Serv_Project_Category_Id]) VALUES (13, N'34a20480-052e-4075-b2ac-2a47ec0eac68-20211219223701-18.jpg', N'Corporate', N'Business Solution', N'Lorem ipsum dolor sit amet constur adipelit sed do eiusm tempor magna aliqu enim ad minim venim quis nostrud.exercittion ullamco laboris nisi ut aliquip excepteur.sint occaecat cuidatat non proident sunt in culpa officia.', 2)
SET IDENTITY_INSERT [dbo].[Service_Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedBacks] ON 

INSERT [dbo].[FeedBacks] ([Id], [Image], [Name], [Content], [Mail]) VALUES (1, N'247cd385-16eb-447f-90aa-abe33b411b8b-20211219181327-2.jpg', N'Hamlet', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'hamilet75@gmail.com')
INSERT [dbo].[FeedBacks] ([Id], [Image], [Name], [Content], [Mail]) VALUES (3, N'3bb6fa35-5ce3-4a48-8823-71c4bf0f864a-20211219182816-7.jpg', N'Hamle234', N'Lorem ipsum dolor sit amet adipelit sed eiusmtempor encid dolore.', N'asd@gmail.com')
SET IDENTITY_INSERT [dbo].[FeedBacks] OFF
GO
SET IDENTITY_INSERT [dbo].[Settings] ON 

INSERT [dbo].[Settings] ([Id], [Phone_1], [Phone_2], [Mail], [Address], [Logo], [About]) VALUES (1, N'(251) 235-3256', N'+2(305) 587-3407', N'info@barnet.com', N'Flat 20, Reynolds Neck, North Hele
naville, FV77 8WS', N'logo.png', N'Lorem ipsum dolor amet consecte adipisicing elit sed eiusm tempor incididunt ut labore dolore magna aliqua enim ad minim veniam. quis nostrud exercitation ullam

Duis aute irure dolor in reprehend it in voluptate velit cillum.dolore eu fugiat nulla.')
SET IDENTITY_INSERT [dbo].[Settings] OFF
GO
SET IDENTITY_INSERT [dbo].[Socials] ON 

INSERT [dbo].[Socials] ([Id], [Icon], [Link], [Name]) VALUES (1, N'fab fa-facebook-f', N'https://www.facebook.com/', N'Facebook')
INSERT [dbo].[Socials] ([Id], [Icon], [Link], [Name]) VALUES (2, N'fab fa-instagram', N'https://www.facebook.com/', N'Instagram')
INSERT [dbo].[Socials] ([Id], [Icon], [Link], [Name]) VALUES (3, N'fab fa-twitter', N'https://www.facebook.com/', N'Twitter')
INSERT [dbo].[Socials] ([Id], [Icon], [Link], [Name]) VALUES (4, N'fab fa-linkedin-in', N'https://www.facebook.com/', N'Linkedin')
SET IDENTITY_INSERT [dbo].[Socials] OFF
GO
