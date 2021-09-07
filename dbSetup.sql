CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE contractor(
  id int NOT NULL primary key AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL
);

CREATE TABLE company(
  id int NOT NULL primary key AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL
);

CREATE TABLE jobs(
id int NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
accountId VARCHAR(255) NOT NULL comment 'Account Id References Account',
companyId int NOT NULL COMMENT 'Company Id refernces Company',
contractorId int NOT NULL COMMENT 'Contractor Id refernces Contractor',
FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
FOREIGN KEY (companyId) REFERENCES company(id) ON DELETE CASCADE,
FOREIGN KEY (contractorId) REFERENCES contractor(id) ON DELETE CASCADE
)default charset utf8 comment '';
