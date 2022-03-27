SELECT P.name AS ProductName, C.name AS CategoryName FROM Product AS P
    LEFT JOIN Bridge AS B ON P.Id = B.ProductId
    LEFT JOIN Category AS C ON C.Id = B.CategoryId;
