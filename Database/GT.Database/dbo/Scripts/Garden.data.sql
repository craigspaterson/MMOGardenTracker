-- Garden.data.sql
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET NOCOUNT ON
SET IDENTITY_INSERT [dbo].[Garden] ON
GO
DECLARE @Data TABLE (
   [GardenId]   [INT]               NOT NULL,
   [GardenName] [NVARCHAR](60) NOT NULL
   PRIMARY KEY ([GardenId])
);
INSERT @Data (
   [GardenId],
   [GardenName]
)
SELECT 1, N'Garden 1' UNION ALL
SELECT 2, N'Garden 2' UNION ALL
SELECT 3, N'Garden 3'

MERGE INTO [dbo].[Garden] tar
USING  @Data dat ON dat.[GardenId] = tar.[GardenId] 
-- Delete rows from target NOT in source 
--WHEN NOT MATCHED BY SOURCE THEN 
--   DELETE 
-- Update rows which differ between target and source
WHEN MATCHED 
  AND ( tar.[GardenName]   != dat.[GardenName] ) THEN 
     UPDATE SET 
        tar.[GardenName]   = dat.[GardenName]
-- Insert rows from source script not in target
WHEN NOT MATCHED BY TARGET THEN 
  INSERT ( 
     [GardenId],
     [GardenName]
   )
  VALUES (
     dat.[GardenId],
     dat.[GardenName]
     );
GO

SET IDENTITY_INSERT [dbo].[Garden] OFF
GO