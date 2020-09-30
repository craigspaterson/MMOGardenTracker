import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';

import { CropService } from './crop.service';
import { Crop } from './crop';

import {
  faEdit,
  faEraser,
  faSortUp,
  faSortDown
} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-crops',
  templateUrl: './crops.component.html',
  styleUrls: ['./crops.component.css']
})
export class CropsComponent implements OnInit, OnDestroy {
  public errorMessage: string;
  public crops: Crop[];

  faEdit = faEdit;
  faEraser = faEraser;
  faSortUp = faSortUp;
  faSortDown = faSortDown;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private cropService: CropService
  ) {}

  private cropsSubscription: Subscription;

  ngOnInit() {
    this.getCrops();
  }

  ngOnDestroy() {
    this.cropsSubscription.unsubscribe();
  }

  getCrops(): void {
    this.cropsSubscription = this.cropService
      .getCrops()
      .subscribe(
        response => (this.crops = response),
        error => (this.errorMessage = <any>error)
      );
  }

  onEditClick(cropId: number): void {
    this.router.navigate([`/crops/crop/${cropId}`]);
  }

  onDeleteClick(cropId: number): void {}

  onAscendingSortClick(cropId: number): void {}

  onDescendingSortClick(cropId: number): void {}
}
