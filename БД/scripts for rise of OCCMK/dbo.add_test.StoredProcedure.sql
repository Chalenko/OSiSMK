USE [OCCMK]
GO
/****** Object:  StoredProcedure [dbo].[add_test]    Script Date: 12/03/2015 12:20:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[add_test] @val varchar(100)
as begin
insert into test values (@val) 
end
GO
