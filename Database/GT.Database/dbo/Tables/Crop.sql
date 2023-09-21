USE GardenTracker;

CREATE TABLE [dbo].[Crop]
(
    [CropId] INT IDENTITY (1, 1) NOT NULL, 
    [CropName] NVARCHAR(60) NOT NULL,
    [GardenId] INT NOT NULL, 
    [PlantName] NVARCHAR(60) NOT NULL, 
    [BeginDate] DATETIMEOFFSET NOT NULL,
    [EndDate] DATETIMEOFFSET NULL,
    [Notes] NVARCHAR(255) NULL, 
    CONSTRAINT [PK_Crop] PRIMARY KEY CLUSTERED ([CropId] ASC),
    CONSTRAINT [AK_CropName] UNIQUE NONCLUSTERED ([CropName] ASC),
    CONSTRAINT [FK_Crop_Garden] FOREIGN KEY ([GardenId]) REFERENCES [dbo].[Garden]([GardenId])
);
