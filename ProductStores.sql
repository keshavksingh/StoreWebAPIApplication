CREATE TABLE Product (ProductId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
ProductName VARCHAR(100) NOT NULL,
ProductPrice INT NULL,
DateModified Datetime NOT NULL DEFAULT GETDATE());


INSERT INTO Product (ProductName,ProductPrice)
VALUES('Marshall Stanmore II',229);


INSERT INTO Product (ProductName,ProductPrice)
VALUES('Marshall Acton II',250);

INSERT INTO Product (ProductName,ProductPrice)
VALUES('Marshall Kilburn',200);


SELECT * FROM Product;
SELECT * FROM Store;


CREATE TABLE Store (StoreId UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
StoreName VARCHAR(100) NOT NULL,
ProductId UNIQUEIDENTIFIER NOT NULL
)

INSERT INTO Store (StoreName,ProductId)
VALUES ('Best Buy','661A0264-62A6-4461-919D-025DC3F82ADF'),
('Target','4B3D2C60-A597-496F-92AF-5B2E13221075'),
('Walmart','0301FB6A-0632-4AD2-B4AA-5BEC941A2034')