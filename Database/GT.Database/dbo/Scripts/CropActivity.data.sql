-- CropActivity.data.sql
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
SET NOCOUNT ON
SET IDENTITY_INSERT [dbo].[CropActivity] ON
GO
DECLARE @Data TABLE (
   [CropActivityId] [INT] NOT NULL,
   [CropId] [INT] NOT NULL,
   [ActivityId] [INT] NOT NULL,
   [ActivityDate] DATETIMEOFFSET NOT NULL,
   [Notes] [NVARCHAR](255)
   PRIMARY KEY ([CropActivityId])
);
INSERT @Data (
   [CropActivityId],
   [CropId],
   [ActivityId],
   [ActivityDate],
   [Notes]
)
SELECT 1, 1, 3, '2019-11-28 18:52:00.760000', NULL 

MERGE INTO [dbo].[CropActivity] tar
USING  @Data dat ON dat.[CropActivityId] = tar.[CropActivityId] 
-- Delete rows from target NOT in source 
--WHEN NOT MATCHED BY SOURCE THEN 
--   DELETE 
-- Update rows which differ between target and source
WHEN MATCHED 
  AND ( tar.[CropActivityId]   != dat.[CropActivityId] ) THEN 
     UPDATE SET 
        tar.[Notes]   = dat.[Notes]
-- Insert rows from source script not in target
WHEN NOT MATCHED BY TARGET THEN 
  INSERT ( 
     [CropActivityId],
     [CropId],
     [ActivityId],
     [ActivityDate],
     [Notes]
   )
  VALUES (
     dat.[CropActivityId],
     dat.[CropId],
     dat.[ActivityId],
     dat.[ActivityDate],
     dat.[Notes]
     );
GO

SET IDENTITY_INSERT [dbo].[CropActivity] OFF
GO
