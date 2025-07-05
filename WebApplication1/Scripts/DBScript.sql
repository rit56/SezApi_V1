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
CREATE  PROCEDURE [dbo].[SP_GetGroundRentChargeList]
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

				CASE 
					WHEN ground.fcllcl = '1' THEN 'FCL' 
					WHEN ground.fcllcl = '2' THEN 'LCL' 
				ELSE 'Other' END AS FCLLCL,
				ground.RentAmount AS Amount,
				--operation.OperationType 
				CASE 
					WHEN ground.ContainerType = 1 THEN 'Import' 
					WHEN ground.ContainerType = 2 THEN 'Export' 
					WHEN ground.ContainerType = 3 THEN 'Empty Import' 
					WHEN ground.ContainerType = 4 THEN 'Empty Export' 
				ELSE 'Other' END AS OperationType
				FROM [dbo].[mstgroundrent] ground
				--LEFT JOIN [dbo].[mstoperation] operation on ground.SacCodeId = operation.SacId
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

				CASE 
					WHEN ground.fcllcl = '1' THEN 'FCL' 
					WHEN ground.fcllcl = '2' THEN 'LCL' 
				ELSE 'Other' END AS FCLLCL,
				ground.RentAmount AS Amount,
				--operation.OperationType 
				CASE 
					WHEN ground.ContainerType = 1 THEN 'Import' 
					WHEN ground.ContainerType = 2 THEN 'Export' 
					WHEN ground.ContainerType = 3 THEN 'Empty Import' 
					WHEN ground.ContainerType = 4 THEN 'Empty Export' 
				ELSE 'Other' END AS OperationType
				FROM [dbo].[mstgroundrent] ground
				--LEFT JOIN [dbo].[mstoperation] operation on ground.SacCodeId = operation.SacId
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
ALTER PROCEDURE [dbo].[SP_GetReeferChargeList] 
  @ReeferChrgId INT = 0 
AS 
BEGIN 
SET NOCOUNT ON;
IF ISNULL(@ReeferChrgId, 0) = 0 
	BEGIN 
	SELECT 
	  refer.ReeferChrgId, 
	  refer.SacCodeId, 
	  refer.EffectiveDate, 
	  sac.SacCode, 
	  refer.[Hours], 
	  refer.Size, 
	  refer.Rate 
		FROM 
		[dbo].[mstreeferchrg] refer
		LEFT JOIN [dbo].[mstsac] sac ON sac.SacId = refer.SacCodeId
	END 
ELSE 
	BEGIN 
	SELECT 
	  refer.ReeferChrgId, 
	  refer.SacCodeId, 
	  refer.EffectiveDate, 
	  sac.SacCode, 
	  refer.[Hours], 
	  refer.Size, 
	  refer.Rate 
		FROM 
		[dbo].[mstreeferchrg] refer
		LEFT JOIN [dbo].[mstsac] sac ON sac.SacId = refer.SacCodeId 
		WHERE 
		refer.ReeferChrgId = @ReeferChrgId;
	END 
END


