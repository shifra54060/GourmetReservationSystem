use master
go
create database fingerFoodStore collate hebrew_100_ci_as
USE fingerFoodStore;

ALTER TABLE Customers
ADD address VARCHAR(100);


CREATE TABLE Category
(
CategoryCode INT IDENTITY(1,1) NOT NULL,
Name VARCHAR(20) NOT NULL,
CONSTRAINT PK_Category PRIMARY KEY(CategoryCode)
)

DELETE FROM Category;
INSERT INTO Category (Name) VALUES
('סלטים שף'),
('דגים מן הים'),
('תפריט צהריים עסקי'),
('בוקר גורמה'),
('חלבי קלאסי'),
('טבעוני מעודן'),
('משקאות פרימיום'),
('קינוחי שף');

select*from Category
select*from Products
SELECT 
    p.ProductCode,
    p.Name AS ProductName,
    p.Description,
    p.Price,
    p.ImageUrl,
    p.UpdateDate,
    p.Size,
    p.IsGlutenFree,
    p.IsVegan,
    c.CategoryCode,
    c.Name AS CategoryName
FROM Products p
INNER JOIN Category c
    ON p.CategoryCode = c.CategoryCode;


ALTER TABLE Products
ALTER COLUMN Description NVARCHAR(255);

CREATE TABLE Products
(
ProductCode INT IDENTITY(1,1) NOT NULL,
Name VARCHAR(50) NOT NULL,
CategoryCode INT NOT NULL,
 Description VARCHAR(100) NOT NULL,
 Price INT NOT NULL,
 ImageUrl VARCHAR(100) NOT NULL,
 UpdateDate DATE  NULL,
 Size VARCHAR(20) NULL,
 IsGlutenFree BIT NULL,
 IsVegan BIT NULL
CONSTRAINT PK_Products PRIMARY KEY(ProductCode),
CONSTRAINT fK_Products_Category FOREIGN KEY(CategoryCode) REFERENCES Category(CategoryCode)
)


ALTER TABLE Products
ALTER COLUMN UpdateDate DATE NULL;

select*from Customers

CREATE TABLE Customers
(
CustomerCode INT IDENTITY(1,1) NOT NULL,
FullName VARCHAR(100) NOT NULL,
 PhoneNumber VARCHAR(15) NULL,
Email VARCHAR(20) NOT NULL,
address VARCHAR(100) NOT NULL,
 BirthDate DATE NULL,
CONSTRAINT PK_Customers PRIMARY KEY(CustomerCode)
)
select*from Shopping

