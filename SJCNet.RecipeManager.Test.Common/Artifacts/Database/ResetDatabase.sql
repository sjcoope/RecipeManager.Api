-- Delete data
DELETE FROM Recipe
DELETE FROM Ingredient
DELETE FROM Measurement
DELETE FROM Product
DELETE FROM Step
DELETE FROM Tag
DELETE FROM [User]
DELETE FROM Category

-- Reset Auto ID Fields
DECLARE @Reseed int = 0
DBCC CHECKIDENT('Recipe',RESEED, @Reseed)
DBCC CHECKIDENT('Ingredient',RESEED, @Reseed)
DBCC CHECKIDENT('Measurement',RESEED, @Reseed)
DBCC CHECKIDENT('Product',RESEED, @Reseed)
DBCC CHECKIDENT('Step',RESEED, @Reseed)
DBCC CHECKIDENT('Tag',RESEED, @Reseed)
DBCC CHECKIDENT('[User]',RESEED, @Reseed)
DBCC CHECKIDENT('Category',RESEED, @Reseed)