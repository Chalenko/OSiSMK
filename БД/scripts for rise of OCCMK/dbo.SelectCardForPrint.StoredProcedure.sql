USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectCardForPrint]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectCardForPrint] @docid int
AS
BEGIN

SELECT 
	k.id										'Номер'
	,dt.docType									'Тип'
	,k.obozn									'Обозначение'
	,k.name										'Наименование'
	,k.original									'Оригинал'
	,k.controlCopyExist							'Копия'
	,k.dateEndOfAction							'Дата окончания'
	,convert (varchar(10),k.dateEnter,104)		'Дата введения'
	,dst.status									'Статус'
	,dsc.docSecret								'Секретность'
	,zi.number									'Запрос номер'
	,convert (varchar(10),zi.data,104)			'Запрос дата'
	,reqDev.developer							'Запрос адрес'
	,pInfo.number								'Получение номер'
	,convert (varchar(10),pinfo.regdata,104)	'Получение дата регистрации'
	,convert (varchar(10),pinfo.poluchDate,104)	'Получение дата'
	,pinfo.kolvo								'Получение количество'
	,recDev.developer							'Получение адрес'
	,dev.developer								'Разработчик'
	,vzk.obozn									'Взамен обозначение'
	,vzk.name									'Взамен наименование'
	,docTypeZam.docType							'Заменен тип'
	,zamk.obozn									'Заменен обозначение'
	,zamk.name									'Заменен наименование'
	,convert (varchar(10),zamk.dateEnter,104)	'Заменен дата'
	,dvi.vnedNumber								'Внедрение номер'
	,convert (varchar(10),dvi.vnedDate,104)		'Внедрение дата'
	,depVnedr.code								'Внедрение подразделение индекс'
	,depVnedr.name								'Внедрение подразделение наименование'
	,dvi.orderNum								'Внедрение приказ'
	,convert (varchar(10),dvi.orderDate,104)	'Внедрение дата приказ'
	,convert (varchar(10),dvi.endOTM,104)		'Внедрение дата ОТМ'
	,convert (varchar(10),dvi.vvedDate,104)		'Внедрение дата введение'
	,av.number									'Акт внедрение номер'
	,convert (varchar(10),av.data,104)			'Акт внедрение дата'
	,ap.number									'Акт проверка номер'
	,convert (varchar(10),ap.data,104)			'Акт проверка дата'
	,convert (varchar(10),k.dateProv,104)		'Проверка дата'
	
FROM 
	kart k
	LEFT JOIN docType dt						ON dt.id = k.docTypeId
	LEFT JOIN docStatus	dst						ON dst.id = k.docStatus
	LEFT JOIN docSecret	dsc						ON dsc.id = k.docSecret
	LEFT JOIN zaprosInfo zi						ON zi.docId = k.id
	LEFT JOIN developer reqDev					ON reqDev.id = zi.addres
	LEFT JOIN poluchatelInfo pInfo				ON pInfo.docId = k.id
	LEFT JOIN developer recDev					ON recDev.id = pinfo.addres
	LEFT JOIN developer dev						ON dev.id = k.docDevel
	LEFT JOIN kart vzk							ON vzk.id = k.zamenen
	LEFT JOIN kart zamk							ON zamk.id = k.vzamen
	LEFT JOIN docType docTypeZam				ON docTypeZam.id = zamk.docTypeId
	LEFT JOIN docVvodInfo dvi					ON dvi.id = k.id
	LEFT JOIN departments depVnedr				ON depVnedr.id = dvi.podrId
	LEFT JOIN ActVnedren av						ON av.id = k.id
	LEFT JOIN ActProverky ap					ON ap.id = k.id
WHERE
	k.id = @docid

end
GO
