CREATE TABLE Movies (
    MovieID INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Year INT,
    Genre VARCHAR(100),
    Description TEXT,
    Director VARCHAR(255),
    Actors TEXT,
    AverageRating FLOAT
);

CREATE TABLE Reviews (
    ReviewID INT AUTO_INCREMENT PRIMARY KEY,
    MovieID INT,
    Opinion TEXT,
    Rating INT CHECK (Rating >= 1 AND Rating <= 10),
    ReviewDate DATETIME,
    Author VARCHAR(255),
    FOREIGN KEY (MovieID) REFERENCES Movies(MovieID)
);
