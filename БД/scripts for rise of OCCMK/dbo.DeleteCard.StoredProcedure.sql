USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCard]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[DeleteCard] @docID int


as begin

BEGIN TRANSACTION

DELETE 
FROM 
	ActProverky 
WHERE 
	id = @docID 

DELETE 
FROM 
	ActVnedren 
WHERE 
	id = @docID 

DELETE 
FROM 
	ZaprosInfo 
WHERE 
	docId = @docID 

DELETE 
FROM 
	PoluchatelInfo 
WHERE 
	docId = @docID 

DELETE 
FROM 
	Kart 
WHERE 
	id = @docID 

UPDATE 
	Kart 
SET 
	Vzamen = null 
WHERE 
	Vzamen = @docID 

UPDATE 
	Kart 
SET 
	Zamenen = null 
WHERE 
	Zamenen = @docID 

DELETE 
FROM 
	DocVvodInfo 
WHERE 
	docId = @docID 

DELETE 
FROM 
	DocChange 
WHERE 
	docId = @docID 

DELETE 
FROM 
	PodrDoc 
WHERE 
	docId = @docID 

IF @@ERROR = 0
COMMIT
ELSE 
ROLLBACK

end
GO
