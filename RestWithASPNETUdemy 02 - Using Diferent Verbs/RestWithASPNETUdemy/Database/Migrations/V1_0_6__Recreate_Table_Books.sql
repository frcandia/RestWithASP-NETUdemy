DROP TABLE books;

CREATE TABLE books (
  Id BIGINT AUTO_INCREMENT PRIMARY KEY,
  Author longtext,
  LaunchDate datetime(6) not null,
  Price decimal(65, 2) not null,
  Title longtext
);
