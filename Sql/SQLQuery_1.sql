
CREATE TABLE UserLog
(
    userIp NVARCHAR(20) NOT NULL,
    searchTime DATETIME NOT NULL,
    searchWord NVARCHAR(255) NOT NULL,
    anagram NVARCHAR(255) NOT NULL,
);

-- DROP TABLE UserLog;