/*Предполагается что в базе данных есть две таблицы
"Products" и "Categories" с атрибутами Id, Name
так как одному продукту может соответствовать много категорий, 
а в одной категории может быть много продуктов, то наблюдается связь многие ко многим
между продуктами и категориями
следователно, в базе необходимо хранить составную таблицу 
"ПродуктыКатегории" с составным первичным ключом для обхода данной связи
*/

CREATE TABLE ProductCategories (
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	PRIMARY KEY (ProductId, CategoryId)
);

SELECT P."Name", C."Name"
FROM Products P
LEFT JOIN ProductCategories PC
	ON P.Id = PC.ProductId
LEFT JOIN Categories C
	ON PC.CategoryId = C.Id;