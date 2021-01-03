import { TestBed, inject } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { GardenService } from './garden.service';
import { Garden } from './garden';
import { Crop } from '../crops/crop';

describe('GardenService', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: GardenService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [GardenService]
    });

    // Inject the http service and test controller for each test
    httpClient = TestBed.inject(HttpClient);
    httpTestingController = TestBed.inject(HttpTestingController);

    service = TestBed.inject(GardenService);
  });

  // Tear Down each test
  afterEach(() => {
    // Calling verify ensures that none of the HTTP requests are outstanding, tests with
    // open requests will fail
    httpTestingController.verify();
  });

  it('should be created', inject([GardenService], (service: GardenService) => {
    expect(service).toBeTruthy();
  }));

  // Initialization
  describe('initialization', () => {
    it('should be created', () => {
      expect(service).toBeDefined();
    });

    it('has 2 methods', () => {
      expect(service.getGardens).toBeDefined();
      expect(service.getGardenByGardenId).toBeDefined();
      // expect(service.postGarden).toBeDefined();
      // expect(service.putGarden).toBeDefined();
      // expect(service.deleteGarden).toBeDefined();
    });
  });

  describe('getGardens', () => {
    const testUrl = '/api/gardens';

    // Mock the response data
    const mockResponse: Garden = {
      gardenId: 1,
      gardenName: 'Garden 1',
      crops: Crop[0]
    };

    it('should make a GET request', () => {
      // Make an HTTP GET request
      httpClient.get<Garden>(testUrl).subscribe(data =>
        // When observable resolves, result should match mock data
        expect(data).toEqual(mockResponse)
      );

      // The following `expectOne()` will match the request's URL.
      // If no requests or multiple requests matched that URL
      // `expectOne()` would throw.
      const req = httpTestingController.expectOne(testUrl);

      // Assert that the request is a GET.
      expect(req.request.method).toEqual('GET');

      // Respond with mock data, causing Observable to resolve.
      // Subscribe callback asserts that correct data was returned.
      req.flush(mockResponse);
    });
  });

  describe('getGardenByGardenId', () => {
    // Arrange
    const testUrl = '/api/gardens/garden/';
    const gardenId = 1;

    // Mock the response data
    const mockResponse: Garden[] = [
      {
        gardenId: 1,
        gardenName: 'Garden 1',
        crops: Crop[0]
      }
    ];

    // Act
    it('should make a GET request', () => {
      // Make an HTTP GET request
      httpClient.get<Garden[]>(testUrl + `/${gardenId}`).subscribe(data => {
        expect(data).toEqual(mockResponse);
        expect(data[0].gardenId).toEqual(mockResponse[0].gardenId);
        expect(data[0].gardenId).toEqual(gardenId);
      });

      // The following `expectOne()` will match the request's URL.
      // If no requests or multiple requests matched that URL
      // `expectOne()` would throw.
      const req = httpTestingController.expectOne(testUrl + `/${gardenId}`);

      // Assert
      // Assert that the request is a GET.
      expect(req.request.method).toEqual('GET');

      // Respond with mock data, causing Observable to resolve.
      // Subscribe callback asserts that correct data was returned.
      req.flush(mockResponse);
    });

  });
});
