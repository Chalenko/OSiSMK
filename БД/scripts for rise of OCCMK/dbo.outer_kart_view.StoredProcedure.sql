USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[outer_kart_view]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[outer_kart_view] @id int
as begin
set dateformat dmy 

select 
	k.id								'Номер' 
	,dt.docType							'Тип' 
	,k.controlCopyExist					'Контрольная копия' 
	,k.original							'Оригинал' 
	,k.obozn							'Обозначение' 
	,k.name								'Наименование документа' 
	,CONVERT(varchar(10), k.dateenter, 104)  'Дата введения' 
	,ds.status							'Статус' 
	,sec.docsecret						'Секретность' 
	,dev.developer						'Разработчик' 
	,CONVERT(varchar(10), k.dateprov, 104) 'Дата проверки' 
	,CONVERT(varchar(10), k.dateEndOfAction, 104) 'end'
	,k.vzamen, k2.obozn vzamenobozn 
	,k.zamenen, k3.obozn zamenenobozn 
	,av.number vnednum, CONVERT(varchar(10), av.data, 104) vneddat, av.id vnedid 
	,ap.number provnum,CONVERT(varchar(10), ap.data, 104) provdat, ap.id provid 
	,dv.podrid							'Номер подразделения' 
	,dv.vnednumber divnum, dv.divdat ddat, dv.codpodr dicod, dv.ordernum diord, dv.diorddat ordat, dv.diotm otm, dv.divved vved 
	,zap.number zapnum, CONVERT(varchar(10),zap.data, 104) zapdat, zap.developer zapdev
	,pol.number polnum, CONVERT(varchar(10),pol.regdata, 104) polreg, CONVERT(varchar(10), pol.poluchdate, 104) pol, pol.kolvo polkol, pol.developer poldev 

from Kart k
	left join doctype dt on dt.id = k.doctypeid
	left join docstatus ds on ds.id = k.docstatus 
	left join docsecret sec on sec.id = k.docsecret
	left join developer dev on dev.id = k.docdevel
	left join departments dep on dep.id = k.docdevel
	left join kart k2 on k2.id = k.vzamen  
	left join kart k3 on k3.id = k.zamenen
	left join actvnedren av on av.id = k.vnedrAct 
	left join actproverky ap on ap.id = k.provAct 
	left join
			(select di.docid,di.vnednumber,CONVERT(varchar(10),di.vneddate,104) divdat, di.podrid, dep.code+'/'+dep.name codpodr,di.ordernum,CONVERT(varchar(10),di.orderdate, 104) diorddat,CONVERT(varchar(10),di.endotm, 104) diotm,CONVERT(varchar(10),di.vveddate, 104) divved
			 from DocVvodInfo di left join departments dep on dep.id=di.podrId) dv
			 on dv.docid = k.id
	left join 
	         (select z.docid,z.number,z.data,dev.developer from zaprosinfo z
              left join developer dev
              on dev.id=z.addres) zap
              on zap.docid=k.id
	left join 
	         (select p.docid,p.number,p.regdata,p.poluchdate,p.kolvo,dev.developer from poluchatelinfo p
              left join developer dev
              on dev.id=p.addres) pol
              on pol.docid=k.id
              	
where k.id = @id

end
GO
