SELECT * FROM Users
SELECT * FROM Poslovnica_Users WHERE UserId = 234

SELECT [Broj poslovnice] FROM Poslovnica P 
left outer join Poslovnica_Users PU on P.PoslovnicaId = PU.PoslovnicaId
left outer join Users U on PU.UserId = U.UserId
WHERE U.UserId=220

SELECT * FROM Poslovnica WHERE [Broj poslovnice] = 'tommy100'

SELECT * FROM Report



