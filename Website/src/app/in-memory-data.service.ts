import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Crop } from './crops/crop';

@Injectable({
  providedIn: 'root'
})
export class InMemoryDataService implements InMemoryDbService {
  constructor() {}

  createDb() {

    // const x = JSON.parse('../app/data/crops.json');
    // console.log('The JSON.parse object count is: ' + x.length);

    const crops = [
      {
        id: 1,
        gardenId: 1,
        cropId: 1,
        cropName: 'Tomato Crop 1',
        plantName: 'Roma Tomato',
        beginDate: '02/15/2018 00:00:00',
        endDate: '10/15/2018 00:00:00',
        notes: 'Some sample notes.',
        cropActivities: [
          {
            cropActivityId: 1,
            cropId: 1,
            activityType: 2,
            activityDate: '02/15/2018 00:00:00',
            notes: 'Used heating pad.'
          }
        ]
      }
    ];

    const gardens = [
      {
        id: 1,
        gardenId: 1,
        gardenName: 'Garden 1',
        crops: [
          {
            id: 1,
            gardenId: 1,
            cropId: 1,
            cropName: 'Tomato Crop 1',
            plantName: 'Roma Tomato',
            beginDate: '02/15/2018 00:00:00',
            endDate: '10/15/2018 00:00:00',
            notes: 'Some sample notes.',
            cropActivities: [
              {
                cropActivityId: 1,
                cropId: 1,
                activityType: 2,
                activityDate: '02/15/2018 00:00:00',
                notes: 'Used heating pad.'
              }
            ]
          }
        ]
      },
      {
        id: 2,
        gardenId: 2,
        gardenName: 'Garden 2'
      },
      {
        id: 3,
        gardenId: 3,
        gardenName: 'Garden 3'
      },
      {
        id: 4,
        gardenId: 4,
        gardenName: 'Garden 4'
      },
      {
        id: 5,
        gardenId: 5,
        gardenName: 'Garden 5'
      },
      {
        id: 6,
        gardenId: 6,
        gardenName: 'Garden 6'
      },
      {
        id: 7,
        gardenId: 7,
        gardenName: 'Garden 7'
      },
      {
        id: 8,
        gardenId: 8,
        gardenName: 'Garden 8'
      },
      {
        id: 9,
        gardenId: 9,
        gardenName: 'Garden 9'
      },
      {
        id: 10,
        gardenId: 10,
        gardenName: 'Garden 10'
      }
    ];

    return { crops, gardens };

    // const db = { crops, heroes };
    // const db = { crops };

    // return { db };
  }
}
