USE [PizzaAppDB]
GO
INSERT [dbo].[Pizza] ([PizzaId], [PizzaName]) VALUES ('ce46c209-e7ee-4f8a-b5ab-0cd8a2ef9564', N'Extra Cheese Pizza')
INSERT [dbo].[Pizza] ([PizzaId], [PizzaName]) VALUES ('606ddcc6-5a45-420b-ae10-5f6395eff827', N'Peperonni Pizza')
GO
INSERT [dbo].[Ingredient] ([IngredientId], [IngredientName]) VALUES ('82f5462d-b629-478d-898a-1d7ab85e8bdd', N'Extra Cheese')
INSERT [dbo].[Ingredient] ([IngredientId], [IngredientName]) VALUES ('bbb7ee8a-2caf-4c4e-baea-9ad4da3ac9df', N'Peperonni')
GO
INSERT [dbo].[PizzaIngredient] ([PizzaIngredientId], [PizzaId], [IngredientId]) VALUES ('2f4cad4d-3008-4d65-a8f9-02970ba3611c', 'ce46c209-e7ee-4f8a-b5ab-0cd8a2ef9564', '82f5462d-b629-478d-898a-1d7ab85e8bdd')
INSERT [dbo].[PizzaIngredient] ([PizzaIngredientId], [PizzaId], [IngredientId]) VALUES ('cc3f623d-6731-486a-b0b4-27d3ebc02521', '606ddcc6-5a45-420b-ae10-5f6395eff827', 'bbb7ee8a-2caf-4c4e-baea-9ad4da3ac9df')
GO