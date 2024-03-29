USE [Vocabularies]
GO
/****** Object:  StoredProcedure [dbo].[p_PopulateVocabularyValues]    Script Date: 7/30/2023 4:54:59 PM ******/
DROP PROCEDURE [dbo].[p_PopulateVocabularyValues]
GO
/****** Object:  StoredProcedure [dbo].[p_PopulateVocabularyValues]    Script Date: 7/30/2023 4:54:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Usage:
1. From local file
(Optionally) EXEC p_TestData_CleanUp
EXEC dbo.p_PopulateVocabularyValues 'Test', 
									'Countries.csv',
									'd:\Projects\CRUDApiGenerator\Data\Vocabularies\'

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

EXEC p_TestData_Populate	'Country', 
							'Countries.csv', 
							'instrademonitor-test-data/', 
							'InsidersTradeMonitor_Azure_TestData'

DROP EXTERNAL DATA SOURCE InsidersTradeMonitor_Azure_TestData

DROP DATABASE SCOPED CREDENTIAL UploadPhotoPrintTestData

DROP MASTER KEY
*/

CREATE PROCEDURE [dbo].[p_PopulateVocabularyValues]
	
	@VocabularyName NVARCHAR(250),
	@FileName		NVARCHAR(250),
	@RootFolder		NVARCHAR(1000),
	@DataSource		NVARCHAR(100) = NULL
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @file AS NVARCHAR(100) = @FileName
	DECLARE @table AS NVARCHAR(100) = 'Values'
    DECLARE @hasIdentity AS BIT = 0 -- no identity in files - new ID will be assigned to each value
	DECLARE @VocabularyID AS BIGINT
	DECLARE @Error AS NVARCHAR(250) 

	DECLARE @Path AS NVARCHAR(MAX)
	DECLARE @sql AS NVARCHAR(MAX)

	BEGIN TRY

		BEGIN TRANSACTION

			PRINT('======= ' + @file + ' -> ' + @table + ' =======')

			SELECT TOP 1 @VocabularyID = ID FROM dbo.Vocabulary WHERE [Name] = @VocabularyName

			IF(@VocabularyID IS NULL) 
			BEGIN
				
				SET @Error = 'Vocabulary with given name not found - ' + @VocabularyName
				;THROW 52001, @Error , 1;
			END


			SELECT @Path = CONCAT(@RootFolder, @file)
			IF(@hasIdentity = 1) BEGIN
				SET @sql = 'SET IDENTITY_INSERT dbo.[' + @table + '] ON;'

				PRINT(@sql)
				EXEC(@sql)
			END


			SET @sql = 'BULK INSERT dbo.[v_ValuesBulkInsert]
			FROM ''' + @Path + '''
			WITH (' +
			CASE
				WHEN @DataSource IS NOT NULL THEN 'DATA_SOURCE=''' + @DataSource + ''',' 
				ELSE ''
			END +
			--'KEEPIDENTITY,
			'FIRSTROW = 2,
			FIELDTERMINATOR = '','',
			ROWTERMINATOR=''0x0d0a'',
			BATCHSIZE=2500000);'

			PRINT(@sql)
			EXEC(@sql)

			UPDATE dbo.[Value]
			SET VocabularyID = @VocabularyID
			WHERE VocabularyID IS NULL

			IF(@hasIdentity = 1) 
			BEGIN
				SET @sql = 'SET IDENTITY_INSERT dbo.[' + @table + '] OFF;'

				PRINT(@sql)
				EXEC(@sql)
			END

		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		SELECT   
        ERROR_NUMBER() AS ErrorNumber  
       ,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH

   
END
GO
