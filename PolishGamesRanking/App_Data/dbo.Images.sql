CREATE TABLE [dbo].[Table]
(
	[ImageId] INT NOT NULL PRIMARY KEY, 
    [ImageSize] INT NOT NULL, 
    [FileName] VARCHAR(200) NOT NULL, 
    [ImageData] VARBINARY(MAX) NOT NULL
)
