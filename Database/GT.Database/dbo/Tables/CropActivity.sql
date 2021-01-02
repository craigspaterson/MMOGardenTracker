CREATE TABLE [dbo].[CropActivity]
(
    [CropActivityId] INT IDENTITY (1, 1) NOT NULL,
    [CropId] INT NOT NULL,
    [ActivityId] INT NOT NULL,
    [ActivityDate] DATETIMEOFFSET NOT NULL,
    [Notes] NVARCHAR(255) NULL,
    CONSTRAINT [PK_CropActivity] PRIMARY KEY CLUSTERED ([CropActivityId] ASC),
    CONSTRAINT [FK_CropActivity_Crop] FOREIGN KEY ([CropId]) REFERENCES [dbo].[Crop]([CropId]),
    CONSTRAINT [AK_CropActivity_Crop_Activity_Date] UNIQUE NONCLUSTERED ([CropId] ASC, [ActivityId] ASC, [ActivityDate] ASC)
)
