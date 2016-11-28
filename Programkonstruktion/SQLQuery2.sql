USE [LabSQL2]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[usp_Update_A_Customer]
		@CustName = N'123',
		@EmpId = 12344,
		@CustId = 123

SELECT	@return_value as 'Return Value'

GO
