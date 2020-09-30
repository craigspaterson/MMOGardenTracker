import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CropService } from './crop.service';
import { GardenService } from '../gardens/garden.service';
import { Crop } from './crop';
import { Garden } from '../gardens/garden';

@Component({
  selector: 'app-crop-detail',
  templateUrl: './crop-detail.component.html',
  styleUrls: ['./crop-detail.component.css']
})
export class CropDetailComponent implements OnInit {
  public errorMessage: string;
  public crop: Crop;
  public gardens: Garden[];
  cropId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cropService: CropService,
    private gardenService: GardenService
  ) {}

  ngOnInit() {
    this.cropId = +this.route.snapshot.paramMap.get('id');

    this.getGardens();

    if (this.cropId) {
      this.getCrop(this.cropId);
    } else {
      this.crop = new Crop();
    }
  }

  private getGardens(): void {
    this.gardenService
      .getGardens()
      .subscribe(
        response => (this.gardens = response),
        error => (this.errorMessage = <any>error)
      );
  }

  private getCrop(cropId: number): void {
    this.cropService
      .getCropByCropId(cropId)
      .subscribe(
        response => (this.crop = response),
        error => (this.errorMessage = <any>error)
      );
  }

  private addCrop(crop: Crop): void {
    this.cropService
      .postCrop(crop)
      .subscribe(
        response => (this.crop = response),
        error => (this.errorMessage = <any>error)
      );
  }

  private updateCrop(cropId: number, crop: Crop): void {
    this.cropService
      .putCrop(cropId, crop)
      .subscribe(
        response => (this.crop = response),
        error => (this.errorMessage = <any>error)
      );
  }

  private saveCrop(crop: Crop): void {
    // console.log(crop);

    if (crop) {
      // TODO: Remove after replacing in memory db
      // crop.cropId = crop.cropId;
    }

    if (this.cropId) {
      this.updateCrop(this.cropId, crop);
    } else {
      this.addCrop(crop);
    }

    this.router.navigate([`/crops`]);
  }

  gotoCrops(): void {
    this.router.navigate([`/crops`]);
  }
}
