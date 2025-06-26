EXEC sp_rename '[dbo].[mstgroundrent].SACId', 'SacCodeId', 'COLUMN';

ALTER TABLE [dbo].[mstreeferchrg]
ADD SacCodeId INT NULL,
    Size NVARCHAR(30),
	Rate DECIMAL,
    [Hours] NVARCHAR(20);


UPDATE [dbo].[mstreeferchrg] SET 
SacCodeId=13,
Size=20,
Rate=100,
[Hours]=2 where ReeferChrgId=1


ALTER TABLE [dbo].[mstmiscellaneous]
ADD SacCodeId INT NULL,
    Size NVARCHAR(30),
	Rate DECIMAL,
    OperationId INT NULL;

UPDATE [dbo].[mstmiscellaneous] SET 
SacCodeId=13,
Size=40,
Rate=100,
OperationId=13 where MiscellaneousId=1


USE [SEZDB]
GO
/****** Object:  StoredProcedure [dbo].[SP_GetGroundRentChargeList]    Script Date: 26-06-2025 11:05:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXEC [dbo].[SP_GetGroundRentChargeList] 1
CREATE PROCEDURE [dbo].[SP_GetGroundRentChargeList]
    @GroundRentId INT = 0
AS
BEGIN
    SET NOCOUNT ON;
		IF ISNULL(@GroundRentId,0) = 0
		BEGIN
			SELECT
				ground.GroundRentId,
				ground.SacCodeId,
				ground.EffectiveDate,
				sac.SacCode,
				CONCAT(ground.DaysRangeFrom, '-', ground.DaysRangeTo) AS DaysRange,
				CASE 
					WHEN ground.ContainerType = 1 THEN 'Empty Container' 
					WHEN ground.ContainerType = 2 THEN 'Loaded Container' 
				ELSE 'Other'
					END AS ContainerType,
				commodity.CommodityType AS ContainerDetails,
				ground.Size,
				ground.fcllcl AS FCLLCL,
				ground.RentAmount AS Amount,
				operation.OperationType 
				FROM [dbo].[mstgroundrent] ground
				LEFT JOIN [dbo].[mstoperation] operation on ground.SacCodeId = operation.SacId
				LEFT JOIN [dbo].[mstsac] sac ON sac.SacId=ground.SacCodeId
				LEFT JOIN [dbo].[MstCommodity] commodity ON commodity.CommodityId = ground.CommodityType
		END
			ELSE
		BEGIN
			SELECT
				ground.GroundRentId,
				ground.SacCodeId,
				ground.EffectiveDate,
				sac.SacCode,
				CONCAT(ground.DaysRangeFrom, '-', ground.DaysRangeTo) AS DaysRange,
				CASE 
					WHEN ground.ContainerType = 1 THEN 'Empty Container' 
					WHEN ground.ContainerType = 2 THEN 'Loaded Container' 
				ELSE 'Other'
					END AS ContainerType,
				commodity.CommodityType AS ContainerDetails,
				ground.Size,
				ground.fcllcl AS FCLLCL,
				ground.RentAmount AS Amount,
				operation.OperationType 
				FROM [dbo].[mstgroundrent] ground
				LEFT JOIN [dbo].[mstoperation] operation on ground.SacCodeId = operation.SacId
				LEFT JOIN [dbo].[mstsac] sac ON sac.SacId=ground.SacCodeId
				LEFT JOIN [dbo].[MstCommodity] commodity ON commodity.CommodityId = ground.CommodityType
				WHERE ground.GroundRentId = @GroundRentId;
		END
END



GO
/****** Object:  StoredProcedure [dbo].[SP_GetReeferChargeList]    Script Date: 26-06-2025 11:09:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[SP_GetReeferChargeList] 1
CREATE PROCEDURE [dbo].[SP_GetReeferChargeList] 
  @ReeferChrgId INT = 0 
AS 
BEGIN 
SET NOCOUNT ON;
IF ISNULL(@ReeferChrgId, 0) = 0 
	BEGIN 
	SELECT 
	  ReeferChrgId, 
	  SacCodeId, 
	  EffectiveDate, 
	  SacCode, 
	  [Hours], 
	  Size, 
	  Rate 
		FROM 
		[dbo].[mstreeferchrg] 
	END 
ELSE 
	BEGIN 
	SELECT 
	  ReeferChrgId, 
	  SacCodeId, 
	  EffectiveDate, 
	  SacCode, 
	  [Hours], 
	  Size, 
	  Rate 
		FROM 
		[dbo].[mstreeferchrg] 
		WHERE 
		ReeferChrgId = @ReeferChrgId;
	END 
END


/****** Object:  StoredProcedure [dbo].[SP_GetMISCChargeList]    Script Date: 26-06-2025 11:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[SP_GetMISCChargeList] 1
CREATE PROCEDURE [dbo].[SP_GetMISCChargeList] 
  @MiscellaneousId INT = 0 
AS 
BEGIN 
SET NOCOUNT ON;
IF ISNULL(@MiscellaneousId, 0) = 0 
	BEGIN 
	SELECT 
	  misc.MiscellaneousId,
	  misc.SacCodeId,
	  misc.SacCode,
	  misc.EffectiveDate,
	  misc.OperationId,
	  operation.OperationDesc,
	  misc.Size,
	  misc.Rate
		FROM 
		[dbo].[mstmiscellaneous] misc 
		JOIN [dbo].[mstoperation] operation ON misc.OperationId = operation.OperationId 
	END 
ELSE 
	BEGIN 
	SELECT 
	  misc.MiscellaneousId,
	  misc.SacCodeId,
	  misc.SacCode,
	  misc.EffectiveDate,
	  misc.OperationId,
	  operation.OperationDesc,
	  misc.Size,
	  misc.Rate
		FROM 
		[dbo].[mstmiscellaneous] misc 
		JOIN [dbo].[mstoperation] operation ON misc.OperationId = operation.OperationId 
		WHERE misc.MiscellaneousId = @MiscellaneousId;
	END 
END


/****** Object:  StoredProcedure [dbo].[SP_AddGroundRentCharge]    Script Date: 26-06-2025 12:15:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_AddGroundRentCharge]

    @GroundRentId INT = 0,
	@EffectiveDate DATE = NULL,
	@SACCodeId INT = 0,
    @DaysRangeFrom INT = NULL,
	@DaysRangeTo INT = 0,
    @ContainerType INT = NULL,
    @CommodityType INT = 0,
	@Size NVARCHAR(100) = NULL,
	@FclLcl NVARCHAR(100) = NULL,
	@RentAmount DECIMAL(10, 2) = NULL,
    @OperationType INT = NULL,
	@CreatedBy INT = NULL,
	@UpdatedBy INT = NULL
AS
BEGIN

    SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION;

		IF ISNULL(@GroundRentId,0) = 0
		BEGIN
			INSERT INTO  [dbo].[mstgroundrent](EffectiveDate, SACCodeId, DaysRangeFrom,DaysRangeTo,ContainerType,CommodityType,Size,FclLcl,RentAmount,OperationType,[CreatedBy],[CreatedOn])
			VALUES (@EffectiveDate, @SACCodeId, @DaysRangeFrom,@DaysRangeTo,@ContainerType,@CommodityType,@Size,@FclLcl,@RentAmount,@OperationType,@CreatedBy, GETDATE());
		END
		ELSE
		BEGIN
			UPDATE [dbo].[mstgroundrent]
			SET
				EffectiveDate = @EffectiveDate,
				SACCodeId = @SACCodeId,
				DaysRangeFrom = @DaysRangeFrom,
				DaysRangeTo = @DaysRangeTo,
				ContainerType = @ContainerType,
				CommodityType=@CommodityType,
				Size=@Size,
				FclLcl=@FclLcl,
				RentAmount=@RentAmount,
				OperationType=@OperationType,

				UpdatedBy = @UpdatedBy,
				UpdatedOn = GETDATE()
			WHERE GroundRentId = @GroundRentId;
		END

		COMMIT;
		SELECT 'OK' AS response;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK;

		SELECT 'NOT OK' AS response;
	END CATCH

	select 'OK' AS response
END


/****** Object:  StoredProcedure [dbo].[SP_AddEditReeferCharge]    Script Date: 26-06-2025 15:36:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_AddEditReeferCharge]
	@ReeferChrgId INT = 0,
	@SacCodeId INT = 0,
	@EffectiveDate DATE = NULL,
	@Hours NVARCHAR(10) = NULL,
	@Size NVARCHAR(20) = NULL,
	@Rate DECIMAL(10, 2) = NULL,
	@CreatedBy INT = NULL,
	@UpdatedBy INT = NULL
AS
BEGIN
DECLARE @SacCode NVARCHAR(7) = NULL
    SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION;

		IF ISNULL(@ReeferChrgId,0) = 0
		BEGIN
			INSERT INTO  [dbo].[mstreeferchrg]
			(SacCodeId,EffectiveDate,SacCode,[Hours],Size,Rate,[CreatedBy],[CreatedOn])
			VALUES 
			(@SacCodeId,@EffectiveDate,@SacCode,@Hours,@Size,@Rate,@CreatedBy, GETDATE());
		END
		ELSE
		BEGIN
			UPDATE [dbo].[mstreeferchrg]
			SET
				SacCodeId = @SacCodeId,
				EffectiveDate = @EffectiveDate,
				SacCode=@SacCode,
				[Hours] = @Hours,
				Size = @Size,
				Rate = @Rate,
				UpdatedBy = @UpdatedBy,
				UpdatedOn = GETDATE()
			WHERE ReeferChrgId = @ReeferChrgId;
		END

		COMMIT;
		SELECT 'OK' AS response;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK;

		SELECT 'NOT OK' AS response;
	END CATCH

	select 'OK' AS response
END


