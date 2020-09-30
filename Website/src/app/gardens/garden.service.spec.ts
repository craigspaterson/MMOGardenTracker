import { TestBed, inject } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController
} from '@angular/common/http/testing';

import { GardenService } from './garden.service';

describe('GardenService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [GardenService]
    });
  });

  it('should be created', inject([GardenService], (service: GardenService) => {
    expect(service).toBeTruthy();
  }));
});
