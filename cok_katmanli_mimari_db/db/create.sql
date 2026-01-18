
IF DB_ID(N'MultiLayerDemo') IS NULL
BEGIN
    CREATE DATABASE MultiLayerDemo;
END
GO
USE MultiLayerDemo;
GO
IF OBJECT_ID(N'dbo.Products', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Products
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Name NVARCHAR(200) NOT NULL,
        Price DECIMAL(18,2) NOT NULL
    );
END
GO