/****** Object:  StoredProcedure [dbo].[SP_GetMISCChargeList]    Script Date: 26-06-2025 11:10:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [dbo].[SP_GetMISCChargeList] 1
ALTER PROCEDURE [dbo].[SP_GetMISCChargeList] 
  @MiscellaneousId INT = 0 
AS 
BEGIN 
SET NOCOUNT ON;
IF ISNULL(@MiscellaneousId, 0) = 0 
	BEGIN 
	SELECT 
	  misc.MiscellaneousId,
	  operation.SacId AS SacCodeId,
	  sac.SacCode,
	  misc.EffectiveDate,
	  misc.OperationId,
	  operation.OperationDesc,
	  misc.Size,
	  misc.Rate
		FROM 
		[dbo].[mstmiscellaneous] misc 
		LEFT JOIN [dbo].[mstoperation] operation ON misc.OperationId = operation.OperationId
		LEFT JOIN [dbo].[mstsac] sac ON sac.SacId=operation.SacId
	END 
ELSE 
	BEGIN 
	SELECT 
	  misc.MiscellaneousId,
	  operation.SacId AS SacCodeId,
	  sac.SacCode,
	  misc.EffectiveDate,
	  misc.OperationId,
	  operation.OperationDesc,
	  misc.Size,
	  misc.Rate
		FROM 
		[dbo].[mstmiscellaneous] misc 
		LEFT JOIN [dbo].[mstoperation] operation ON misc.OperationId = operation.OperationId
		LEFT JOIN [dbo].[mstsac] sac ON sac.SacId=operation.SacId
		WHERE misc.MiscellaneousId = @MiscellaneousId;
	END 
END

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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sp_AddEditMiscCharge]
    @MiscellaneousId INT = NULL,  
	@EffectiveDate DATE = NULL,
	@SacCodeId INT = 0,
	@OperationId INT = 0,
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

        IF EXISTS (SELECT 1 FROM mstmiscellaneous WHERE MiscellaneousId = @MiscellaneousId)
		--IF ISNULL(@MiscellaneousId,0) = 0
        BEGIN
            -- UPDATE
            UPDATE [dbo].[mstmiscellaneous]
            SET
                SacCode = @SacCode,
				EffectiveDate= @EffectiveDate,
				SacCodeId = @SacCodeId,
				OperationId= @OperationId,
				Size = @Size,
				Rate = @Rate,
				UpdatedBy = @UpdatedBy,
                UpdatedOn = GETDATE()
            WHERE MiscellaneousId = @MiscellaneousId;
        END
        ELSE
        BEGIN
            -- INSERT
            INSERT INTO [dbo].[mstmiscellaneous] (
                EffectiveDate,
                SacCode,
				SacCodeId,
				OperationId,
				Size,
				Rate,
				CreatedBy,
                CreatedOn
            )
            VALUES (
				@EffectiveDate,
                @SacCode,
				@SacCodeId,
				@OperationId,
				@Size,
				@Rate,
				@CreatedBy,
                GETDATE()
            );
        END

        COMMIT TRANSACTION;
        SELECT 'Success' AS Response;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SELECT ERROR_MESSAGE() AS Response;
    END CATCH
END

------------05-07-2025-------------------

ALTER TABLE [dbo].[mstPreArrivalNotification]
ADD PackListPDFName   NVARCHAR(200),
    PackListPDF_GUID  NVARCHAR(50),
	CheckListPDFName  NVARCHAR(200),
    CheckListPDF_GUID NVARCHAR(50);


/****** Object:  StoredProcedure [dbo].[SP_AddPreArrivalNotification]    Script Date: 05-07-2025 18:02:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_AddPreArrivalNotification]

    @PreArrivalNotificationId INT = 0,
	@PreArrivalDate DATE = NULL,
	@PreArrivalNo NVARCHAR(100) = NULL,
	@ContainerNo NVARCHAR(100) = NULL,
	@Size INT = 0,
    @Type INT = 0,
	@WTKg NVARCHAR(100) = NULL,
	@Value NVARCHAR(100) = NULL,
	@Commodity INT = 0,
	@PackListPDFName NVARCHAR(50) = NULL,
	@PackListPDF_GUID NVARCHAR(50) = NULL,
	@CheckListPDFName NVARCHAR(50) = NULL,
	@CheckListPDF_GUID NVARCHAR(50) = NULL,
	@ExpectedArrivalDate DATE = NULL,
	@ExpectedArrivalTime time(7) = NULL,
	@CreatedBy INT = NULL,
	@UpdatedBy INT = NULL
AS
BEGIN

    SET NOCOUNT ON;
	BEGIN TRY
    BEGIN TRANSACTION;

		IF ISNULL(@PreArrivalNotificationId,0) = 0
		BEGIN
			INSERT INTO  [dbo].[mstPreArrivalNotification]
			(
					     PreArrivalDate,
					     PreArrivalNo ,
					     ContainerNo ,
					     Size ,
					     Type,
					     WTKg,
					     Value,
					     Commodity,
						 PackListPDFName,
						 PackListPDF_GUID,
						 CheckListPDFName, 
						 CheckListPDF_GUID,
					     ExpectedArrivalDate,
					     ExpectedArrivalTime,
						 [CreatedBy],
						 [CreatedOn]
			)
			VALUES (
						 @PreArrivalDate,
					     @PreArrivalNo,
					     @ContainerNo,
					     @Size,
					     @Type,
					     @WTKg,
					     @Value,
					     @Commodity,
						 @PackListPDFName,
						 @PackListPDF_GUID,
						 @CheckListPDFName, 
						 @CheckListPDF_GUID,
					     @ExpectedArrivalDate,
					     @ExpectedArrivalTime,
						 @CreatedBy, 
						 GETDATE()
					);
		END
		ELSE
		BEGIN
			UPDATE  [dbo].[mstPreArrivalNotification]
			SET
				    [PreArrivalDate]=@PreArrivalDate,
					PreArrivalNo= @PreArrivalNo,
					ContainerNo =@ContainerNo,
					Size= @Size,
					Type=@Type,
					WTKg =@WTKg,
					Value=@Value ,
					Commodity=@Commodity,
					PackListPDFName=@PackListPDFName,
					PackListPDF_GUID=@PackListPDF_GUID,
					CheckListPDFName=@CheckListPDFName, 
					CheckListPDF_GUID=@CheckListPDFName,
					ExpectedArrivalDate =@ExpectedArrivalDate,
					ExpectedArrivalTime=@ExpectedArrivalTime,
					UpdatedBy = @UpdatedBy,
					UpdatedOn = GETDATE()
			WHERE [PreArrivalNotificationId] =@PreArrivalNotificationId ;
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


