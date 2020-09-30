import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { GardenService } from './garden.service';
import { Garden } from './garden';

@Component({
  selector: 'app-garden-detail',
  templateUrl: './garden-detail.component.html',
  styleUrls: ['./garden-detail.component.css']
})
export class GardenDetailComponent implements OnInit {
  public errorMessage: string;
  public garden: Garden;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private gardenService: GardenService
  ) {}

  ngOnInit() {
    const gardenId = +this.route.snapshot.paramMap.get('id');

    this.getGarden(gardenId);
  }

  private getGarden(gardenId: number): void {
    this.gardenService
      .getGardenByGardenId(gardenId)
      .subscribe(
        response => (this.garden = response),
        error => (this.errorMessage = <any>error)
      );
  }

  gotoGardens(): void {
    this.router.navigate([`/gardens`]);
  }
}
