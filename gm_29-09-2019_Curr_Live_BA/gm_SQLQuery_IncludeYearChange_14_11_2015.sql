
SELECT id.Delivery as STNNo, id.BillingDocument as INVNo, su.IOMNo,oh.IOMDate, oh.PartyCode,oh.PartyName,
         (case when oh.LocationCode is not null then (select DispatchThru from LocationMaster where LocationMaster.LocationCode=oh.LocationCode) end) as LocationCode, 
(case when su.Plnt is not null then (select DispatchThru from LocationMaster where LocationMaster.LocationCode=su.Plnt) end) as STNLocation, 
         oh.DSM_ZSM, oh.DispThrough, id.HORemarks,id.AuthDate, id.InvTransporter as Transpoter,id.InvLRNo as LRNo,id.InvDispLRdate as LRDate,
id.InvDispDelDate as DelDate,oh.BillingAddress,
(case when oh.StampingID is not null then (select Name from StampingMaster where oh.StampingID = StampingMaster.StampingId) end) SubInstitution,
oh.MRP, id.Cases from STNUpload su, OrderHeader oh, Invoice_Dispatch id where oh.IOMNo=su.IOMNO and oh.IOMNo=id.IOMNO
and su.Delivery != '' and su.OrdUpdated=1


select * from CustomerMaster where CustomerCode = 'G99T0678'

select * from Invoice_Dispatch
select * from STNInvoice_Dispatch
select * from OrderHeader order by 1 desc

select * from OrderItem

