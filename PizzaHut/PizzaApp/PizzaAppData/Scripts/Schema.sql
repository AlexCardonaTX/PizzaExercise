USE [PizzaAppDB]
GO
CREATE TABLE [dbo].[Pizza](
	[PizzaId] [uniqueidentifier] PRIMARY KEY,
	[PizzaName] [nvarchar](150) NOT NULL
)
GO
CREATE TABLE [dbo].[Ingredient](
	[IngredientId] [uniqueidentifier] PRIMARY KEY,
	[IngredientName] [nvarchar](150) NOT NULL
)
GO
CREATE TABLE [dbo].[PizzaIngredient] (
	[PizzaIngredientId] [uniqueidentifier] PRIMARY KEY,
	[PizzaId] [uniqueidentifier] NOT NULL,
	[IngredientId] [uniqueidentifier] NOT NULL,
)
GO
alter table [dbo].[PizzaIngredient] add constraint [FK_Pizza_Ingredient] foreign key (PizzaId) references Pizza(PizzaId)
GO
alter table [dbo].[PizzaIngredient] add constraint [FK_Ingredient_Pizza] foreign key (IngredientId) references Ingredient(IngredientId)
GO