-- Crop.data.sql
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET NOCOUNT ON
SET IDENTITY_INSERT [dbo].[Crop] ON
GO
DECLARE @Data TABLE (
    [CropId] INT NOT NULL, 
    [CropName] NVARCHAR(60) NOT NULL,
    [GardenId] INT NOT NULL, 
    [PlantName] NVARCHAR(60) NOT NULL, 
    [BeginDate] DATETIMEOFFSET NOT NULL,
    [EndDate] DATETIMEOFFSET NULL,
    [Notes] NVARCHAR(255) NULL
   PRIMARY KEY ([CropId])
);
INSERT @Data (
   [CropId],
   [CropName],
   [GardenId],
   [PlantName],
   [BeginDate],
   [EndDate],
   [Notes]
)
SELECT 1, N'Tomato Crop 1', 1, N'Roma Tomato', '02/15/2018 00:00:00', '10/15/2018 00:00:00', N'Some sample notes.' UNION ALL
SELECT 2, N'Jalapeno Crop 1', 1, N'Giant Jalapeno', '02/15/2018 00:00:00', '10/15/2018 00:00:00', N'Some sample notes.'

MERGE INTO [dbo].[Crop] tar
USING  @Data dat ON dat.[CropId] = tar.[CropId] 
-- Delete rows from target NOT in source 
--WHEN NOT MATCHED BY SOURCE THEN 
--   DELETE 
-- Update rows which differ between target and source
WHEN MATCHED 
  AND ( tar.[CropName]   != dat.[CropName] ) THEN 
     UPDATE SET 
        tar.[CropName]   = dat.[CropName]
-- Insert rows from source script not in target
WHEN NOT MATCHED BY TARGET THEN 
  INSERT ( 
     [CropId],
     [CropName],
     [GardenId],
     [PlantName],
     [BeginDate],
     [EndDate],
     [Notes]
   )
  VALUES (
     dat.[CropId],
     dat.[CropName],
     dat.[GardenId],
     dat.[PlantName],
     dat.[BeginDate],
     dat.[EndDate],
     dat.[Notes]
     );
GO

SET IDENTITY_INSERT [dbo].[Crop] OFF
GO