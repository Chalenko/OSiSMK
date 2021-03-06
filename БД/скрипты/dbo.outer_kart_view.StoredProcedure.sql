USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[outer_kart_view]    Script Date: 12/22/2015 16:10:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[outer_kart_view] @id int
AS BEGIN
SET DATEFORMAT dmy 

SELECT 
	k.id									'Номер' 
	,dt.docType								'Тип' 
	,k.controlCopyExist						'Контрольная копия' 
	,k.original								'Оригинал' 
	,k.obozn								'Обозначение' 
	,k.name									'Наименование документа' 
	,CONVERT(varchar(10), k.dateenter, 104) 'Дата введения' 
	--,k.dateenter							'Дата введения' 
	,ds.status								'Статус' 
	,sec.docsecret							'Секретность' 
	,dev.developer							'Разработчик' 
	,CONVERT(varchar(10), k.dateprov, 104)	'Дата проверки' 
	,CONVERT(varchar(10), k.dateEndOfAction, 104) 'Дата окончания'
	,k.vzamen
	,k2.obozn								vzamenobozn 
	,k.zamenen
	,k3.obozn								zamenenobozn 
	,av.number								vnednum
	,CONVERT(varchar(10), av.data, 104)		vneddat
	,av.id									vnedid 
	,ap.number								provnum
	,CONVERT(varchar(10), ap.data, 104)		provdat
	,ap.id									provid 
	,dv.podrid								'Номер подразделения' 
	,dv.vnednumber							divnum
	,dv.divdat								ddat
	,dv.codpodr								dicod
	,dv.ordernum							diord
	,dv.diorddat							ordat
	,dv.diotm								otm
	,dv.divved								vved 
	,zap.number								zapnum
	,CONVERT(varchar(10), zap.data, 104)	zapdat
	,zap.developer							zapdev
	,pol.number								polnum
	,CONVERT(varchar(10), pol.regdata, 104)	polreg
	,CONVERT(varchar(10), pol.poluchdate, 104) pol
	,pol.kolvo								polkol
	,pol.developer							poldev 
FROM Kart k
	LEFT JOIN doctype		dt	ON dt.id = k.doctypeid
	LEFT JOIN docstatus		ds	ON ds.id = k.docstatus 
	LEFT JOIN docsecret		sec ON sec.id = k.docsecret
	LEFT JOIN developer		dev ON dev.id = k.docdevel
	LEFT JOIN departments	dep ON dep.id = k.docdevel
	LEFT JOIN kart			k2	ON k2.id = k.vzamen  
	LEFT JOIN kart			k3	ON k3.id = k.zamenen
	LEFT JOIN actvnedren	av	ON av.id = k.vnedrAct 
	LEFT JOIN actproverky	ap	ON ap.id = k.provAct 
	LEFT JOIN (
		SELECT 
			di.docid
			,di.vnednumber
			,CONVERT(varchar(10),di.vneddate,104)				divdat
			,di.podrid
			,dep.code+'/'+dep.name								codpodr
			,di.ordernum,CONVERT(varchar(10),di.orderdate, 104) diorddat
			,CONVERT(varchar(10),di.endotm, 104)				diotm
			,CONVERT(varchar(10),di.vveddate, 104)				divved
		FROM DocVvodInfo di 
		LEFT JOIN departments dep ON dep.id=di.podrId)
							dv	ON dv.docid = k.id
	LEFT JOIN (
		SELECT 
			z.docid
			,z.number
			,z.data
			,dev.developer 
		FROM zaprosinfo z
		LEFT JOIN developer dev	ON dev.id=z.addres) 
							zap ON zap.docid=k.id
	LEFT JOIN (
		SELECT 
			p.docid
			,p.number
			,p.regdata
			,p.poluchdate
			,p.kolvo
			,dev.developer
		FROM poluchatelinfo p 
		LEFT JOIN developer dev ON dev.id=p.addres)
							pol ON pol.docid=k.id
WHERE k.id = @id

END
GO
