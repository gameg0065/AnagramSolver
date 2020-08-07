
CREATE PROCEDURE DeleteTable (@Tablename NVARCHAR(20))
AS  
BEGIN  
IF @Tablename = 'Word'  
    BEGIN  
        DELETE FROM Word
    END 
ELSE IF @Tablename = 'UserLog'  
    BEGIN  
        DELETE FROM UserLog  
    END   
ELSE IF @Tablename = 'CachedWord'  
    BEGIN  
        DELETE FROM CachedWord  
    END  
END  