USE [NORTHWND]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pr_GetOrderSummary]
	@StartDate DATE = NULL, 
	@EndDate DATE = NULL,
	@EmployeeID INT NULL,
	@CustomerID NCHAR(5) NULL
AS
BEGIN
	SET @StartDate = ISNULL(@StartDate, GETDATE())
	SET @EndDate = ISNULL(@EndDate, GETDATE())
		
	SELECT e.EmployeeFullName,
		   s.CompanyName as Shipper,
		   c.CompanyName as Customer,
		   COUNT(DISTINCT o.OrderID) as NumberOfOrders,
		   o.OrderDate as [Date],
		   SUM(o.Freight) as TotalFreightCost,
		   COUNT(DISTINCT p.ProductID) as NumberOfDifferentProducts,
		   SUM(od.Quantity * od.UnitPrice) as TotalOrderValue
	FROM Orders o
		INNER JOIN [Order Details] od ON od.OrderID = o.OrderID
		INNER JOIN Products p ON p.ProductID = od.ProductID
		INNER JOIN Shippers s ON s.ShipperId = o.ShipVia
		LEFT JOIN (SELECT EmployeeId, CONCAT(TitleOfCourtesy,' ', FirstName,' ', LastName) as EmployeeFullName FROM Employees) e ON e.EmployeeID = o.EmployeeID
		LEFT JOIN Customers c ON c.CustomerID = o.CustomerID
	WHERE o.OrderDate >= @StartDate AND o.OrderDate <= @EndDate
	  AND @EmployeeID IS NULL OR o.EmployeeID = @EmployeeID 
	  AND @CustomerID IS NULL OR o.CustomerID = @CustomerID
	GROUP BY o.OrderDate, e.EmployeeFullName, c.CompanyName, s.CompanyName
	ORDER BY o.OrderDate
END
GO
