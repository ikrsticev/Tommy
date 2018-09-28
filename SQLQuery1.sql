SELECT * FROM Users
SELECT * FROM Poslovnica
INSERT INTO Poslovnica_Users VALUES (234,202)

SELECT [Broj poslovnice] FROM Poslovnica P 
left outer join Poslovnica_Users PU on P.PoslovnicaId = PU.PoslovnicaId
left outer join Users U on PU.UserId = U.UserId
WHERE U.UserId=220

SELECT * FROM Poslovnica WHERE [Broj poslovnice] = 'tommy100'

SELECT * FROM Report

truncate table Report

truncate table Logins

INSERT INTO Logins VALUES (CURRENT_TIMESTAMP, 4)

SELECT LoginId, Username, Vrijeme_prijave FROM Users U
left outer join Logins L on L.UserId = U.UserId
WHERE LoginId is not null





