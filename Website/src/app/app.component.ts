import { Component } from '@angular/core';

import { faCoffee, faLeaf, faEdit } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Garden Tracker';
  faCoffee = faCoffee;
  faLeaf = faLeaf;
  faEdit = faEdit;
}
