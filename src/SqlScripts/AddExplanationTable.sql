

if exists(Select * from sys.objects where name = 'explanations')
begin
	drop table explanations
end

Create table explanations
(
	id bigint identity(0,1) primary key
	, questionId int not null references questions on delete cascade 
	, explanation varchar(max)
)

Alter table explanations add constraint uk__explanations__questionId unique(questionId)
