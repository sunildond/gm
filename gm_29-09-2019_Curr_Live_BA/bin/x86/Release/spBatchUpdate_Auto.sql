USE [GM_2018_2019_New]
GO
/****** Object:  StoredProcedure [dbo].[spBatchUpdate]    Script Date: 09/22/2019 11:56:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author name: <Author,,Name>
-- Create date: 22 September, 2019
-- Description: [spBatchUpdate_Auto] 1116, 52, 22100010, 'IIN110003064050115', '21110315', '2012-04-06 22:48:41.893', '2012-04-06 22:48:41.893', 68, 63 
-- =============================================
ALTER PROCEDURE [dbo].[spBatchUpdate_Auto]
    @IOMNO numeric(18,0),
    @ProductCode nvarchar(50),
    @WareHouseCode nvarchar(500),
    @BatchNo nvarchar(500),
    @QTY int = 0,
    @MFGDate datetime,
	@ExpiryDate datetime,
	@AlisCode nvarchar(50)
    
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements. select * from StockUpload
    SET NOCOUNT ON;
    declare @Error int
    declare @Message varchar(500)
	   
	   
       IF (@QTY>0)
       BEGIN
       
	   Update OrderItem set BatchQuantity = (BatchQuantity + @QTY), Reason = '', Remark = '', IsDeliveryCompleted=1, CloseDate=getdate() where IOMNo=@IOMNO and Aliscode=@AlisCode  ; 
       
       IF EXISTS(SELECT * FROM StockUpload WHERE BatchNo = @BatchNo and Aliscode = @AlisCode)
       BEGIN
			--Update StockUpload set AllocatedQuantity = AllocatedQuantity + @QTY where ID=@stockUploadId; 
			Update StockUpload SET AllocatedQuantity = AllocatedQuantity + @QTY WHERE BatchNo = @BatchNo and Aliscode = @AlisCode
       END
              
       Insert into BatchAllocation (IOMNO,ProductCode,WareHouseCode,BatchNo,QTY,MFGDate,ExpiryDate,SelfLifePercentage,AlisCode,StorageCode,LastModify) VALUES (@IOMNO,@ProductCode,@WareHouseCode,@BatchNo,@QTY,@MFGDate,@ExpiryDate,0,@AlisCode,'FG01',GETDATE()); 
      
	   --Update ScheduleDetail set BatchQuantity = (BatchQuantity + @QTY), Reason = '', Remark = '' where ScheduleID = @ScheduleID
	  END 
    --print @Message
   
END
