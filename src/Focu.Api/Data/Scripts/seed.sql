INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Food', 'Food and beverage expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Health', 'Health and wellness expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Transport', 'Transportation and vehicle costs', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Housing', 'Home-related expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Education', 'Education and course expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Entertainment', 'Entertainment activities expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Clothing', 'Clothing expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Investments', 'Investments and financial applications', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Taxes', 'Tax and fee payments', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Travel', 'Travel and tourism expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Gifts', 'Gifts and donations expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Beauty', 'Beauty and personal care expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Pets', 'Pet expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Phone', 'Phone and internet costs', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Insurance', 'Various insurance payments', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Mental Health', 'Psychology and therapy expenses', 'teste@balta.io');
INSERT INTO [dbo].[Category] (Title, Description, UserId) VALUES ('Fitness', 'Gym and physical activities expenses', 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Grocery shopping', '2024-01-05', '2024-01-05', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Food'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Gym membership', '2024-01-10', '2024-01-10', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Fitness'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Bus ticket', '2024-01-15', '2024-01-15', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transport'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Course books', '2024-01-20', '2024-01-20', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Education'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Salary', '2024-01-25', '2024-01-25', 1, 5000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Medical appointment', '2024-01-26', '2024-01-26', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Health'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Dinner out', '2024-01-27', '2024-01-27', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Entertainment'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Dog food', '2024-01-28', '2024-01-28', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Life insurance payment', '2024-01-29', '2024-01-29', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Insurance'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Netflix subscription', '2024-02-02', '2024-02-02', 2, -45.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Entertainment'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('New clothes', '2024-02-06', '2024-02-06', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Clothing'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Car repair', '2024-02-11', '2024-02-11', 2, -800.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transport'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Haircut', '2024-02-15', '2024-02-15', 2, -50.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Beauty'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Book purchase', '2024-02-18', '2024-02-18', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Education'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Travel refund', '2024-02-20', '2024-02-20', 1, 1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Travel'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('February rent', '2024-02-25', '2024-02-25', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Housing'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Vehicle tax', '2024-02-27', '2024-02-27', 2, -400.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Taxes'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Vet appointment', '2024-02-28', '2024-02-28', 2, -180.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Birthday dinner', '2024-02-28', '2024-02-28', 2, -250.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Entertainment'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Monthly salary', '2024-03-01', '2024-03-01', 1, 5000.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Investments'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Electricity bill', '2024-03-02', '2024-03-02', 2, -120.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Housing'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Water bill', '2024-03-05', '2024-03-05', 2, -80.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Housing'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('School tuition', '2024-03-10', '2024-03-10', 2, -600.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Education'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Clothing purchase', '2024-03-12', '2024-03-12', 2, -300.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Clothing'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Supplements purchase', '2024-03-15', '2024-03-15', 2, -200.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Health'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Family restaurant', '2024-03-18', '2024-03-18', 2, -250.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Food'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Phone plan', '2024-03-20', '2024-03-20', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Phone'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Weekend trip', '2024-03-22', '2024-03-22', 2, -800.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Travel'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Car insurance payment', '2024-03-24', '2024-03-24', 2, -400.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Insurance'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, [Type], Amount, CategoryId, UserId)
VALUES ('Art supplies', '2024-03-26', '2024-03-26', 2, -150.00, (SELECT TOP 1 Id FROM [dbo].[Category] WHERE Title='Entertainment'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Freelance income', '2024-05-02', '2024-05-02', 1, 2200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Internet bill', '2024-05-05', '2024-05-05', 2, -89.99, (SELECT Id FROM [dbo].[Category] WHERE Title='Phone'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Transport expense', '2024-05-07', '2024-05-07', 2, -160.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Transport'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Book purchase', '2024-05-09', '2024-05-09', 2, -120.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Education'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Salary', '2024-05-10', '2024-05-10', 1, 4000.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Rent payment', '2024-05-12', '2024-05-12', 2, -1500.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Housing'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Dinner expense', '2024-05-15', '2024-05-15', 2, -200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Food'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Medical consultation', '2024-05-18', '2024-05-18', 2, -300.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Health'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Pet food', '2024-05-20', '2024-05-20', 2, -75.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Pets'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Birthday gift', '2024-05-22', '2024-05-22', 2, -150.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Gifts'), 'teste@balta.io');

INSERT INTO [dbo].[Transaction] (Title, CreatedAt, PaidOrReceivedAt, Type, Amount, CategoryId, UserId)
VALUES ('Bonus', '2024-05-24', '2024-05-24', 1, 1200.00, (SELECT Id FROM [dbo].[Category] WHERE Title='Investments'), 'teste@balta.io');

INSERT INTO [Product] VALUES('Annual Plan', '1 year platform access', 'annual-plan', 1, 799.90)

