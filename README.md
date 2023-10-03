# Tentamen
Tentamen C#

Nedan följer instruktioner för hur du ska göra för att köra programmet och fylla det med information. Var noga med stavningen med stora och små bokstäver.


_____________________Instruktioner___________________________________


1. Ändra den connection string som finns i appsettings.json till din egna.
2. Se till att databasen heter HemTenta i connection stringen OBS!! viktigt med stavningen.
3. Uppdatera därefter databasen med kommandot Update-database i Package manager console. 
4. Använd den medföljande SQL-koden i Microsoft SQL Server Management Studio för att fylla tabellerna med data. Refresh database så HemTenta dyker upp, skapa en query och kör koden nedan.
5. Starta programmet och all information bör ha matats in om du utfört alla steg korrekt.

Lycka till!


_____________________Kopiera koden nedan till SQL Server Management Studio_____________________________________________


USE HemTenta

  INSERT INTO Books (Title, ISBN, Inhouse, CheckedOut)
VALUES
('The Fellowship of the Ring', '9780261102354', 1, 0),
('The Two Towers', '9780547928203', 0, 1),
('The Two Towers', '9780547928203', 0, 1),
('The Return of the King', '9780261102385', 1, 0),
('The Return of the King', '9780261102385', 1, 0),
('Harry Potter and the Prisoner of Azkaban', '9780439136365', 0, 1),
('Harry Potter and the Chamber of Secrets', '9780439064873', 1, 0),
('Harry Potter and the Chamber of Secrets', '9780439064873', 0, 1),
('Harry Potter and the Order of Phoenix', '9780439358071', 0, 1),
('Harry Potter and the Half-Blood Prince', '9780439785969', 1, 0),
('Harry Potter and the Half-Blood Prince', '9780439785969', 1, 0),
('Harry Potter and the Deathly Hallows', '9780545139700', 0, 1),
('Harry Potter and the Deathly Hallows', '9780545139700', 1, 0),
('Harry Potter and the Cursed Child', '9781338099133', 0, 1),
('The Nightingale', '9781250080400', 1, 0),
('Romeo and Juliet', '9780671722852', 0, 1),
('The Firm', '‎9780440245926', 1, 0);

INSERT INTO Author (Name)
VALUES
('J.R.R. Tolkien'),
('J.K. Rowling'),
('Kristin Hannah'),
('Shakespeare'),
('John Grisham');

  INSERT INTO AuthorBook (AuthorId, BooksId)
VALUES
(1, 1),(1, 2),(1, 3),(1, 4),
(1, 5),(2, 6),(2, 7),(2, 8),
(2, 9),(2, 10),(2, 11),(2, 12),
(2, 13),(2, 14),(3, 15),(4, 16),
(5, 17);

INSERT INTO Genres (Name)
VALUES
('Fantasy'), ('Fiction'), ('Adventure'), 
('Roman'), ('Thriller'), ('Romance');

INSERT INTO BookGenre (BooksId, GenresId)
VALUES
(1, 1),(1, 2),(2, 1),(2, 2),
(3, 1),(3, 2),(4, 1),(4, 2),
(5, 1),(5, 2),(6, 1),(6, 3),
(7, 1),(7, 3),(8, 1),(8, 3),
(9, 1),(9, 3),
(10, 1),(10, 3),(11, 1),(11, 3),
(12, 1),(12, 3),(13, 1),(13, 3),
(14, 1),(14, 3),(15, 4),(16, 6),
(17, 5);

INSERT INTO Users (Name, LastName, Adress, PhoneNumber)
VALUES
    ('Henke', 'Larsson', '123 Celtic', '543-1234'),
    ('Lionel', 'Messi', '456 Barca', '543-5678'),
    ('Cristiano', 'Ronaldo', '789 Manchester', '543-9012'),
    ('Janne', 'Andersson', '321 Stockholm', '543-3456'),
    ('Luca', 'Modric', '654 Madrid', '543-7890');

INSERT INTO Loans (LoanDate, DueDate, BookId, UserId)
VALUES 
    ('2023-05-07', '2023-05-14', 1, 1),
    ('2023-05-08', '2023-05-15', 2, 2),
    ('2023-05-09', '2023-05-16', 3, 3),
    ('2023-05-10', '2023-05-17', 4, 4),
    ('2023-05-11', '2023-05-18', 5, 5);

INSERT INTO BookClubs(Name)
VALUES
('ReadingCorner'),('Turn the Page'), ('Storytale');

INSERT INTO BookClubUser(BookClubsId, usersId)
VALUES
    (1, 1),
    (1, 3),
    (2, 2),
    (2, 5),
    (2, 4),
    (3, 1),
    (3, 5);