select oh.OrderHeaderId , oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,sd.DeliveryDate as DelDate, ot.ProductCode as ProdCode , ot.ProductName, SD.OrderQuantity as QTY, (sd.OrderQuantity -sd.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (sd.OrderQuantity -sd.BatchQuantity) as ProductValue, ot.AlisCode, sd.ScheduleID, ot.Reason,ot.Remark as PendingRemark,oh.Remark as OrderHeaderRemark ,oh.OrderAuthoDate as    OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot, ScheduleDetail as sd ,StampingMaster as sm 
where oh.IOMNo=ot.IOMNo and ot.IOMNo=sd.IOMNo 
and oh.Schedule='YES' and oh.Authorised=1 
--and sd.DeliveryDate <=GETDATE()
and (sd.OrderQuantity -sd.BatchQuantity) >0  and oh.StampingID=sm.StampingId  and ot.IsDeliveryCompleted=1
Union all 
select oh.OrderHeaderId, oh.IOMNo,oh.IOMDate,oh.PartyCode,oh.PartyName,oh.Schedule ,oh.OrderDeliveryDate as DelDate, ot.ProductCode as ProdCode, ot.ProductName, ot.Quantity as QTY, (ot.Quantity -ot.BatchQuantity) as PendingQuantity, oh.DispThrough, oh.MRP, sm.Name as StampingName, ot.BillingRate, ot.ValuePerProd * (ot.Quantity - ot.BatchQuantity) as ProductValue, ot.AlisCode, 0 as ScheduleID, ot.Reason,ot.Remark as PendingRemark ,oh.Remark as OrderHeaderRemark,oh.OrderAuthoDate as OrderAuthDate, oh.DocFile1 from OrderHeader as oh ,OrderItem as ot , StampingMaster as sm 
where oh.IOMNo=ot.IOMNo and oh.Schedule='No'  and oh.Authorised=1 
--and oh.OrderDeliveryDate <=GETDATE() 
and (ot.Quantity -ot.BatchQuantity) >0 and oh.StampingID=sm.StampingId 
and ot.IsDeliveryCompleted=1

select * from OrderItem where IOMNo = 12100004

select * from OrderHeader where LocationCode = 'CF38'

select * from OrderItem where IOMNo = 15100980

select * from ProductMaster  where Aliscode = 'O00006'

select ba.ProductCode,ba.QTY, ba.BatchNo,
(case when ba.ProductCode is not null then (select distinct Description from ProductMaster where Material = ba.ProductCode) end) as ProductName,
oh.*,ba.BatchAllocationId from OrderHeader oh, BatchAllocation ba where oh.IOMNo = ba.IOMNO 
and oh.IOMNo =  15101465
and oh.IOMNo in (select iomno from orderitem where BilledQuantity=0)

select * from OrderItem where IOMNo = 15100980
select * from BatchAllocation where IOMNO = 15101409 and BatchNo = 11150170 and ProductCode = 'IIN110008547010125'

select IOMNO, ProductCode, QTY, BatchAllocationId from BatchAllocation where IOMNO=12100008 and iomno in (select iomno from orderitem where BilledQuantity=0) and ProductCode = IIN110003076240858 and QTY = @BatchQuantity

select * from OrderItem order by 1 desc

select * from SAPInvoiceUpload order by 1 desc

select * from BatchAllocation order by 1 desc
select * from BatchAllocation where IOMNO = 13100513 12100008

select * from STNInvoice_Dispatch order by 1 desc

select IOMNO, ProductCode, BatchNo, COUNT(*) as cnt from BatchAllocation group by IOMNO, ProductCode, BatchNo order by cnt desc

select * from STNInvoice_Dispatch order by 1 desc

select top 1 * from SAPInvoiceUpload order by 1 desc
select top 1 * from DirSAPInvoiceUpload order by 1 desc
select top 1 * from STNUpload order by 1 desc
select top 1 * from IBISDirectBillingUpdate order by 1 desc
select top 1 * from IBISBillingUpdate order by 1 desc
select ba.ProductCode,ba.QTY, ba.BatchNo,
(case when ba.ProductCode is not null then (select distinct Description from ProductMaster where Material = ba.ProductCode) end) as ProductName,
oh.*,ba.BatchAllocationId from OrderHeader oh, BatchAllocation ba where oh.IOMNo = ba.IOMNO and oh.IOMNo = 15101520

select ba.IsBilled, ba.ProductCode,ba.QTY, ba.BatchNo,
(case when ba.ProductCode is not null then (select distinct Description from ProductMaster where Material = ba.ProductCode) end) as ProductName,
oh.*,ba.BatchAllocationId from OrderHeader oh, BatchAllocation ba where oh.IOMNo = ba.IOMNO and oh.IOMNo = 12100008
--select * from BatchAllocation where IOMNO = 15101520

select * from (
select IOMNo, MaterialCode, Batch from SAPInvoiceUpload  where IOMNo=15101409 and MaterialCode='' and Batch=''
union all
select IOMNo, MaterialCode, Batch from DirSAPInvoiceUpload  where IOMNo=15101409 and MaterialCode='' and Batch=''
union all
select IOMNo, MaterialCode, Batch from IBISDirectBillingUpdate  where IOMNo=15101409 and MaterialCode='' and Batch=''
union all
select IOMNo, MaterialCode, Batch from IBISBillingUpdate  where IOMNo=15101409 and MaterialCode='' and Batch=''
union all
select IOMNo, MaterialCode, Batch from STNUpload  where IOMNo= 15101409 and MaterialCode='' and Batch=''
) as tempTbl


SELECT BatchAllocation.IOMNO,OrderHeader.IOMDate,OrderHeader.PartyCode,OrderHeader.PartyName, OrderHeader.DispThrough, OrderHeader.InstPONo,OrderHeader.InstPODate,
OrderItem.Remark,BatchAllocation.WareHouseCode,BatchAllocation.StorageCode, BatchAllocation.ProductCode  ,OrderItem.ProductName,BatchAllocation.BatchNo,BatchAllocation.QTY,
OrderItem.BillingRate,OrderItem.MRP as MRPRate, OrderItem.EffTax,OrderItem.ProdValue,
BatchAllocation.MFGDate, BatchAllocation.ExpiryDate,BatchAllocation.SelfLifePercentage, OrderHeader.MRP,StampingMaster.Name as Stamping, 
(OrderItem.MRP * BatchAllocation.QTY) as MRPValue  FROM BatchAllocation,OrderHeader,OrderItem,StampingMaster 
WHERE BatchAllocation.IOMNO=OrderHeader.IOMNo and OrderHeader.StampingID=StampingMaster.StampingId 
and BatchAllocation.AlisCode=OrderItem.AlisCode and OrderItem.IOMNo=OrderHeader.IOMNo
and CONVERT(varchar, BatchAllocation.IOMNO)+BatchAllocation.ProductCode  
not in ( select CONVERT(varchar,iomno)+MaterialCode from stnupload  where OrdUpdated =1 
Union all   
select CONVERT(varchar,iomno)+MaterialCode from SAPInvoiceUpload  where OrdUpdated =1  
Union all   
select CONVERT(varchar,iomno)+MaterialCode  from DirSAPInvoiceUpload  where OrdUpdated =1  
Union all  
select CONVERT(varchar,iomno)+MaterialCode from IBISBillingUpdate  where OrdUpdated =1
Union all   select CONVERT(varchar,iomno)+MaterialCode 
from  IBISDirectBillingUpdate  where OrdUpdated =1)

--All SQL Merge
select OH.IOMNo , oh.IOMDate,oh.PartyCode ,OH.PartyName,
(case when STNUPD.Plnt is not null then (select DispatchThru from LocationMaster where STNUPD.Plnt = LocationMaster.LocationCode) end) STNLocation,
(case when OH.LocationCode is not null then (select DispatchThru from LocationMaster where OH.LocationCode = LocationMaster.LocationCode) end) LocationCode,
STNUPD.PartyCode as STNDispThrough, 
OH.DispThrough ,OH.Remark,STNUPD.MaterialCode , STNUPD.Description AS Productname ,
STNUPD.Batch ,STNUPD.DeliveryQuantity AS Quantity, STNUPD.MfgDate as MfgDate, STNUPD.ExpDate as ExpDate, STNDISP.HORemarks as STNRemark, STNUPD.Delivery AS STNNO, 
STNUPD.BillingDocument as ProfInvoice, STNUPD.ActualGoodsMovement as STNDate,
STNDISP.InvTransporter AS STNTRANSPORTER, STNDISP.InvLRNo  AS STNLRNO,
STNDISP.InvDispLRdate AS STNDISPLRDATE, STNDISP.InvDispDelDate AS STNDISPELDATE,
INVOICE.HORemarks as InvoiceDispatchRemark, INVOICE.BillingDocument AS INVOICE, INVOICE.BillingDate as InvoiceDate, INVOICE.InvTransporter, 
INVOICE.InvLRNo, INVOICE.InvDispLRdate, INVOICE.InvDispDelDate,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.MRP,INVOICE.Cases, INVOICE.TentativeDel,
OH.BillingAddress,OH.DeliveryAddress,OH.OrderDeliveryDate
 ,STNDISP.AuthDate as STNAuthDate, INVOICE.AuthDate as INVAuthDate
 from STNInvoice_Dispatch AS STNDISP, OrderHeader as OH, STNUpload AS STNUPD, Invoice_Dispatch as INVOICE
 where  STNDISP.IOMNO =OH.IOMNo    AND STNDISP.Delivery = STNUPD.Delivery  
 AND STNDISP.IOMNO =INVOICE.IOMNO and STNDISP.Delivery =INVOICE.Delivery 
 and INVOICE.BillingDocument in ( select BillingDocument from SAPInvoiceUpload ) 
 
union all
select OH.IOMNo , oh.IOMDate,oh.PartyCode ,OH.PartyName,
(case when STNUPD.Plnt is not null then (select DispatchThru from LocationMaster where STNUPD.Plnt = LocationMaster.LocationCode) end) STNLocation,
(case when OH.LocationCode is not null then (select DispatchThru from LocationMaster where OH.LocationCode = LocationMaster.LocationCode) end) LocationCode,
STNUPD.PartyCode as STNDispThrough, 
OH.DispThrough ,OH.Remark,STNUPD.MaterialCode ,STNUPD.Description AS Productname ,
STNUPD.Batch ,STNUPD.DeliveryQuantity AS Quantity, STNUPD.MfgDate as MfgDate, STNUPD.ExpDate as ExpDate, STNDISP.HORemarks as STNRemark, STNUPD.Delivery AS STNNO,
STNUPD.BillingDocument as ProfInvoice, STNUPD.ActualGoodsMovement as STNDate,
STNDISP.InvTransporter AS STNTRANSPORTER, STNDISP.InvLRNo  AS STNLRNO,
STNDISP.InvDispLRdate AS STNDISPLRDATE, STNDISP.InvDispDelDate AS STNDISPELDATE,
INVOICE.HORemarks as InvoiceDispatchRemark,INVOICE.BillingDocument AS INVOICE,INVOICE.BillingDate as InvoiceDate,INVOICE.InvTransporter,
INVOICE.InvLRNo, INVOICE.InvDispLRdate, INVOICE.InvDispDelDate,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.MRP,INVOICE.Cases, INVOICE.TentativeDel,
OH.BillingAddress,OH.DeliveryAddress,OH.OrderDeliveryDate 
,STNDISP.AuthDate as STNAuthDate, INVOICE.AuthDate as INVAuthDate
 from STNInvoice_Dispatch AS STNDISP, OrderHeader as OH, STNUpload AS STNUPD, Invoice_Dispatch as INVOICE
 where  STNDISP.IOMNO =OH.IOMNo 
  AND STNDISP.Delivery = STNUPD.Delivery 
  and STNDISP.IOMNO =INVOICE.IOMNO and STNDISP.Delivery =INVOICE.Delivery 
  and INVOICE.BillingDocument in (select DocumentNumber  from IBISBillingUpdate)
   
 UNION ALL    

select OH.IOMNo , oh.IOMDate,oh.PartyCode ,OH.PartyName, '' as STNLocation,
(case when OH.LocationCode is not null then (select DispatchThru from LocationMaster where OH.LocationCode = LocationMaster.LocationCode) end) LocationCode,
'' as STNDispThrough, OH.DispThrough ,OH.Remark,SAPDIR.MaterialCode ,sapdir.Description  AS Productname, sapdir.Batch , sapdir.BilledQuantity AS Quantity , 
'' as MfgDate, '' as ExpDate,
'' as STNRemark,'' AS STNNO,
'' as ProfInvoice, '' as STNDate,
'' AS STNTRANSPORTER, '' AS STNLRNO,
' ' AS STNDISPLRDATE, '' AS STNDISPELDATE,
INVOICE.HORemarks as InvoiceDispatchRemark,INVOICE.BillingDocument AS INVOICE,INVOICE.BillingDate as InvoiceDate,INVOICE.InvTransporter,
INVOICE.InvLRNo, INVOICE.InvDispLRdate, INVOICE.InvDispDelDate,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.MRP,INVOICE.Cases, INVOICE.TentativeDel,
OH.BillingAddress,OH.DeliveryAddress,OH.OrderDeliveryDate   
,'' as STNAuthDate, INVOICE.AuthDate as INVAuthDate
FROM invoice_Dispatch AS INVOICE, OrderHeader as OH , DirSAPInvoiceUpload AS SAPDIR  
 WHERE INVOICE.IOMNO =OH.IOMNo  AND SAPDIR.IOMNo =INVOICE.IOMNO AND INVOICE.BillingDocument = SAPDIR.BillingDocument 
 
 UNION ALL
select OH.IOMNo , oh.IOMDate,oh.PartyCode ,OH.PartyName, '' as STNLocation,
(case when OH.LocationCode is not null then (select DispatchThru from LocationMaster where OH.LocationCode = LocationMaster.LocationCode) end) LocationCode,
'' as STNDispThrough, OH.DispThrough ,OH.Remark,IBISDIR.MaterialCode,IBISDIR.Productname, IBISDIR.Batch, IBISDIR.BilledQuantity AS Quantity , 
'' as MfgDate, '' as ExpDate,
'' as STNRemark,'' AS STNNO,
'' as ProfInvoice, '' as STNDate,
'' AS STNTRANSPORTER, '' AS STNLRNO,
' ' AS STNDISPLRDATE, '' AS STNDISPELDATE,
INVOICE.HORemarks as InvoiceDispatchRemark,INVOICE.BillingDocument AS INVOICE,INVOICE.BillingDate as InvoiceDate,INVOICE.InvTransporter,
INVOICE.InvLRNo, INVOICE.InvDispLRdate, INVOICE.InvDispDelDate,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.MRP,INVOICE.Cases, INVOICE.TentativeDel,
OH.BillingAddress,OH.DeliveryAddress,OH.OrderDeliveryDate  
 ,'' as STNAuthDate, INVOICE.AuthDate as INVAuthDate
 FROM invoice_Dispatch AS INVOICE, OrderHeader as OH , IBISDirectBillingUpdate AS  IBISDIR
 WHERE INVOICE.IOMNO =OH.IOMNo  AND IBISDIR.IOMNo =INVOICE.IOMNO AND INVOICE.BillingDocument = IBISDIR.DocumentNumber  
 
 UNION ALL
select OH.IOMNo , oh.IOMDate,oh.PartyCode ,OH.PartyName,
(case when STNUPD.Plnt is not null then (select DispatchThru from LocationMaster where STNUPD.Plnt = LocationMaster.LocationCode) end) STNLocation,
(case when OH.LocationCode is not null then (select DispatchThru from LocationMaster where OH.LocationCode = LocationMaster.LocationCode) end) LocationCode,
STNUPD.PartyCode as STNDispThrough, 
OH.DispThrough ,OH.Remark,STNUPD.MaterialCode , STNUPD.Description AS Productname ,
STNUPD.Batch ,STNUPD.DeliveryQuantity AS Quantity, STNUPD.MfgDate as MfgDate, STNUPD.ExpDate as ExpDate, STNDISP.HORemarks as STNRemark, STNUPD.Delivery AS STNNO,
STNUPD.BillingDocument as ProfInvoice, STNUPD.ActualGoodsMovement as STNDate,
STNDISP.InvTransporter AS STNTRANSPORTER, STNDISP.InvLRNo  AS STNLRNO,
STNDISP.InvDispLRdate AS STNDISPLRDATE, STNDISP.InvDispDelDate AS STNDISPELDATE,
'' as InvoiceDispatchRemark,'' as INVOICE, '' as InvoiceDate, '' as  nvTransporter,
'' as InvLRNo, '' as InvDispLRdate, '' as InvDispDelDate,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.MRP,'' as Cases, '' as TentativeDel,
OH.BillingAddress,OH.DeliveryAddress,OH.OrderDeliveryDate
 ,STNDISP.AuthDate as STNAuthDate, '' as INVAuthDate
 from STNInvoice_Dispatch AS STNDISP, OrderHeader as OH, STNUpload AS STNUPD
 where  STNDISP.IOMNO =OH.IOMNo  AND STNDISP.Delivery = STNUPD.Delivery   
  and stndisp.Delivery not in ( select iomno from SAPInvoiceUpload ) and STNDISP.Delivery  not in ( select IOMNo from IBISBillingUpdate )


select * from CustomerMaster where CustomerCode = '1007014'

select CustomerMaster.Name, CustomerMaster.City, CustomerMaster.Street, CustomerMaster.Street1, CustomerMaster.Street2, CustomerMaster.Street3, CustomerMaster.MobileNumber, 
CustomerMaster.PostalCode,CustomerMaster.DispatchThru, CustomerMaster.LocationCode, CustomerMaster.CustomerCode, CustomerMaster.LST_CST, 
LocationMaster.TaxOn from CustomerMaster join LocationMaster on CustomerMaster.LocationCode=LocationMaster.LocationCode 
where CustomerId = 1489

---------------------------------------------------------IOM Report--------------------------------------------------------------
select OH.IOMNo,OH.IOMDate,CAST(OH.OrderAuthoDate as DATE) as AuthrisationDate, OH.PartyCode,OH.PartyName,OH.DSM_ZSM,OH.DispThrough,OH.InstPONo,OH.InstPODate , OH.OrderRecieveDate , 
OH.OrderDeliveryDate as DeliveryDate,OH.Schedule,OH.MRP as MRPyn,
(case when OH.Institution is not null then (select Name from InstitutionMaster where OH.Institution = InstitutionMaster.Code) end) Institution,
(case when OH.SubInstitution is not null then (select Name from SubInstitutionMaster where OH.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution,
OI.ProductCode AS MaterialCode , OI.ProductName,
oi.Quantity as OrderQuantity , OI.BillingRate ,OI.MRP ,OI.EffTax ,OI.ProdValue, 
(case when OH.PartyCode is not null then (select top 1 ltrim(rtrim(Street + ' ' + Street1 + ' ' + Street2 + ' ' + Street3 + ' ' + PostalCode)) as PartyBillingAddress from CustomerMaster where OH.PartyCode = CustomerMaster.CustomerCode) end) as BillingAddress
,OH.DeliveryAddress,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.DocFile1 ,OI.MRPPrint ,OH.Lisioner, OH.Remark, OH.DocumentRequired , OH.Authorised
from OrderHeader AS OH, OrderItem  as OI where  Oh.IOMNo =OI.IOMNo and OH.Schedule!='yes'
union all 
select OH.IOMNo,OH.IOMDate,CAST(OH.OrderAuthoDate as DATE) as AuthrisationDate,OH.PartyCode,OH.PartyName,OH.DSM_ZSM,OH.DispThrough,OH.InstPONo,OH.InstPODate , OH.OrderRecieveDate , 
sd.DeliveryDate,OH.Schedule,OH.MRP as MRPyn,
(case when OH.Institution is not null then (select Name from InstitutionMaster where OH.Institution = InstitutionMaster.Code) end) Institution,
(case when OH.SubInstitution is not null then (select Name from SubInstitutionMaster where OH.SubInstitution = SubInstitutionMaster.Code) end) SubInstitution, 
SD.MaterialCode , OI.ProductName, SD.OrderQuantity , OI.BillingRate ,OI.MRP ,OI.EffTax ,OI.ProdValue, 
(case when OH.PartyCode is not null then (select top 1 ltrim(rtrim(Street + ' ' + Street1 + ' ' + Street2 + ' ' + Street3 + ' ' + PostalCode)) as PartyBillingAddress from CustomerMaster where OH.PartyCode = CustomerMaster.CustomerCode) end) as BillingAddress
,OH.DeliveryAddress,
(case when OH.StampingID is not null then (select Name from StampingMaster where OH.StampingID = StampingMaster.StampingId) end) StampingName,
OH.DocFile1 ,OI.MRPPrint ,OH.Lisioner , OH.Remark ,  OH.DocumentRequired , OH.Authorised
from ScheduleDetail as SD,OrderHeader AS OH, OrderItem  as OI where 
SD.IOMNo=OH.IOMNo  AND OI.IOMNo =SD.IOMNo AND SD.MaterialCode = OI.ProductCode and OH.Schedule='yes'

select * from OrderHeader where PartyCode in ('G99A0136','G99T0542','G99T0541','G99T0538','G99T0530','G99T0529','G99T0520','G99T0501','G99T0499','G99T0495','G99T0493','G99T0477','G99T0471','G99T0469',
'G99T0468','G99T0463','G99Z0007','G99Y0008','G99V0014','G99T0672','G99T0664','G99T0648','G99T0646','G99T0250','G99T0240','G99T0235','G99T0232','G99T0219','G99T0216','G99T0204','G99T0194','G99T0188',
'G99T0186','G99T0185','G99T0183','G99T0182','G99T0153','G99T0151','G99T0149','G99T0147','G99T0145','G99T0143','G99T0140','G99T0137','G99T0134','G99T0130','G99T0124','G99T0429','G99T0427','G99T0411',
'G99T0408','G99T0308','G99T0301','G99T0380','G99T0375','G99T0370','G99T0368','G99T0346','G99T0343','G99T0342','G99T0338','G99T0325','G99T0325','G99O0039','G99O0033','G99N0066','G99N0058','G99N0052',
'G99N0025','G99T0115','G99T0082','G99T0081','G99T0079','G99T0063','G99T0059','G99S0074','G99S0047','G99R0011','G99P0070','G99P0069','G99O0048','G99T0035','G99T0030','G99T0027','G99T0026','G99M0054',
'G99M0048','G99H0039','G99G0107','G99G0056','G99M0034','G99M0024','G99I0037','G99I0030','G99I0021','G99N0019','G99M0205','G99M0117','G99M0114','G99C0124','G99C0118','G99C0083','G99C0080','G99C0074',
'G99C0057','G99C0055','G99C0047','G99C0045','G99C0044','G99C0042','G99C0014','G99B0077','G99E0035','G99E0029','G99E0026','G99D0117','G99D0116','G99D0113','G99D0111','G99D0096','G99D0094','G99D0093',
'G99D0074','G99D0070','G99C0249','G99C0248','G99C0240','G99D0031','G99D0029','G99D0020','G99D0019','G99D0018','G99C0239','G99C0252','G99C0250','G13S0003','G15D0001','G11N0002','G24C0004','G99A0068',
'G24T0008','G24T0007','G24S0004','G24J0001','G24G0005','G12M0012','G99L0046','G01N0002','G99T0575')

select * from CustomerMaster where CustomerCode in ('G99A0136','G99T0542','G99T0541','G99T0538','G99T0530','G99T0529','G99T0520','G99T0501','G99T0499','G99T0495','G99T0493','G99T0477','G99T0471','G99T0469',
'G99T0468','G99T0463','G99Z0007','G99Y0008','G99V0014','G99T0672','G99T0664','G99T0648','G99T0646','G99T0250','G99T0240','G99T0235','G99T0232','G99T0219','G99T0216','G99T0204','G99T0194','G99T0188',
'G99T0186','G99T0185','G99T0183','G99T0182','G99T0153','G99T0151','G99T0149','G99T0147','G99T0145','G99T0143','G99T0140','G99T0137','G99T0134','G99T0130','G99T0124','G99T0429','G99T0427','G99T0411',
'G99T0408','G99T0308','G99T0301','G99T0380','G99T0375','G99T0370','G99T0368','G99T0346','G99T0343','G99T0342','G99T0338','G99T0325','G99T0325','G99O0039','G99O0033','G99N0066','G99N0058','G99N0052',
'G99N0025','G99T0115','G99T0082','G99T0081','G99T0079','G99T0063','G99T0059','G99S0074','G99S0047','G99R0011','G99P0070','G99P0069','G99O0048','G99T0035','G99T0030','G99T0027','G99T0026','G99M0054',
'G99M0048','G99H0039','G99G0107','G99G0056','G99M0034','G99M0024','G99I0037','G99I0030','G99I0021','G99N0019','G99M0205','G99M0117','G99M0114','G99C0124','G99C0118','G99C0083','G99C0080','G99C0074',
'G99C0057','G99C0055','G99C0047','G99C0045','G99C0044','G99C0042','G99C0014','G99B0077','G99E0035','G99E0029','G99E0026','G99D0117','G99D0116','G99D0113','G99D0111','G99D0096','G99D0094','G99D0093',
'G99D0074','G99D0070','G99C0249','G99C0248','G99C0240','G99D0031','G99D0029','G99D0020','G99D0019','G99D0018','G99C0239','G99C0252','G99C0250','G13S0003','G15D0001','G11N0002','G24C0004','G99A0068',
'G24T0008','G24T0007','G24S0004','G24J0001','G24G0005','G12M0012','G99L0046','G01N0002','G99T0575')

select * from LocationMaster
select * from LocationCode_Old_New
--update LocationMaster set OldLocationCode = LocationCode, OldDispatchThru = DispatchThru
--update LocationMaster set LocationMaster.NewLocationCode = LocationCode_Old_New.NewLocationCode from LocationMaster inner join LocationCode_Old_New on LocationMaster.LocationCode = LocationCode_Old_New.LocationCode
--update LocationMaster set LocationMaster.NewDispatchThru = LocationCode_Old_New.NewDispatchThru from LocationMaster inner join LocationCode_Old_New on LocationMaster.LocationCode = LocationCode_Old_New.LocationCode

select * from CustomerMaster
select * from PartyCod_Old_New
--update CustomerMaster set OldCustomerCode = CustomerCode
--update CustomerMaster set CustomerMaster.NewCustomerCode = PartyCod_Old_New.NewCustomerCode from CustomerMaster inner join PartyCod_Old_New on CustomerMaster.CustomerCode = PartyCod_Old_New.CustomerCode

--update PartyCod_Old_New set CustomerCode = '1006723', NewCustomerCode = '1006723' where ID = 1474
--update PartyCod_Old_New set CustomerCode = '1006856', NewCustomerCode = '1006856' where ID = 1475
--update PartyCod_Old_New set CustomerCode = '1006865', NewCustomerCode = '1006865' where ID = 1476
--update PartyCod_Old_New set CustomerCode = '1006866', NewCustomerCode = '1006866' where ID = 1477
--update PartyCod_Old_New set CustomerCode = '1006867', NewCustomerCode = '1006867' where ID = 1478
--update PartyCod_Old_New set CustomerCode = '1006868', NewCustomerCode = '1006868' where ID = 1479
--update PartyCod_Old_New set CustomerCode = '1006869', NewCustomerCode = '1006869' where ID = 1480
--update PartyCod_Old_New set CustomerCode = '1006873', NewCustomerCode = '1006873' where ID = 1481
--update PartyCod_Old_New set CustomerCode = '1006721', NewCustomerCode = '1006721' where ID = 1473

--update PartyCod_Old_New set NewCustomerCode = Name where ID in (1282,1278,1272,1285,1281,1273,1290,1328,1267,1270,1289,1275,1279,1268,1288,1271,1274,1280,1276,1387,1287,1277,1283,1284,1286,1269)

select * from CustomerMaster where NewCustomerCode is NULL
--update CustomerMaster set NewCustomerCode = OldCustomerCode where NewCustomerCode is NULL

select * from INFORMATION_SCHEMA.TABLES
select * from OrderTypeMaster --NC
select * from OrderIssueDetails --truncate table OrderIssueDetails
select * from OrderDispatchDetails --truncate table OrderDispatchDetails
select * from SAP_STN_Details --truncate table SAP_STN_Details
select * from SAP_INV_Details --truncate table SAP_INV_Details
select * from QueryTable --NC
select * from ShelfLifeMaster --NC
select * from tmpBatchAllocation --truncate table tmpBatchAllocation
select * from BatchAllocation --truncate table BatchAllocation
select * from OrderHeader --truncate table OrderHeader
select * from OrderItem --truncate table OrderItem
select * from ScheduleDetail --truncate table ScheduleDetail
select * from DeletedScheduleDetail --truncate table DeletedScheduleDetail
select * from DeletedOrderItem --truncate table DeletedOrderItem
select * from DeletedOrderHeader --truncate table DeletedOrderHeader
select * from CustomerWithLocation --NC
select * from CustomerType --NC
select * from CustomerMasterNEW --NC
select * from CustomerCategory --NC
select * from Country --NC
select * from DOC_REQ_Master --NC
select * from STNInvoice_Dispatch --truncate table STNInvoice_Dispatch
select * from DSM_ZSM --NC
select * from CustomerMaster --NC
select * from LocationMaster --NC
select * from LiasonerMaster --NC
select * from ItemCategory --NC
select * from IOMLogicMaster --NC need to be update
select * from Invoice_Dispatch --truncate table Invoice_Dispatch
select * from InstitutionMaster --NC
select * from SubInstitutionMaster --NC
select * from StockUpload --truncate table StockUpload
select * from StockMaster --truncate table StockMaster
select * from StampingMaster --NC
select * from CategoryMaster --NC
select * from MacDetail --NC
select * from State --NC
select * from ZoneMaster --NC
select * from UserTypeMaster --NC
select * from UserModuleRelation --NC
select * from UserMaster --NC
select * from UserLocationRelation --NC
select * from TaxTypeMaster --NC
select * from STNUpload --truncate table STNUpload
select * from TaxMaster --NC
select * from SAPInvoiceUpload --truncate table SAPInvoiceUpload
select * from DirSAPInvoiceUpload --truncate table DirSAPInvoiceUpload
select * from ModuleMaster --NC
select * from IBISDirectBillingUpdate --truncate table IBISDirectBillingUpdate
select * from IBISBillingUpdate --truncate table IBISBillingUpdate
select * from DeliveryDetailWithProduct --truncate table DeliveryDetailWithProduct
select * from ProductMaster --NC
select * from PendingReason --NC


select * from OrderHeader

select * from LocationMaster
--update LocationMaster set LocationCode = NULL, DispatchThru = NULL where LocationId in (136,148)
--update LocationMaster set IsActive = 'No' where LocationId in (136,148)

select * from CustomerMaster where CustomerCode = '1004711'
--update CustomerMaster set CustomerCode = NewCustomerCode


select CustomerMaster.Name, CustomerMaster.City, CustomerMaster.Street, CustomerMaster.Street1, CustomerMaster.Street2, CustomerMaster.Street3, CustomerMaster.MobileNumber, CustomerMaster.PostalCode, CustomerMaster.DispatchThru, CustomerMaster.LocationCode, CustomerMaster.CustomerCode, CustomerMaster.LST_CST, LocationMaster.TaxOn 
from CustomerMaster join LocationMaster on CustomerMaster.LocationCode=LocationMaster.LocationCode where CustomerId = 825

--update CustomerMaster set CustomerMaster.NewCustomerCode = PartyCod_Old_New.NewCustomerCode from CustomerMaster inner join PartyCod_Old_New on CustomerMaster.CustomerCode = PartyCod_Old_New.CustomerCode
--update CustomerMaster set CustomerMaster.LocationCode = LocationMaster.LocationCode, CustomerMaster.DispatchThru = LocationMaster.DispatchThru from CustomerMaster join LocationMaster on CustomerMaster.LocationCode=LocationMaster.LocationCode 

select DATEPART(dd,'05-18-2015')
select DATEPART(MM,'05-18-2015')
select DATEPART(yyy,getdate())
select * from StnUpload order by 1 desc
--update StnUpload set LastModify = '2015-11-09 00:00:00.000' where ID = 24993

select * from STNUpload where DATEPART(dd,LastModify) = DATEPART(dd,getdate()) and DATEPART(MM,LastModify) = DATEPART(MM,getdate()) and
DATEPART(yyyy,LastModify) = DATEPART(yyyy,getdate())
select * from STNUpload where DATEPART(dd,LastModify) = DATEPART(dd,'05-18-2015') and DATEPART(MM,LastModify) = DATEPART(MM,'05-18-2015') 
and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'05-18-2015') 

select * from SAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,getdate()) and DATEPART(MM,LastModify) = DATEPART(MM,getdate()) and
DATEPART(yyyy,LastModify) = DATEPART(yyyy,getdate())
select * from SAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,'08-10-2015') and DATEPART(MM,LastModify) = DATEPART(MM,'08-10-2015') 
and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'08-10-2015')

