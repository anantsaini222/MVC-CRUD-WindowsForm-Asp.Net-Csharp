CREATE PROCEDURE [dbo].[StudentCRUD]
	@Id int = 0,
	@Name varchar(50)=NULL,
	@Course varchar(50)=NULL,
	@Email varchar(50)=NULL,
	@SEM_1 int = 0,
	@SEM_2 int = 0,
	@SEM_3 int = 0,
	@SEM_4 int = 0,
	@Percentage int=0,
	@Grade varchar(50)=NULL,
	@status varchar(50)

AS
BEGIN
SET NOCOUNT ON;
----Insert New Record
IF @status='INSERT'
BEGIN
	INSERT INTO StudentTable(Id,Name,Course,Email,SEM_1,SEM_2,SEM_3,SEM_4,Percentage,Grade)
	VALUES(@Id,@Name,@Course,@Email,@SEM_1,@SEM_2,@SEM_3,@SEM_4,@Percentage,@Grade)
END
----Select Records In Table
IF @status='SELECT'
BEGIN 
SELECT Id,Name,Course,Email,SEM_1,SEM_2,SEM_3,SEM_4,Percentage,Grade FROM StudentTable
END
----Update Records in Table
IF @status='UPDATE'
BEGIN
UPDATE StudentTable
	SET Name=@Name,
	Course=@Course,
	Email=@Email,
	SEM_1=@SEM_1,
	SEM_2=@SEM_2,
	SEM_3=@SEM_3,
	SEM_4=@SEM_4,
	Percentage=@Percentage,
	Grade=@Grade WHERE Id=@Id
END
-----Delete Records from Table
IF @status='DELETE'
BEGIN
DELETE FROM StudentTable WHERE Id=@Id
END
SET NOCOUNT OFF
END

RETURN 0
