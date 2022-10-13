CREATE TABLE venue (
  [venue_id] int NOT NULL IDENTITY,
  [venue_name] varchar(100),
  [venue_location] varchar(100),
  [capacity] int,
  PRIMARY KEY ([venue_id])
);

CREATE TABLE genre (
  [genre_id] int NOT NULL IDENTITY,
  [genre_name] varchar(100),
  PRIMARY KEY ([genre_id])
);

CREATE TABLE Artist (
  [artist_id] int NOT NULL IDENTITY,
  [artist_name] varchar(100),
  [genre_id] int,
  PRIMARY KEY ([artist_id]),
  FOREIGN KEY ([genre_id]) REFERENCES genre([genre_id])
);

CREATE TABLE Customer (
  [customer_id] int NOT NULL IDENTITY,
  [customer_name] varchar(100),
  [user_name] varchar(100),
  [password] varchar(100),
  [email] varchar(100),
  PRIMARY KEY ([customer_id])
);

CREATE TABLE Concert (
  [concert_id] int NOT NULL IDENTITY,
  [concert_name] varchar(100),
  [artist_id] int,
  [date] date,
  [start_time] time(0),
  [end_time] time(0),
  [venue_id] int,
  [image_path] varchar(100),
  PRIMARY KEY ([concert_id]),
  FOREIGN KEY ([venue_id]) REFERENCES venue([venue_id])
);

CREATE TABLE Ticket (
  [ticket_id] int NOT NULL IDENTITY,
  [price] float,
  [concert_id] int,
  [ticket_amount] int,
  PRIMARY KEY ([ticket_id]),
  FOREIGN KEY ([concert_id]) REFERENCES Concert([concert_id])
);

CREATE TABLE customer_order (
  [order_id] int NOT NULL IDENTITY,
  [customer_id] int,
  [total_price] float,
  [ticket_id] int,
  [vip] bit,
  [ticket_amount] int,
  PRIMARY KEY ([order_id]),
  FOREIGN KEY ([ticket_id]) REFERENCES Ticket([ticket_id])
);


--------------------CUSTOMERS
	INSERT INTO Customer (customer_name, user_name, password) VALUES ('Adonias Worku', 'Adoni', 'adoni123');
	INSERT INTO Customer (customer_name, user_name, password) VALUES ('Kunuz Mohammed', 'Kunuz', 'kunuz123');
	INSERT INTO Customer (customer_name, user_name, password) VALUES ('Leulseged Lemma', 'Leula', 'leula123');
	INSERT INTO Customer (customer_name, user_name, password) VALUES ('Mattathias Abraham', 'Matti', 'matti123');
	INSERT INTO Customer (customer_name, user_name, password) VALUES ('ADMINSTRATOR', 'Admin', 'admin123');

--------------------ARTISTS
	INSERT INTO artist (artist_name, genre_id) VALUES ('Rophnan', 1);
	INSERT INTO artist (artist_name, genre_id) VALUES ('Hewan Gebrewold', 6);
	INSERT INTO artist (artist_name, genre_id) VALUES ('Kassmasse', 2);
	INSERT INTO artist (artist_name, genre_id) VALUES ('jemberu Demke', 4);
	INSERT INTO artist (artist_name, genre_id) VALUES ('Gigi', 3);
	INSERT INTO artist (artist_name, genre_id) VALUES ('Teddy Afro', 1);

--------------------GENRES
	INSERT INTO genre (genre_name) VALUES ('EDM');
	INSERT INTO genre (genre_name) VALUES ('Antsar');
	INSERT INTO genre (genre_name) VALUES ('trip hop');
	INSERT INTO genre (genre_name) VALUES ('hip hop / rap');
	INSERT INTO genre (genre_name) VALUES ('Reggae fusion');
	INSERT INTO genre (genre_name) VALUES ('Maghreb Pop');

--------------------VENUES
	INSERT INTO venue (venue_name, venue_location, capacity) VALUES ('Millennium Hall', 'Bole 3, 5, Addis Ababa', 1000);
	INSERT INTO venue (venue_name, venue_location, capacity) VALUES ('Fana bole 17/18 hall', 'Bole, Addis Ababa', 500);
	INSERT INTO venue (venue_name, venue_location, capacity) VALUES ('Addis Ababa stadium', 'stadium, Addis Ababa', 35000);
	INSERT INTO venue (venue_name, venue_location, capacity) VALUES ('Red Carpet Hall', 'Akaki Kality, Addis Ababa', 450);
	INSERT INTO venue (venue_name, venue_location, capacity) VALUES ('Kebena House Events', 'Kebena, Addis Ababa', 300);
	INSERT INTO venue (venue_name, venue_location, capacity) VALUES ('Ethiopian National Theatre', 'Beharawi mexico, Addis Ababa', 860);
	SELECT * FROM venue;

--------------------CONCERTS
	INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES ('XI', 1, '2022-12-06', '07:15:00', '10:30:00',1, 'rophnan.jpg');
	INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES ('Hewan', 2, '2022-11-02', '06:00:00', '09:30:00', 2, 'Hewan.png');
	INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES ('Bahel | Weg', 3, '2022-10-18', '08:15:00', '10:00:00', 3, 'kassmasse.png');
	INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES ('Tizita', 4, '2022-12-12', '07:15:00', '09:45:00', 4, 'Jemberu.png');
	INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES ('Guramayle', 5, '2022-09-05', '08:05:00', '10:05:00', 5, 'gigi.png');
	INSERT INTO concert (concert_name, artist_id, date, start_time, end_time, venue_id, image_path) VALUES ('Fikir-Ashenfe', 6, '2022-11-29', '07:15:00', '10:30:00', 6, 'teddyafro.png');

--------------------TICKETS
	INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (799, 1, 487);
	INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (599, 2, 7);
	INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (500, 3, 2);
	INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (455, 4, 692);
	INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (890, 5, 12);
	INSERT INTO ticket (price, concert_id, ticket_amount) VALUES (999, 6, 3);