########## Star Wars (plusieurs ´episodes) ##########
SELECT *
FROM Movie
WHERE Movie.Id IN (11, 12180, 130654, 140607, 181808)

########## Harrison Ford ou Tom Hanks (acteurs connus dans des films connus à repérer facilement dans quelques films) ##########
SELECT *
FROM ActorMovie INNER JOIN Movie ON ActorMovie.MoviesId = Movie.Id
				INNER JOIN Actor ON ActorMovie.ActorsId = Actor.Id
WHERE ActorMovie.ActorsId IN (3, 31)

########## Harrison Ford (dans Star Wars et Apocalypse Now) ##########
SELECT *
FROM ActorMovie INNER JOIN Movie ON ActorMovie.MoviesId = Movie.Id
				INNER JOIN Actor ON ActorMovie.ActorsId = Actor.Id
WHERE ActorMovie.MoviesId IN (11, 28, 140607) AND ActorMovie.ActorsId = 3

########## Mrs Doubtfire (dans lequel Robin Williams joue plusieurs rôles) ##########
SELECT *
FROM Role INNER JOIN Movie ON Role.MovieId = Movie.Id
		  INNER JOIN Actor ON Role.ActorId = Actor.Id
WHERE Role.MovieId = 288148 AND Role.ActorId = 589651