select * from DirSAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,getdate()) and DATEPART(MM,LastModify) = DATEPART(MM,getdate()) and
DATEPART(yyyy,LastModify) = DATEPART(yyyy,getdate())
select * from DirSAPInvoiceUpload where DATEPART(dd,LastModify) = DATEPART(dd,'08-10-2015') and DATEPART(MM,LastModify) = DATEPART(MM,'08-10-2015') 
and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'08-10-2015')

select * from IBISDirectBillingUpdate where DATEPART(dd,LastModify) = DATEPART(dd,getdate()) and DATEPART(MM,LastModify) = DATEPART(MM,getdate()) and
DATEPART(yyyy,LastModify) = DATEPART(yyyy,getdate())
select * from IBISDirectBillingUpdate where DATEPART(dd,LastModify) = DATEPART(dd,'09-03-2015') and DATEPART(MM,LastModify) = DATEPART(MM,'09-03-2015') 
and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'09-03-2015')

select * from IBISBillingUpdate where DATEPART(dd,LastModify) = DATEPART(dd,getdate()) and DATEPART(MM,LastModify) = DATEPART(MM,getdate()) and
DATEPART(yyyy,LastModify) = DATEPART(yyyy,getdate())
select * from IBISBillingUpdate where DATEPART(dd,LastModify) = DATEPART(dd,'09-03-2015') and DATEPART(MM,LastModify) = DATEPART(MM,'09-03-2015') 
and DATEPART(yyyy,LastModify) = DATEPART(yyyy,'09-03-2015')

