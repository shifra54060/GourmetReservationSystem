USE fingerFoodStore;

INSERT INTO Products (Name, CategoryCode, Description, Price, ImageUrl, UpdateDate, Size, IsGlutenFree, IsVegan) VALUES
('גלידת וניל עם פצפוצי שוקולד', 7, 'גלידת וניל עשירה עם פצפוצי שוקולד קרים', 18, '/images/icecream_vanilla_choco.jpg', GETDATE(), '100ml', 0, 0),
('גלידת תותים טבעית', 7, 'גלידת תותים טריים ללא חומרים משמרים', 20, '/images/icecream_strawberry.jpg', GETDATE(), '100ml', 1, 1),
('סורבה מנגו', 7, 'סורבה מרענן מטעם מנגו טבעי', 22, '/images/sorbet_mango.jpg', GETDATE(), '120ml', 1, 1),
('עוגת שוקולד שוקולדית', 7, 'עוגת שוקולד עשירה עם קרם שוקולד', 35, '/images/cake_chocolate.jpg', GETDATE(), '250g', 0, 0),
('עוגת גבינה ניו יורקית', 7, 'עוגת גבינה קלאסית עם תחתית ביסקוויטים', 32, '/images/cake_cheesecake.jpg', GETDATE(), '200g', 0, 0),
('עוגת שוקולד ופיסטוק', 7, 'עוגת שוקולד עם שכבות פיסטוק וקרם', 38, '/images/cake_choco_pistachio.jpg', GETDATE(), '250g', 0, 0),
('סניקרס קפוא', 7, 'גלידת סניקרס עשירה עם שכבות קרמל ושוקולד', 25, '/images/icecream_snickers.jpg', GETDATE(), '120ml', 0, 0),
('מוס שוקולד פרווה', 7, 'מוס שוקולד קליל וטבעוני', 28, '/images/mousse_chocolate.jpg', GETDATE(), '150g', 1, 1),
('גלידת פטל-לימון', 7, 'גלידה מרעננת בטעמים של פטל ולימון', 20, '/images/icecream_raspberry_lemon.jpg', GETDATE(), '100ml', 1, 1),
('סלט יווני', 1, 'סלט עם עגבניות, מלפפונים, זיתים וגבינת פטה', 35, '/images/salad_greek.jpg', GETDATE(), '250g', 1, 0),
('סלט קינואה', 1, 'סלט קינואה עם ירקות טריים ועשבי תיבול', 40, '/images/salad_quinoa.jpg', GETDATE(), '200g', 1, 1),
('כריך חביתה עם ירקות', 2, 'לחם מלא, חביתה וירקות טריים', 25, '/images/sandwich_egg.jpg', GETDATE(), '1 יחידה', 0, 0),
('כריך טופו ואבוקדו', 2, 'לחם מחיטה מלאה עם טופו ואבוקדו', 30, '/images/sandwich_tofu.jpg', GETDATE(), '1 יחידה', 1, 1),
('מגש אירוח קוקטייל', 3, 'מגוון finger foods קרים', 150, '/images/platter_cocktail.jpg', GETDATE(), '1 מגש', 0, 0),
('קינוח טרמיסו', 7, 'קינוח איטלקי קלאסי', 20, '/images/dessert_tiramisu.jpg', GETDATE(), '150g', 0, 0),
('מיץ תפוזים טבעי', 6, 'מיץ סחוט טרי', 15, '/images/juice_orange.jpg', GETDATE(), '300ml', 1, 1),
('מאפה גבינה', 8, 'מאפה גבינה עשיר וטעים', 12, '/images/pastry_cheese.jpg', GETDATE(), '1 יחידה', 0, 0);
INSERT INTO Category (Name) VALUES
('סלטים'),
('כריכים'),
('מגשי אירוח'),
('חלבי'),
('חגים מיוחדים'),
('משקאות'),
('קינוחים'),
('מאפים');

select*from Category
select*from Products

INSERT INTO Products (Name, CategoryCode, Description, Price, ImageUrl, UpdateDate, Size, IsGlutenFree, IsVegan) VALUES
('מיני פיתות', 2, 'פיתה עם עגבניות, מלפפונים, זיתים וגבינת פטה', 80, 'כריכים\מיני-פותות-כריכים-טבעוניים-מגשי-אירוח-פינגר-פוד-קייטרינגר-לאירועים.webp', GETDATE(), '250g', 1, 0)
