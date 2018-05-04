SELECT Person.Name AS NameOfPerson, Church.Name AS LikesChurch, Church.YearOfConstruction, City.Name AS ChurchIsInCity
FROM Person	
INNER JOIN PeopleLikesChurches ON Person.ID=PeopleLikesChurches.Person
INNER JOIN Church ON PeopleLikesChurches.Church=Church.ID
INNER JOIN City ON Church.City=City.ID
