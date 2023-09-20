USE GardenTracker;

CREATE TABLE [dbo].[Garden]
(
    [GardenId] INT IDENTITY (1, 1) NOT NULL, 
    [GardenName] NVARCHAR(60) NOT NULL,
    CONSTRAINT [PK_Garden] PRIMARY KEY CLUSTERED ([GardenId] ASC),
    CONSTRAINT [AK_GardenName] UNIQUE NONCLUSTERED ([GardenName] ASC)
);