using MyRazor.Models;

namespace MyRazor.Abstract
{
    public interface IPhoto <T> where T : class
    {
        IEnumerable<T> GetPhotoAllorById(string id);
        Status AddOrEditPhoto(T model);
		T GetPhotoById(string id);
	}
}

/*
 
CREATE TABLE [dbo].[Photo] (
	[Id][int] IDENTITY primary key,
	[Name] [nvarchar] (1000),
	[Extension][varchar] (10),
	[Width][int],
	[Height][int],
	[DateCreated][datetime])


 ALTER proc [dbo].[pPhoto] -- GetPhotoAllorById
@id int
as
select 
		Id,
		Name,
		Extension,
		Width,
		Height,
		DateCreated
from	Photo
where (@id is null or @id = 0 or id = @id)
GO

ALTER proc [dbo].[pPhoto];2 -- AddOrEditPhoto
@id int,
@Name nvarchar(1000),
@Extension varchar(10),
@Width int,
@Height int,
@DateCreated datetime
as

--	declare
--		@result int
--	exec @result = pPhoto;2 0, 'photo_1', 'png', 10, 20, getdate()
--	select @result

if @id = 0
	begin
		if exists(select 1
					from dbo.Photo p
					where p.name = @Name
					and p.Extension = @Extension
					)
					return 0
		INSERT INTO dbo.Photo
			   (Name
			   , Extension
			   , Width
			   , Height
			   , DateCreated)
		 VALUES
			   (@Name,
				@Extension,
				@Width,
				@Height,
				@DateCreated)
		return 1
	end
	else
	begin
		UPDATE dbo.Photo
		   SET Name = @Name,
			  Extension = @Extension,
			  Width = @Width,
			  Height = @Height,
			  DateCreated = @DateCreated
			 WHERE id = @id
			 return 1
		end
 
 */