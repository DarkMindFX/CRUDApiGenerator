USE [Vocabularies]
GO
/****** Object:  StoredProcedure [dbo].[p_PopulateVocabularies]    Script Date: 7/30/2023 4:54:59 PM ******/
DROP PROCEDURE [dbo].[p_PopulateVocabularies]
GO
/****** Object:  StoredProcedure [dbo].[p_PopulateVocabularies]    Script Date: 7/30/2023 4:54:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Usage:
1. From local file
(Optionally) EXEC p_TestData_CleanUp
EXEC dbo.p_PopulateVocabularies 'd:\Projects\CRUDApiGenerator\Data\Vocabularies\'

2. From Azure Blob

CREATE MASTER KEY ENCRYPTION BY PASSWORD ='<Password>'

CREATE DATABASE SCOPED CREDENTIAL UploadPhotoPrintTestData
WITH IDENTITY = 'SHARED ACCESS SIGNATURE',
SECRET = '<SAS for blob folder>';

CREATE EXTERNAL DATA SOURCE Vocabulary_Azure_TestData
WITH (
        TYPE = BLOB_STORAGE,
        LOCATION = 'https://<blob address>',
        CREDENTIAL = UploadPhotoPrintTestData
    );
GO 

EXEC p_PopulateVocabularies	'instrademonitor-test-data/', 
							'InsidersTradeMonitor_Azure_TestData'

DROP EXTERNAL DATA SOURCE InsidersTradeMonitor_Azure_TestData

DROP DATABASE SCOPED CREDENTIAL UploadPhotoPrintTestData

DROP MASTER KEY


*/

CREATE PROCEDURE [dbo].[p_PopulateVocabularies] 
	@RootFolder		NVARCHAR(1000),
	@DataSource		NVARCHAR(100) = NULL
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE @tblVocabularies AS TABLE (
		[VocabularyName]	NVARCHAR(255),
		[FileName]			NVARCHAR(255)
	)

	INSERT INTO @tblVocabularies
	SELECT 'FirstName', 'FirstNames.csv' UNION
	SELECT 'LastName', 'LastNames.csv'	UNION
	SELECT 'Country', 'Countries.csv'	UNION
	SELECT 'City', 'Cities.csv'

	DECLARE @VocabularyName NVARCHAR(255)
	DECLARE @FileName		NVARCHAR(255)

	DECLARE vocabCursor CURSOR FOR
	SELECT [VocabularyName], [FileName] FROM @tblVocabularies

	OPEN vocabCursor

	BEGIN TRY

		BEGIN TRANSACTION trans_InsertVocabularies

		FETCH NEXT FROM vocabCursor INTO @VocabularyName, @FileName		

		WHILE @@FETCH_STATUS = 0
		BEGIN

			IF(NOT EXISTS(SELECT 1 FROM dbo.Vocabulary WHERE Name = @VocabularyName))
			BEGIN
				INSERT INTO Vocabulary ([Name]) VALUES (@VocabularyName)
			END
			
			EXEC dbo.p_PopulateVocabularyValues @VocabularyName, @FileName, @RootFolder, @DataSource

			FETCH NEXT FROM vocabCursor INTO @VocabularyName, @FileName
			
		END

		COMMIT TRANSACTION trans_InsertVocabularies
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION trans_InsertVocabularies
		SELECT   
        ERROR_NUMBER() AS ErrorNumber  
       ,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH


	CLOSE vocabCursor
	DEALLOCATE vocabCursor
END
GO
