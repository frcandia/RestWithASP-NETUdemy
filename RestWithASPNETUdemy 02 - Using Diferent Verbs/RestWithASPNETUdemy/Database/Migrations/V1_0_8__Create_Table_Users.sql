CREATE TABLE users (
  Id BIGINT AUTO_INCREMENT PRIMARY KEY,
  Login varchar(50) unique not null,
  AccessKey varchar(50) not null
);
