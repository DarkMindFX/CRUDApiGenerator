USE [Vocabularies]
GO
/****** Object:  View [dbo].[v_ValuesBulkInsert]    Script Date: 7/30/2023 4:54:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_ValuesBulkInsert] AS
SELECT
    [Value]
FROM
    dbo.[Value]
GO
