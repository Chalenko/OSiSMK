USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[SelectPodrDocStatisticForPrint]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPodrDocStatisticForPrint]
	@podrId int

AS BEGIN


		SELECT     row_number() OVER (partition BY docId, copyName ORDER BY docId, podrId, copyName, id DESC) rn, 
					[id], [docId], [podrId],  [copyName], [copyStatus]
		into #t1
		FROM PodrDoc
		WHERE  podrId = @podrId
		and 
		copyStatus in (1,3)--spisan i spisan po aktu
		order by docId

		select docId, 
				count(copyName) as copyReturnedCount 
		into #countReturnedCopyTable 
		from #t1
		where rn=1 
		group by docId

		drop table #t1
		
		select 
			pd.docId
			,(select name from Kart where id = pd.docId) name
			,count(distinct pd.copyName) copySumCount
		into #uniqueDocTable
		from podrDoc pd
			left join Kart k on k.id = pd.docId
		where pd.docId in 
					(
						select distinct docId from podrDoc where podrId = @podrId
					) 
					and pd.podrId = @podrId
		group by (pd.docId)
		order by docId

		select 
		ud.docId						"Номер"
		,name							"Наименование"
		,copySumCount					"Количество экземпляров"
		,copyReturnedCount				"Количество списанных экземпляров"
		from #uniqueDocTable ud
		left join #countReturnedCopyTable crd on crd.docId = ud.docId
		


		drop table #uniqueDocTable
		drop table #countReturnedCopyTable
END
GO