ALTER TABLE Shopping
ADD TotalAmount DECIMAL(10,2) NULL;
DELETE FROM Shopping;
CREATE TABLE Shopping (
    ShoppingCode INT IDENTITY(1,1) NOT NULL,
    CustomerCode INT NOT NULL,
    OrderDate DATE NOT NULL,
	TotalAmount decimal(10,2) NULL,
    Remark VARCHAR(30) NULL,
    CONSTRAINT PK_Shopping PRIMARY KEY (ShoppingCode),
    CONSTRAINT FK_Shopping_Customers FOREIGN KEY (CustomerCode) REFERENCES Customers(CustomerCode)
)
select*from Shopping
select*from ShoppingDetails
CREATE TABLE ShoppingDetails
(
ShoppingDetailsCode INT IDENTITY(1,1) NOT NULL,
ShoppingCode INT NOT NULL,
ProductCode INT NOT NULL,
Quantity INT NOT NULL,
CONSTRAINT PK_ShoppingDetails PRIMARY KEY(ShoppingDetailsCode),
CONSTRAINT fK_ShoppingDetails_Shopping FOREIGN KEY(ShoppingCode) REFERENCES Shopping(ShoppingCode),
CONSTRAINT fK_ShoppingDetails_Products FOREIGN KEY(ProductCode) REFERENCES Products(ProductCode),
)
DELETE FROM Tables;
select*from Tables
INSERT INTO Tables (TableNumber, Seats, IsOccupied)
VALUES
(1, 2, 0),
(2, 4, 0),
(3, 6, 1),
(4, 2, 0),
(5, 4, 1),
(6, 6, 0),
(7, 8, 0),
(8, 4, 1),
(9, 2, 0),
(10, 4, 0),
(11, 6, 0),
(12, 2, 1),
(13, 4, 0),
(14, 6, 0),
(15, 8, 1),
(16, 2, 0),
(17, 4, 1),
(18, 6, 0),
(19, 2, 0),
(20, 4, 1),
(21, 6, 0),
(22, 8, 0),
(23, 4, 0),
(24, 2, 1);
CREATE TABLE Tables (
    TableId INT IDENTITY(1,1) PRIMARY KEY,
    TableNumber INT NOT NULL,
    Seats INT NOT NULL,
    IsOccupied BIT DEFAULT 
);
ALTER TABLE Products
ALTER COLUMN Name VARCHAR(50) NOT NULL;
DELETE FROM ShoppingDetails
DELETE FROM Products;
select*from Products
select*from Category
INSERT INTO Products (Name, CategoryCode, Description, Price, ImageUrl, UpdateDate, Size, IsGlutenFree, IsVegan) VALUES
('פילה סלמון אטלנטי צרוב', 10, 'פילה סלמון צרוב בעור קריספי, מוגש על מצע ירקות ירוקים עונתיים ורוטב שמפניה חמצמץ.', 125, 'fish/fish (4).jpg', GETDATE(), 'large', 1, 0),
('שיפודי סלמון בגריל על רוקט', 10, 'קוביות סלמון טרי צלוי בגריל, בציפוי זיגוג עשבי תיבול, מוגש על מצע עלי רוקט טריים.', 98, 'fish/fish (8).jpg', GETDATE(), 'medium', 1, 0),
('שיפודי סלמון ולימון עם צימיצורי', 10, 'נתחי סלמון ופרוסות לימון צרובים, מוברשים ברוטב צ׳ימיצ׳ורי ירוק עז ופיקנטי.', 105, 'fish/fish (5).jpg', GETDATE(), 'medium', 1, 0),
('טארטאר סלמון מעושן ואבוקדו', 10, 'סלמון מעושן מגולגל על קוביות קרם אבוקדו מתובל, בעיטור שומר וגרגרי שומשום שחור.', 85, 'fish/fish (3).jpg', GETDATE(), 'small', 1, 0),
('פילה דג לבן על מצע תרד ורוטב חמאה-לימון', 10, 'פילה דג ים צלוי, מוגש על תרד מוקפץ ברוטב קטיפתי עשיר של חמאה חומה ולימון.', 118, 'fish/fish (2).jpg', GETDATE(), 'large', 1, 0),
('גלילות מלפפונים וסלמון מעושן', 10, 'מתאבנים אלגנטיים של סלמון מעושן, מגולגל בתוך פרוסות מלפפון דקיקות עם גבינת שמנת ועירית.', 72, 'fish/fish (1).jpg', GETDATE(), 'small', 1, 0),
('דג ים צלוי ברוטב שמנת ותרד', 10, 'פילה דג ים בשרני אפוי בתנור, שוחה ברוטב שמנת, תרד טרי וצנוברים קלויים.', 130, 'fish/fish (6).jpg', GETDATE(), 'large', 1, 0),
('סלמון צרוב עם אספרגוס ופירה שף', 10, 'פילה סלמון צלוי עם פסי גריל עדינים, מוגש על אספרגוס טרי ופירה תפוחי אדמה חלבי.', 128, 'fish/fish (7).jpg', GETDATE(), 'large', 1, 0),
('סלמון בקרם פטריות ושמנת', 10, 'פילה סלמון עשיר ברוטב שמנת פטריות פורצ׳יני, מונח על מצע תרד חלוט.', 115, 'fish/fish (9).jpg', GETDATE(), 'medium', 1, 0),
('טארטאר סלמון ואבוקדו מגדל', 10, 'מגדל אלגנטי של סלמון קצוץ טרי על אבוקדו מתובל, עם עלי רוקט ולימון כבוש.', 92, 'fish/fish (10).jpg', GETDATE(), 'small', 1, 0),
('מוס רויאל שוקולד כהה', 16, 'כיפת מוס שוקולד כהה עשיר ומבריק, על בסיס פירורי קקאו קראנצ׳י, מוגש עם שבבי שוקולד מריר ועיטור עלי בזיליקום עדינים.', 65, 'desert/desert (27).jpg', GETDATE(), 'small', 0, 0),
('מגדל קרמל מלוח ושקדים', 16, 'מוס וניל לבן-שמנת בציפוי כדור שוקולד מבריק, ניגר ברוטב קרמל מלוח חם, מוגש עם שקדים פרוסים קלויים.', 68, 'desert/desert (26).jpg', GETDATE(), 'small', 1, 0),
('שוט קרם אגוזי לוז ופרלין', 16, 'מוס שוקולד אגוזי לוז קטיפתי מוגש בכוס שוט, על מצע קראסט פריך של פירורי ביסקוויט ואגוזים, מעוטר בשבבי פרלין קלוי.', 58, 'desert/desert (30).jpg', GETDATE(), 'small', 0, 0),
('שכבות פאדג׳ בוטנים-קרמל', 16, 'ריבוע בראוניז פאדג׳ שוקולד עשיר עם שכבת קרם בוטנים מלוח, מוזרם ברוטבי שוקולד מריר וקרמל, בתוספת גלידת וניל ובוטנים מקורמלים.', 75, 'desert/desert (23).jpg', GETDATE(), 'large', 0, 0),
('פארפה שיבולת שועל ופירות טרופיים', 16, 'שכבות של פודינג צ׳יה-חלב קוקוס, מנגו טרי, פטל וקיווי, עם תערובת פירות יער אקזוטיים ומנטה טרייה.', 55, 'desert/desert (24).jpg', GETDATE(), 'small', 1, 1),
('מקרון יין אדום וגבינת שמנת', 16, 'עוגיות מקרון קטיפתיות בצבע יין אדום, במילוי קרם גבינת שמנת עשיר ונגיעת מייפל, מעוטרות באגוזי מלך ועלעלים ירוקים.', 62, 'desert/desert (25).jpg', GETDATE(), 'small', 1, 0),
('מקרון "עץ חג" פיסטוק ורימון', 16, 'מגדל מיניאטורי של מקרונים ירוקים בטעם פיסטוק, במילוי קרם וניל עשיר, מעוטר בגרגרי רימון ובכוכב זהב אכיל.', 60, 'desert/desert (28).jpg', GETDATE(), 'small', 1, 0),
('עוגת לבה שוקולד חמה וקצפת', 16, 'עוגת שוקולד חמה אישית עם לב שוקולד נוזלי, מעליה כדור קצפת וניל, סירופ שוקולד כהה ותותים טריים ושקדים מולבנים.', 70, 'desert/desert (29).jpg', GETDATE(), 'medium', 0, 0),
('בראוניז קרמל חם עם גלידת וניל', 16, 'בראוניז שוקולד פאדג׳י, בציפוי קרם וניל חמאתי ושכבת שוקולד מבריקה, מוגש עם גלידת וניל וקוביות קרמל קראנצ׳י.', 72, 'desert/desert (31).jpg', GETDATE(), 'medium', 0, 0),
('מוס רושה מגדל שוקולד וזהב', 16, 'מיני עוגת רושה (Rocher) שוקולד עשירה, מוס שוקולד חלב ומריר קטיפתי, ציפוי שוקולד מבריק ואגוזים, כדור שוקולד מוזהב מעל.', 68, 'desert/desert (15).jpg', GETDATE(), 'small', 0, 0),
('גלילות מקרמל אבוקדו וסלמון', 16, 'מקרונים מלוחים במילוי קרם גבינת שמנת ואבוקדו, גלילי סלמון מעושן, מעוטר שמיר ופלפל שחור גרוס.', 75, 'desert/desert (12).jpg', GETDATE(), 'small', 1, 0),
('פארפה וניל לימון ופירורים', 16, 'מוס לימון קליל ומרענן עם שכבות קראמבל חמאה פריך, מוגש בגביע, בעיטור פרוסת לימון טרייה ואוכמניות.', 62, 'desert/desert (18).jpg', GETDATE(), 'small', 0, 0),
('טריפל שכבות קיווי-ליים', 16, 'מיני עוגת גבינה-וניל על בסיס פריך, בציפוי גלייז ירוק בוהק בטעם קיווי וליים, עם פרוסת קיווי טרי מעל.', 60, 'desert/desert (21).jpg', GETDATE(), 'small', 0, 0),
('טירמיסו בוטנים-קרמל מלוח', 16, 'מיני צ׳יזקייק וניל קרמי על בסיס קראמבל פריך, מוזרם ברוטב קרמל מלוח, עם קצפת ובוטנים קלויים מלוחים.', 66, 'desert/desert (16).jpg', GETDATE(), 'small', 0, 0),
('שוקולד-בננה קראמבל קפה', 16, 'שכבות של מוס שוקולד חלב כהה וקרם קפה-בננה, מוגש עם קראמבל שוקולד לבן ומכוסה קצפת, פטל ושבבי שוקולד.', 63, 'desert/desert (17).jpg', GETDATE(), 'small', 0, 0),
('ג׳לי קוקטייל הדרים ופירות יער',16, 'שכבות ג׳לי במרקם עדין בטעמי תפוז, מנגו ווניל, בתוספת פטל צהוב וקצפת מעוטרת פרוסת תפוז טרייה.', 58, 'desert/desert (13).jpg', GETDATE(), 'small', 1, 1),
('מוס תה מאצ׳ה וקרמל ירוק', 16, 'שכבות מוס מאצ׳ה ירוק עז וקרם תה לבן, עם פס קרמל במרכז, מעוטר בסלסול שוקולד ירוק ומוס קראמבל מאצ׳ה.', 64, 'desert/desert (19).jpg', GETDATE(), 'small', 0, 0),
('טריקולור פירות יער ג׳לי',16, 'כוסות ג׳לי צבעוניות בשלוש שכבות אלכסוניות: ירוק, ורוד ואדום, עם פטל טרי ושבבי שוקולד מריר.', 55, 'desert/desert (20).jpg', GETDATE(), 'small', 1, 1),
('מקרוני פטל-פיסטוק בורדו', 16, 'עוגיות מקרון במילוי קרם פטל עז, מעוטרות בפיסטוקים גרוסים ופטל טרי.', 62, 'desert/desert (10).jpg', GETDATE(), 'small', 1, 0),
('כדורי שוקולד לבן ופירות יער', 16, 'כדורי שוקולד לבן במילוי מוס וניל וליבת פירות יער חמצמצה, מכוסים באבקת קקאו.', 68, 'desert/desert (5).jpg', GETDATE(), 'small', 0, 0),
('קרפ שוקולד נוטף וקוקוס', 16, 'גלילי קרפ צרפתי דקיקים במילוי קרם שמנת קטיפתי, מוזרמים בסירופ שוקולד עשיר ומעוטרים שבבי קוקוס.', 55, 'desert/desert (7).jpg', GETDATE(), 'medium', 0, 0),
('פחזניות קרם וניל ושוקולד', 16, 'מגדל פחזניות אווריריות במילוי קרם וניל, בציפוי גנאש שוקולד מבריק, מעוטר קצפת ושבבי שוקולד מריר.', 60, 'desert/desert (3).jpg', GETDATE(), 'medium', 0, 0),
('פנה קוטה פיטאיה מנגו', 16, 'קינוח פנה קוטה (קרם וניל לבן) עם שכבת מחית פיטאיה (פרי הדרקון) סגולה בוהקת, מעוטר קוביות פיטאיה.', 65, 'desert/desert (4).jpg', GETDATE(), 'small', 1, 0),
('מקרון פטריות ושמיר מעושן', 16, 'עוגיות מקרון קלאסיות במילוי קרם שמנת ואבוקדו, פרוסות סלמון מעושן, בתיבול עדין של שמיר ופלפל שחור.', 78, 'desert/desert (12).jpg', GETDATE(), 'small', 1, 0),
('גביע מוס שוקולד ואוראו', 16, 'מוס שוקולד עשיר וקטיפתי בגביע קוקטייל, עם קראמבל עוגיות שוקולד ומעליו קצפת מנטה וסירופ שוקולד מריר.', 64, 'desert/desert (11).jpg', GETDATE(), 'small', 0, 0),
('פנה קוטה וניל עם קולי פטל', 16, 'כוסות פנה קוטה קלאסית עם מוס וניל לבן ורוטב פטל-תות חמצמץ, מעוטרות פירות יער טריים ומנטה.', 60, 'desert/desert (14).jpg', GETDATE(), 'small', 1, 0),
('שחיתות שוקולד-פטל בכוס', 16, 'שכבות של מוס שוקולד כהה, קראמבל פריך וקצפת וניל, מעוטר בקוביות שוקולד ופטל אדום טרי.', 66, 'desert/desert (17).jpg', GETDATE(), 'small', 0, 0),
('גלידת שוקולד בלגי וקצפת', 16, 'כדורי גלידת שוקולד בלגי משובחת, מוגשים בגביע, מוזרמים בסירופ שוקולד חם ומעליהם קצפת וניל ושבבי שוקולד.', 58, 'desert/desert (9).jpg', GETDATE(), 'medium', 1, 0),
('טארט קראמבל פטל-גבינה', 16, 'מאפה קראמבל בצק עלים פריך במילוי גבינת שמנת וריבת פטל, מעוטר באוכמניות טריות וענפי טימין.', 55, 'desert/desert (6).jpg', GETDATE(), 'medium', 0, 0),
('טארטלט פיסטוק וקרנברי', 16, 'מיני טארט בסיס קראמבל פריך, מוס וניל, גלייז פיסטוק בוהק, מעוטר בקרנברי מיובש ופיסטוקים גרוסים.', 69, 'desert/desert (22).jpg', GETDATE(), 'small', 0, 0),
('מוס פטל וקרם וניל בשכבות', 16, 'מיני עוגת מוס מעודנת בשלוש שכבות: מוס פטל עז, מוס פטל-וניל בהיר ומוס וניל קטיפתי, מעוטרת בפטל טרי וקצפת קטיפתית.', 72, 'desert/desert (1).jpg', GETDATE(), 'small', 1, 0),
('מקרון פיסטוק וגרגרי ענבים', 16, 'עוגיית מקרון ירוקה ממולאת בקרם שמנת אוורירי, עם גרגרי ענבים ירוקים טריים, קצפת וניל ועיטור פרח אכיל.', 65, 'desert/desert (2).jpg', GETDATE(), 'small', 1, 0);

