// Required for all Angular tests
import { TestBed, inject } from '@angular/core/testing';

// Required for mocking HTTP requests
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CropService } from './crop.service';
import { Crop } from './crop';

describe('CropService', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: CropService;

  beforeEach(() => {
    TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
    providers: [CropService],
    teardown: { destroyAfterEach: false }
});

    // Inject the http service and test controller for each test
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);

    service = TestBed.get(CropService);
  });

  // Tear Down each test
  afterEach(() => {
    // Calling verify ensures that none of the HTTP requests are outstanding, tests with
    // open requests will fail
    httpTestingController.verify();
  });

  // it('should be created', inject([CropService], (service: CropService) => {
  //   expect(service).toBeTruthy();
  // }));

  // Initialization
  describe('initialization', () => {
    it('should be created', () => {
      expect(service).toBeDefined();
    });

    it('has 5 methods', () => {
      expect(service.getCrops).toBeDefined();
      expect(service.getCropByCropId).toBeDefined();
      expect(service.postCrop).toBeDefined();
      expect(service.putCrop).toBeDefined();
      expect(service.deleteCrop).toBeDefined();
    });
  });

  describe('getCrops', () => {
    const testUrl = '/api/crops';

    // Mock the response data
    const mockData: Crop = {
      gardenId: 1,
      cropId: 1,
      cropName: 'Tomato Crop 1',
      plantName: 'Roma Tomato',
      beginDate: new Date(2018, 2, 15, 0, 0, 0),
      endDate: new Date(2018, 10, 15, 0, 0, 0),
      notes: 'Some sample notes.',
      cropActivities: [
        {
          cropActivityId: 1,
          cropId: 1,
          activityType: 2,
          activityDate: new Date(2018, 2, 15, 0, 0, 0),
          notes: 'Used heating pad.'
        }
      ]
    };

    it('should make a GET request', () => {
      // Make an HTTP GET request
      httpClient.get<Crop>(testUrl).subscribe(data =>
        // When observable resolves, result should match mock data
        expect(data).toEqual(mockData)
      );

      // The following `expectOne()` will match the request's URL.
      // If no requests or multiple requests matched that URL
      // `expectOne()` would throw.
      const req = httpTestingController.expectOne(testUrl);

      // Assert that the request is a GET.
      expect(req.request.method).toEqual('GET');

      // Respond with mock data, causing Observable to resolve.
      // Subscribe callback asserts that correct data was returned.
      req.flush(mockData);
    });
  });

  describe('getCropByCropId', () => {
    const testUrl = '/api/crops/crop/';
    const cropId = 1;

    // Mock the response data
    const mockData: Crop[] = [
      {
        gardenId: 1,
        cropId: 1,
        cropName: 'Tomato Crop 1',
        plantName: 'Roma Tomato',
        beginDate: new Date(2018, 2, 15, 0, 0, 0),
        endDate: new Date(2018, 10, 15, 0, 0, 0),
        notes: 'Some sample notes.',
        cropActivities: [
          {
            cropActivityId: 1,
            cropId: 1,
            activityType: 2,
            activityDate: new Date(2018, 2, 15, 0, 0, 0),
            notes: 'Used heating pad.'
          }
        ]
      }
    ];

    it('should make a GET request', () => {
      // Make an HTTP GET request
      httpClient.get<Crop[]>(testUrl + `/${cropId}`).subscribe(data => {
        expect(data).toEqual(mockData);
        expect(data[0].cropId).toEqual(mockData[0].cropId);
        expect(data[0].cropId).toEqual(cropId);
      });

      // The following `expectOne()` will match the request's URL.
      // If no requests or multiple requests matched that URL
      // `expectOne()` would throw.
      const req = httpTestingController.expectOne(testUrl + `/${cropId}`);

      // Assert that the request is a GET.
      expect(req.request.method).toEqual('GET');

      // Respond with mock data, causing Observable to resolve.
      // Subscribe callback asserts that correct data was returned.
      req.flush(mockData);
    });
  });
});
