CREATE TABLE [dbo].[RatedGames] (
    [Id]                 INT            NOT NULL IDENTITY,
    [GameId]             INT            NOT NULL,
    [ApplicationUser_Id] NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.RatedGames] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.RatedGames_dbo.AspNetUsers_ApplicationUser_Id] FOREIGN KEY ([ApplicationUser_Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ApplicationUser_Id]
    ON [dbo].[RatedGames]([ApplicationUser_Id] ASC);

