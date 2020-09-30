import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { GardenService } from './garden.service';
import { Garden } from './garden';
import {
  faEdit,
  faEraser,
  faSortUp,
  faSortDown
} from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-gardens',
  templateUrl: './gardens.component.html',
  styleUrls: ['./gardens.component.css']
})
export class GardensComponent implements OnInit {
  public errorMessage: string;
  public gardens: Garden[];

  faEdit = faEdit;
  faEraser = faEraser;
  faSortUp = faSortUp;
  faSortDown = faSortDown;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private gardenService: GardenService
  ) {}

  ngOnInit() {
    this.getGardens();
  }

  getGardens(): void {
    this.gardenService
      .getGardens()
      .subscribe(
        response => (this.gardens = response),
        error => (this.errorMessage = <any>error)
      );
  }

  onEditClick(gardenId: number): void {
    this.router.navigate([`/gardens/garden/${gardenId}`]);
  }

  onDeleteClick(gardenId: number): void {}

  onAscendingSortClick(gardenId: number): void {}

  onDescendingSortClick(gardenId: number): void {}
}
