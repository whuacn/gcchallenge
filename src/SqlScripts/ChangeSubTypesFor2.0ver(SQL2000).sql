-- Autor: Yuriy Stasiv
-- Version: 1.0b
-- Description: DB - 'GmatClubChallenge'. Override SubTypes for 2.0 version
	--Deleted SubTypes:
	--			DataSufficiency
	--			ProblemSolving 
	--Addet SubTypes:
	--			  Arithmetic
	--            Algebra
	--            Word Problems
	--            Geometry
	--            Statistics
	--            Probability
	--            Combinations 
begin tran -- begin transaction
--begin try -- begin global try for commit or roll back changes
	
	SET IDENTITY_INSERT QuestionSubtypes ON 

	declare @DataSufficiencyStr varchar(255)
	set @DataSufficiencyStr = 'Data sufficiency'
	declare @ProblemSolvingStr varchar(255)
	set @ProblemSolvingStr = 'Problem solving'

	--id for new subTypes
	declare @id bigInt
	
	set @id = (Select max(id) from QuestionSubtypes)

	declare @DataSufficiencyId bigint
	declare @ProblemSolvingId bigint
	declare @ArithmeticId bigint

	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Arithmetic')

	set @ArithmeticId = (Select max(id) from QuestionSubtypes)
	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Algebra')
	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Word Problems')
	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Geometry')
	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Statistics')
	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Probability')
	set @id = @id + 1
	insert into QuestionSubtypes (id, Name)
		 values (@id, 'Combinations')

	Set @DataSufficiencyId = (Select id from QuestionSubtypes where name like @DataSufficiencyStr)
	Set @ProblemSolvingId = (Select id from QuestionSubtypes where name like @ProblemSolvingStr)

	-- Update Questions
	Update Questions set SubtypeId = @ArithmeticId 
	where SubtypeId = @DataSufficiencyId or SubtypeId = @ProblemSolvingId

	--Update QuestionSets
	Update QuestionSets set QuestionSubtypeId = @ArithmeticId 
	where QuestionSubtypeId = @DataSufficiencyId or QuestionSubtypeId = @ProblemSolvingId

	--Update Tests
	Update Tests set QuestionSubtypeId = @ArithmeticId 
	where QuestionSubtypeId = @DataSufficiencyId or QuestionSubtypeId = @ProblemSolvingId

	Delete from QuestionSubtypes where name like @DataSufficiencyStr
	Delete from QuestionSubtypes where name like @ProblemSolvingStr


	select * from QuestionSubtypes -- This data need for update Subtype enum in ..\Data\Question.cs file 
	SET IDENTITY_INSERT QuestionSubtypes OFF

	--
	commit --Commit changes
	--
  

--end try
--begin catch
--	select Error_message() -- Show error and roll back changes	
--	rollback
--end catch	

