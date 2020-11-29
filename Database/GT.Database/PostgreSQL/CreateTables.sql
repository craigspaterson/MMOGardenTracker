﻿DROP TABLE IF EXISTS dbo."CropActivity" CASCADE;
DROP TABLE IF EXISTS dbo."Crop" CASCADE;
DROP TABLE IF EXISTS dbo."Garden" CASCADE;

CREATE TABLE dbo."Garden"
(
    "GardenId" INT GENERATED ALWAYS AS IDENTITY NOT NULL,          
    "GardenName" VARCHAR(60) NOT NULL,
    CONSTRAINT "PK_Garden" PRIMARY KEY ("GardenId"),
    CONSTRAINT "AK_GardenName" UNIQUE ("GardenName")
);

CREATE TABLE dbo."Crop"
(
    "CropId" INT GENERATED ALWAYS AS IDENTITY NOT NULL,
    "CropName" VARCHAR(60) NOT NULL,
    "GardenId" INT NOT NULL,
    "PlantName" VARCHAR(60) NOT NULL,
    "BeginDate" TIMESTAMPTZ NOT NULL,
    "EndDate" TIMESTAMPTZ NULL,
    "Notes" VARCHAR(255) NULL,
    CONSTRAINT "PK_Crop" PRIMARY KEY ("CropId"),
    CONSTRAINT "AK_CropName" UNIQUE ("CropName"),
    CONSTRAINT "FK_Crop_Garden" FOREIGN KEY ("GardenId") REFERENCES dbo."Garden"("GardenId")
);

CREATE TABLE dbo."CropActivity"
(
    "CropActivityId" INT GENERATED ALWAYS AS IDENTITY NOT NULL,
    "CropId" INT NOT NULL,
    "ActivityId" INT NOT NULL,
    "ActivityDate" TIMESTAMPTZ NOT NULL,
    "Notes" VARCHAR(255) NULL,
    CONSTRAINT "PK_CropActivity" PRIMARY KEY ("CropActivityId"),
    CONSTRAINT "FK_CropActivity_Crop" FOREIGN KEY ("CropId") REFERENCES dbo."Crop"("CropId"),
    CONSTRAINT "AK_CropActivity_Crop_Activity_Date" UNIQUE ("CropId", "ActivityId", "ActivityDate")
);