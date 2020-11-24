-- Garden
INSERT INTO dbo."Garden" ("GardenId", "GardenName") VALUES (DEFAULT, 'Garden 1');
INSERT INTO dbo."Garden" ("GardenId", "GardenName") VALUES (DEFAULT, 'Garden 2');
INSERT INTO dbo."Garden" ("GardenId", "GardenName") VALUES (DEFAULT, 'Garden 3');

-- Crop
INSERT INTO dbo."Crop" ("CropId", "CropName", "GardenId", "PlantName", "BeginDate", "EndDate", "Notes") VALUES (DEFAULT, 'Tomato Crop 1', 1, 'Roma Tomato', '2018-02-23 17:28:34.812000', '2018-10-15 14:30:00.132000', 'Some sample notes.');
INSERT INTO dbo."Crop" ("CropId", "CropName", "GardenId", "PlantName", "BeginDate", "EndDate", "Notes") VALUES (DEFAULT, 'Jalapeno Crop 1', 1, 'Giant Jalapeno', '2018-02-23 17:28:34.812000', '2018-10-15 14:30:00.132000', 'Some sample notes.');

-- CropActivity
