if exists (Select 1 from sys.columns
inner join sys.objects on sys.columns.object_id = sys.objects.object_id
where sys.columns.name = 'explanation' and sys.objects.name = 'Answers')
begin
	Alter table [Answers] drop column explanation
end

Alter table [Answers] add [explanation] varchar(max) null