CREATE TABLE IF NOT EXISTS books (
  Id varchar(127) not null,
  Author longtext,
  LaunchDate datetime(6) not null,
  Price decimal(65, 2) not null,
  Title longtext,
  Primary Key (Id)
);