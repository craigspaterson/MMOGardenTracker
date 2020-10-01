(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app-bootstrap/app-bootstrap.module.ts":
/*!*******************************************************!*\
  !*** ./src/app/app-bootstrap/app-bootstrap.module.ts ***!
  \*******************************************************/
/*! exports provided: AppBootstrapModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppBootstrapModule", function() { return AppBootstrapModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm2015/common.js");
/* harmony import */ var ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ngx-bootstrap/dropdown */ "./node_modules/ngx-bootstrap/dropdown/index.js");
/* harmony import */ var ngx_bootstrap_tooltip__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ngx-bootstrap/tooltip */ "./node_modules/ngx-bootstrap/tooltip/index.js");
/* harmony import */ var ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ngx-bootstrap/modal */ "./node_modules/ngx-bootstrap/modal/index.js");
/* harmony import */ var ngx_bootstrap_datepicker__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ngx-bootstrap/datepicker */ "./node_modules/ngx-bootstrap/datepicker/index.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};






// Add BootStrap modules as needed
let AppBootstrapModule = class AppBootstrapModule {
};
AppBootstrapModule = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
        imports: [
            _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
            ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_2__["BsDropdownModule"].forRoot(),
            ngx_bootstrap_tooltip__WEBPACK_IMPORTED_MODULE_3__["TooltipModule"].forRoot(),
            ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_4__["ModalModule"].forRoot(),
            ngx_bootstrap_datepicker__WEBPACK_IMPORTED_MODULE_5__["BsDatepickerModule"].forRoot()
        ],
        exports: [ngx_bootstrap_dropdown__WEBPACK_IMPORTED_MODULE_2__["BsDropdownModule"], ngx_bootstrap_tooltip__WEBPACK_IMPORTED_MODULE_3__["TooltipModule"], ngx_bootstrap_modal__WEBPACK_IMPORTED_MODULE_4__["ModalModule"], ngx_bootstrap_datepicker__WEBPACK_IMPORTED_MODULE_5__["BsDatepickerModule"]],
        declarations: []
    })
], AppBootstrapModule);



/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./dashboard/dashboard.component */ "./src/app/dashboard/dashboard.component.ts");
/* harmony import */ var _gardens_gardens_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./gardens/gardens.component */ "./src/app/gardens/gardens.component.ts");
/* harmony import */ var _gardens_garden_detail_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./gardens/garden-detail.component */ "./src/app/gardens/garden-detail.component.ts");
/* harmony import */ var _crops_crops_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./crops/crops.component */ "./src/app/crops/crops.component.ts");
/* harmony import */ var _crops_crop_detail_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./crops/crop-detail.component */ "./src/app/crops/crop-detail.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};







const routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'dashboard', component: _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_2__["DashboardComponent"] },
    { path: 'gardens', component: _gardens_gardens_component__WEBPACK_IMPORTED_MODULE_3__["GardensComponent"] },
    { path: 'gardens/garden/:id', component: _gardens_garden_detail_component__WEBPACK_IMPORTED_MODULE_4__["GardenDetailComponent"] },
    { path: 'crops', component: _crops_crops_component__WEBPACK_IMPORTED_MODULE_5__["CropsComponent"] },
    { path: 'crops/crop/:id', component: _crops_crop_detail_component__WEBPACK_IMPORTED_MODULE_6__["CropDetailComponent"] },
    { path: 'crops/crop/new', component: _crops_crop_detail_component__WEBPACK_IMPORTED_MODULE_6__["CropDetailComponent"] }
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
        imports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"].forRoot(routes)],
        exports: [_angular_router__WEBPACK_IMPORTED_MODULE_1__["RouterModule"]]
    })
], AppRoutingModule);



/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"jumbotron jumbotron-fluid\">\r\n  <div class=\"container\">\r\n    <h1 class=\"display-4\">{{title}}</h1>\r\n    <p class=\"lead\">Track all of your gardens, crops, and activities with {{title}}.</p>\r\n  </div>\r\n</div>\r\n<nav class=\"navbar navbar-expand-lg navbar-dark bg-dark\">\r\n  <a class=\"navbar-brand\" href=\"#\">\r\n    <fa-icon [icon]=\"faLeaf\" style=\"color:lime\"></fa-icon> </a>\r\n  <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#navbarNavAltMarkup\" aria-controls=\"navbarNavAltMarkup\"\r\n    aria-expanded=\"false\" aria-label=\"Toggle navigation\">\r\n    <span class=\"navbar-toggler-icon\"></span>\r\n  </button>\r\n  <div class=\"collapse navbar-collapse\" id=\"navbarNavAltMarkup\">\r\n    <div class=\"navbar-nav\">\r\n      <a class=\"nav-item nav-link active\" routerLink=\"/dashboard\">Dashboard\r\n        <span class=\"sr-only\">(current)</span>\r\n      </a>\r\n      <a class=\"nav-item nav-link\" routerLink=\"/gardens\">Gardens</a>\r\n      <a class=\"nav-item nav-link\" routerLink=\"/crops\">Crops</a>\r\n    </div>\r\n  </div>\r\n</nav>\r\n\r\n<!-- <div style=\"text-align:center\">\r\n  <fa-icon [icon]=\"faCoffee\"></fa-icon>\r\n</div> -->\r\n\r\n<div class=\"container-fluid\">\r\n  <div class=\"row\">\r\n    <div class=\"col-1\"></div>\r\n    <div class=\"col-11\">\r\n      <router-outlet></router-outlet>\r\n    </div>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @fortawesome/free-solid-svg-icons */ "./node_modules/@fortawesome/free-solid-svg-icons/index.es.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};


let AppComponent = class AppComponent {
    constructor() {
        this.title = 'Garden Tracker';
        this.faCoffee = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_1__["faCoffee"];
        this.faLeaf = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_1__["faLeaf"];
        this.faEdit = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_1__["faEdit"];
    }
};
AppComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'app-root',
        template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
        styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
    })
], AppComponent);



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm2015/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm2015/forms.js");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var _app_bootstrap_app_bootstrap_module__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./app-bootstrap/app-bootstrap.module */ "./src/app/app-bootstrap/app-bootstrap.module.ts");
/* harmony import */ var _fortawesome_angular_fontawesome__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @fortawesome/angular-fontawesome */ "./node_modules/@fortawesome/angular-fontawesome/fesm2015/angular-fontawesome.js");
/* harmony import */ var _crops_crops_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./crops/crops.component */ "./src/app/crops/crops.component.ts");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./dashboard/dashboard.component */ "./src/app/dashboard/dashboard.component.ts");
/* harmony import */ var _gardens_gardens_component__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./gardens/gardens.component */ "./src/app/gardens/gardens.component.ts");
/* harmony import */ var _crops_crop_detail_component__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./crops/crop-detail.component */ "./src/app/crops/crop-detail.component.ts");
/* harmony import */ var _gardens_garden_detail_component__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./gardens/garden-detail.component */ "./src/app/gardens/garden-detail.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};













let AppModule = class AppModule {
};
AppModule = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
        declarations: [
            _app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"],
            _crops_crops_component__WEBPACK_IMPORTED_MODULE_7__["CropsComponent"],
            _dashboard_dashboard_component__WEBPACK_IMPORTED_MODULE_9__["DashboardComponent"],
            _gardens_gardens_component__WEBPACK_IMPORTED_MODULE_10__["GardensComponent"],
            _crops_crop_detail_component__WEBPACK_IMPORTED_MODULE_11__["CropDetailComponent"],
            _gardens_garden_detail_component__WEBPACK_IMPORTED_MODULE_12__["GardenDetailComponent"]
        ],
        imports: [
            _angular_platform_browser__WEBPACK_IMPORTED_MODULE_0__["BrowserModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_2__["FormsModule"],
            _angular_forms__WEBPACK_IMPORTED_MODULE_2__["ReactiveFormsModule"],
            _angular_common_http__WEBPACK_IMPORTED_MODULE_4__["HttpClientModule"],
            _app_routing_module__WEBPACK_IMPORTED_MODULE_8__["AppRoutingModule"],
            _app_bootstrap_app_bootstrap_module__WEBPACK_IMPORTED_MODULE_5__["AppBootstrapModule"],
            _fortawesome_angular_fontawesome__WEBPACK_IMPORTED_MODULE_6__["FontAwesomeModule"],
        ],
        providers: [],
        bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_3__["AppComponent"]]
    })
], AppModule);



/***/ }),

/***/ "./src/app/crops/crop-detail.component.css":
/*!*************************************************!*\
  !*** ./src/app/crops/crop-detail.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/crops/crop-detail.component.html":
/*!**************************************************!*\
  !*** ./src/app/crops/crop-detail.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n  <div class=\"col-md-8\">\r\n    <!-- <div *ngIf=\"crop as crop; else loading\"> -->\r\n    <form #f=\"ngForm\" (ngSubmit)=\"saveCrop(f.value)\">\r\n      <div class=\"form-group\">\r\n        <label for=\"gardenId\">Garden</label>\r\n        <select id=\"gardenId\" name=\"gardenId\" #gardenId=\"ngModel\" [(ngModel)]=\"crop.gardenId\">\r\n          <option value=\"\"></option>\r\n          <option *ngFor=\"let garden of gardens\" [value]=\"garden.gardenId\">\r\n            {{garden.gardenName}}\r\n          </option>\r\n        </select>\r\n      </div>\r\n      <div class=\"form-group\">\r\n        <label for=\"cropId\">Crop Id</label>\r\n        <input id=\"cropId\" name=\"cropId\" type=\"text\" class=\"form-control\" #cropId=\"ngModel\" [(ngModel)]=\"crop.cropId\" placeholder=\"Crop Id\"\r\n          readonly>\r\n      </div>\r\n      <div class=\"form-group\">\r\n        <label for=\"cropName\">Crop Name</label>\r\n        <input id=\"cropName\" name=\"cropName\" type=\"text\" class=\"form-control\" #cropName=\"ngModel\" [(ngModel)]=\"crop.cropName\" placeholder=\"Crop Name\"\r\n          required>\r\n      </div>\r\n      <div class=\"form-group\">\r\n        <label for=\"plantName\">Plant Name</label>\r\n        <input id=\"plantName\" name=\"plantName\" type=\"text\" class=\"form-control\" #plantName=\"ngModel\" [(ngModel)]=\"crop.plantName\"\r\n          placeholder=\"Plant Name\" required>\r\n      </div>\r\n      <div class=\"form-group\">\r\n        <label for=\"beginDate\">Begin Date</label>\r\n        <input id=\"beginDate\" name=\"beginDate\" type=\"text\" placeholder=\"Datepicker\" class=\"form-control\" #beginDate=\"ngModel\" [(ngModel)]=\"crop.beginDate\"\r\n          bsDatepicker required>\r\n      </div>\r\n      <div class=\"form-group\">\r\n        <label for=\"endDate\">End Date</label>\r\n        <input id=\"endDate\" name=\"endDate\" type=\"text\" placeholder=\"Datepicker\" class=\"form-control\" #endDate=\"ngModel\" [(ngModel)]=\"crop.endDate\"\r\n          bsDatepicker>\r\n      </div>\r\n      <div class=\"form-group\">\r\n        <label for=\"notes\">Notes</label>\r\n        <input id=\"notes\" name=\"notes\" type=\"text\" class=\"form-control\" #notes=\"ngModel\" [(ngModel)]=\"crop.notes\">\r\n      </div>\r\n\r\n      <!-- cropActivities: CropActivity[]; -->\r\n      <button class=\"btn btn-primary\" id=\"submit\" name=\"submit\" type=\"submit\" value=\"Submit\">Submit</button>&nbsp;\r\n      <button class=\"btn btn-secondary\" type=\"button\" (click)=\"gotoCrops()\">Back</button>\r\n\r\n    </form>\r\n    <!-- </div> -->\r\n\r\n    <ng-template #loading>\r\n      Loading...\r\n    </ng-template>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "./src/app/crops/crop-detail.component.ts":
/*!************************************************!*\
  !*** ./src/app/crops/crop-detail.component.ts ***!
  \************************************************/
/*! exports provided: CropDetailComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CropDetailComponent", function() { return CropDetailComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _crop_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./crop.service */ "./src/app/crops/crop.service.ts");
/* harmony import */ var _gardens_garden_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../gardens/garden.service */ "./src/app/gardens/garden.service.ts");
/* harmony import */ var _crop__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./crop */ "./src/app/crops/crop.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





let CropDetailComponent = class CropDetailComponent {
    constructor(route, router, cropService, gardenService) {
        this.route = route;
        this.router = router;
        this.cropService = cropService;
        this.gardenService = gardenService;
    }
    ngOnInit() {
        this.cropId = +this.route.snapshot.paramMap.get('id');
        this.getGardens();
        if (this.cropId) {
            this.getCrop(this.cropId);
        }
        else {
            this.crop = new _crop__WEBPACK_IMPORTED_MODULE_4__["Crop"]();
        }
    }
    getGardens() {
        this.gardenService
            .getGardens()
            .subscribe(response => (this.gardens = response), error => (this.errorMessage = error));
    }
    getCrop(cropId) {
        this.cropService
            .getCropByCropId(cropId)
            .subscribe(response => (this.crop = response), error => (this.errorMessage = error));
    }
    addCrop(crop) {
        this.cropService
            .postCrop(crop)
            .subscribe(response => (this.crop = response), error => (this.errorMessage = error));
    }
    updateCrop(cropId, crop) {
        this.cropService
            .putCrop(cropId, crop)
            .subscribe(response => (this.crop = response), error => (this.errorMessage = error));
    }
    saveCrop(crop) {
        // console.log(crop);
        if (crop) {
            // TODO: Remove after replacing in memory db
            // crop.cropId = crop.cropId;
        }
        if (this.cropId) {
            this.updateCrop(this.cropId, crop);
        }
        else {
            this.addCrop(crop);
        }
        this.router.navigate([`/crops`]);
    }
    gotoCrops() {
        this.router.navigate([`/crops`]);
    }
};
CropDetailComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'app-crop-detail',
        template: __webpack_require__(/*! ./crop-detail.component.html */ "./src/app/crops/crop-detail.component.html"),
        styles: [__webpack_require__(/*! ./crop-detail.component.css */ "./src/app/crops/crop-detail.component.css")]
    }),
    __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
        _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
        _crop_service__WEBPACK_IMPORTED_MODULE_2__["CropService"],
        _gardens_garden_service__WEBPACK_IMPORTED_MODULE_3__["GardenService"]])
], CropDetailComponent);



/***/ }),

/***/ "./src/app/crops/crop.service.ts":
/*!***************************************!*\
  !*** ./src/app/crops/crop.service.ts ***!
  \***************************************/
/*! exports provided: CropService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CropService", function() { return CropService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm2015/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../environments/environment */ "./src/environments/environment.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





const httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'Content-Type': 'application/json' }),
    params: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpParams"]({})
};
let CropService = class CropService {
    constructor(http) {
        this.http = http;
        // private url = 'api/crops';
        this.url = _environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].gardenTrackerServiceUrl + 'api/crops';
    }
    getCrops() {
        return this.http
            .get(this.url, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    getCropByCropId(cropId) {
        return this.http
            .get(this.url + `/${cropId}`, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    postCrop(crop) {
        return this.http
            .post(this.url, crop, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    putCrop(cropId, crop) {
        return this.http
            .put(this.url + `/${cropId}`, crop, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    deleteCrop(cropId) {
        return this.http
            .delete(this.url + `/${cropId}`, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    handleError(error) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])('Something bad happened; please try again later.');
    }
};
CropService = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
        providedIn: 'root'
    }),
    __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
], CropService);



/***/ }),

/***/ "./src/app/crops/crop.ts":
/*!*******************************!*\
  !*** ./src/app/crops/crop.ts ***!
  \*******************************/
/*! exports provided: Crop */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Crop", function() { return Crop; });
class Crop {
}


/***/ }),

/***/ "./src/app/crops/crops.component.css":
/*!*******************************************!*\
  !*** ./src/app/crops/crops.component.css ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/crops/crops.component.html":
/*!********************************************!*\
  !*** ./src/app/crops/crops.component.html ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n  <div class=\"col-md-8\">\r\n    <p>\r\n      <a routerLink=\"/crops/crop/new\" class=\"btn btn-primary\">Add Crop</a>\r\n    </p>\r\n\r\n    <ng-container *ngIf=\"crops && crops.length; then hasDataTemplate; else noDataTemplate\">\r\n    </ng-container>\r\n\r\n    <ng-template #hasDataTemplate>\r\n      <div>\r\n        <table class=\"table table-bordered thread-dark\">\r\n          <thead>\r\n            <tr>\r\n              <th>Action</th>\r\n              <th>Crop Name</th>\r\n              <th>Plant Name</th>\r\n              <th>Begin Date</th>\r\n              <th>End Date</th>\r\n            </tr>\r\n          </thead>\r\n          <tr *ngFor=\"let crop of crops; let loopIndex = index\">\r\n            <td style=\"text-align:top; padding:0; margin:0; cursor:pointer; width: 80px;\">\r\n              <fa-icon [icon]=\"faEdit\" style=\"color:black\" (click)=\"onEditClick(crop.cropId)\"></fa-icon>&nbsp;\r\n              <fa-icon [icon]=\"faEraser\" style=\"color:black\" (click)=\"onDeleteClick(crop.cropId)\"></fa-icon>&nbsp;\r\n              <!-- <fa-icon [icon]=\"faSortUp\" style=\"color:black\" (click)=\"onAscendingSortClick(crop.cropId)\"></fa-icon>&nbsp; -->\r\n              <!-- <fa-icon [icon]=\"faSortDown\" style=\"color:black\" (click)=\"onDescendingSortClick(crop.cropId)\"></fa-icon> -->\r\n            </td>\r\n            <td>\r\n              {{crop.cropName}}\r\n            </td>\r\n            <td>\r\n              {{crop.plantName}}\r\n            </td>\r\n            <td>\r\n              {{crop.beginDate | date:'shortDate'}}\r\n            </td>\r\n            <td>\r\n              {{crop.endDate | date:'shortDate'}}\r\n            </td>\r\n          </tr>\r\n        </table>\r\n      </div>\r\n    </ng-template>\r\n\r\n    <ng-template #noDataTemplate>\r\n      <div>\r\n        Loading...\r\n      </div>\r\n    </ng-template>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "./src/app/crops/crops.component.ts":
/*!******************************************!*\
  !*** ./src/app/crops/crops.component.ts ***!
  \******************************************/
/*! exports provided: CropsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CropsComponent", function() { return CropsComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _crop_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./crop.service */ "./src/app/crops/crop.service.ts");
/* harmony import */ var _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @fortawesome/free-solid-svg-icons */ "./node_modules/@fortawesome/free-solid-svg-icons/index.es.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




let CropsComponent = class CropsComponent {
    constructor(route, router, cropService) {
        this.route = route;
        this.router = router;
        this.cropService = cropService;
        this.faEdit = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faEdit"];
        this.faEraser = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faEraser"];
        this.faSortUp = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faSortUp"];
        this.faSortDown = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faSortDown"];
    }
    ngOnInit() {
        this.getCrops();
    }
    ngOnDestroy() {
        this.cropsSubscription.unsubscribe();
    }
    getCrops() {
        this.cropsSubscription = this.cropService
            .getCrops()
            .subscribe(response => (this.crops = response), error => (this.errorMessage = error));
    }
    onEditClick(cropId) {
        this.router.navigate([`/crops/crop/${cropId}`]);
    }
    onDeleteClick(cropId) { }
    onAscendingSortClick(cropId) { }
    onDescendingSortClick(cropId) { }
};
CropsComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'app-crops',
        template: __webpack_require__(/*! ./crops.component.html */ "./src/app/crops/crops.component.html"),
        styles: [__webpack_require__(/*! ./crops.component.css */ "./src/app/crops/crops.component.css")]
    }),
    __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
        _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
        _crop_service__WEBPACK_IMPORTED_MODULE_2__["CropService"]])
], CropsComponent);



/***/ }),

/***/ "./src/app/dashboard/dashboard.component.css":
/*!***************************************************!*\
  !*** ./src/app/dashboard/dashboard.component.css ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/dashboard/dashboard.component.html":
/*!****************************************************!*\
  !*** ./src/app/dashboard/dashboard.component.html ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <h2>Dashboard</h2>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "./src/app/dashboard/dashboard.component.ts":
/*!**************************************************!*\
  !*** ./src/app/dashboard/dashboard.component.ts ***!
  \**************************************************/
/*! exports provided: DashboardComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DashboardComponent", function() { return DashboardComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

let DashboardComponent = class DashboardComponent {
    constructor() { }
    ngOnInit() {
    }
};
DashboardComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'app-dashboard',
        template: __webpack_require__(/*! ./dashboard.component.html */ "./src/app/dashboard/dashboard.component.html"),
        styles: [__webpack_require__(/*! ./dashboard.component.css */ "./src/app/dashboard/dashboard.component.css")]
    }),
    __metadata("design:paramtypes", [])
], DashboardComponent);



/***/ }),

/***/ "./src/app/gardens/garden-detail.component.css":
/*!*****************************************************!*\
  !*** ./src/app/gardens/garden-detail.component.css ***!
  \*****************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/gardens/garden-detail.component.html":
/*!******************************************************!*\
  !*** ./src/app/gardens/garden-detail.component.html ***!
  \******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n  <div class=\"col-md-8\">\r\n    <div *ngIf=\"garden as garden; else loading\">\r\n      <div>\r\n        <span>Garden Id: </span>{{garden.gardenId}}</div>\r\n      <div>\r\n        <label>Garden Name:\r\n          <input [(ngModel)]=\"garden.gardenName\" placeholder=\"Garden Name\">\r\n        </label>\r\n      </div>\r\n      <p>\r\n        <button class=\"btn btn-secondary\" type=\"button\" (click)=\"gotoGardens()\">Back</button>\r\n      </p>\r\n    </div>\r\n\r\n    <ng-template #loading>\r\n      Loading...\r\n    </ng-template>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "./src/app/gardens/garden-detail.component.ts":
/*!****************************************************!*\
  !*** ./src/app/gardens/garden-detail.component.ts ***!
  \****************************************************/
/*! exports provided: GardenDetailComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GardenDetailComponent", function() { return GardenDetailComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _garden_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./garden.service */ "./src/app/gardens/garden.service.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};



let GardenDetailComponent = class GardenDetailComponent {
    constructor(route, router, gardenService) {
        this.route = route;
        this.router = router;
        this.gardenService = gardenService;
    }
    ngOnInit() {
        const gardenId = +this.route.snapshot.paramMap.get('id');
        this.getGarden(gardenId);
    }
    getGarden(gardenId) {
        this.gardenService
            .getGardenByGardenId(gardenId)
            .subscribe(response => (this.garden = response), error => (this.errorMessage = error));
    }
    gotoGardens() {
        this.router.navigate([`/gardens`]);
    }
};
GardenDetailComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'app-garden-detail',
        template: __webpack_require__(/*! ./garden-detail.component.html */ "./src/app/gardens/garden-detail.component.html"),
        styles: [__webpack_require__(/*! ./garden-detail.component.css */ "./src/app/gardens/garden-detail.component.css")]
    }),
    __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
        _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
        _garden_service__WEBPACK_IMPORTED_MODULE_2__["GardenService"]])
], GardenDetailComponent);



/***/ }),

/***/ "./src/app/gardens/garden.service.ts":
/*!*******************************************!*\
  !*** ./src/app/gardens/garden.service.ts ***!
  \*******************************************/
/*! exports provided: GardenService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GardenService", function() { return GardenService; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm2015/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm2015/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm2015/operators/index.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../environments/environment */ "./src/environments/environment.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};





const httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpHeaders"]({ 'Content-Type': 'application/json' })
};
let GardenService = class GardenService {
    constructor(http) {
        this.http = http;
        // private url = 'api/gardens';
        this.url = _environments_environment__WEBPACK_IMPORTED_MODULE_4__["environment"].gardenTrackerServiceUrl + 'api/gardens';
    }
    getGardens() {
        return this.http
            .get(this.url, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    getGardenByGardenId(gardenId) {
        return this.http
            .get(this.url + `/${gardenId}`, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(this.handleError));
    }
    handleError(error) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        }
        else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(`Backend returned code ${error.status}, ` + `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])('Something bad happened; please try again later.');
    }
};
GardenService = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Injectable"])({
        providedIn: 'root'
    }),
    __metadata("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_1__["HttpClient"]])
], GardenService);



/***/ }),

/***/ "./src/app/gardens/gardens.component.css":
/*!***********************************************!*\
  !*** ./src/app/gardens/gardens.component.css ***!
  \***********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/gardens/gardens.component.html":
/*!************************************************!*\
  !*** ./src/app/gardens/gardens.component.html ***!
  \************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"row\">\r\n  <div class=\"col-md-8\">\r\n    <ng-container *ngIf=\"gardens && gardens.length; then hasDataTemplate; else noDataTemplate\">\r\n    </ng-container>\r\n\r\n    <ng-template #hasDataTemplate>\r\n      <div>\r\n        <table class=\"table table-bordered thread-dark\">\r\n          <thead>\r\n            <tr>\r\n              <th>Action</th>\r\n              <th>Garden Name</th>\r\n            </tr>\r\n          </thead>\r\n          <tr *ngFor=\"let garden of gardens; let loopIndex = index\">\r\n            <td style=\"text-align:top; padding:0; margin:0; cursor:pointer; width: 80px;\">\r\n              <fa-icon [icon]=\"faEdit\" style=\"color:black\" (click)=\"onEditClick(garden.gardenId)\"></fa-icon>&nbsp;\r\n              <fa-icon [icon]=\"faEraser\" style=\"color:black\" (click)=\"onDeleteClick(garden.gardenId)\"></fa-icon>&nbsp;\r\n              <!-- <fa-icon [icon]=\"faSortUp\" style=\"color:black\" (click)=\"onAscendingSortClick(garden.gardenId)\"></fa-icon>&nbsp; -->\r\n              <!-- <fa-icon [icon]=\"faSortDown\" style=\"color:black\" (click)=\"onDescendingSortClick(garden.gardenId)\"></fa-icon> -->\r\n            </td>\r\n            <td>\r\n              {{garden.gardenName}}\r\n            </td>\r\n          </tr>\r\n        </table>\r\n      </div>\r\n    </ng-template>\r\n\r\n    <ng-template #noDataTemplate>\r\n      <div>\r\n        Loading...\r\n      </div>\r\n    </ng-template>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "./src/app/gardens/gardens.component.ts":
/*!**********************************************!*\
  !*** ./src/app/gardens/gardens.component.ts ***!
  \**********************************************/
/*! exports provided: GardensComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "GardensComponent", function() { return GardensComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm2015/router.js");
/* harmony import */ var _garden_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./garden.service */ "./src/app/gardens/garden.service.ts");
/* harmony import */ var _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @fortawesome/free-solid-svg-icons */ "./node_modules/@fortawesome/free-solid-svg-icons/index.es.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




let GardensComponent = class GardensComponent {
    constructor(route, router, gardenService) {
        this.route = route;
        this.router = router;
        this.gardenService = gardenService;
        this.faEdit = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faEdit"];
        this.faEraser = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faEraser"];
        this.faSortUp = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faSortUp"];
        this.faSortDown = _fortawesome_free_solid_svg_icons__WEBPACK_IMPORTED_MODULE_3__["faSortDown"];
    }
    ngOnInit() {
        this.getGardens();
    }
    getGardens() {
        this.gardenService
            .getGardens()
            .subscribe(response => (this.gardens = response), error => (this.errorMessage = error));
    }
    onEditClick(gardenId) {
        this.router.navigate([`/gardens/garden/${gardenId}`]);
    }
    onDeleteClick(gardenId) { }
    onAscendingSortClick(gardenId) { }
    onDescendingSortClick(gardenId) { }
};
GardensComponent = __decorate([
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
        selector: 'app-gardens',
        template: __webpack_require__(/*! ./gardens.component.html */ "./src/app/gardens/gardens.component.html"),
        styles: [__webpack_require__(/*! ./gardens.component.css */ "./src/app/gardens/gardens.component.css")]
    }),
    __metadata("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_1__["ActivatedRoute"],
        _angular_router__WEBPACK_IMPORTED_MODULE_1__["Router"],
        _garden_service__WEBPACK_IMPORTED_MODULE_2__["GardenService"]])
], GardensComponent);



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
const environment = {
    production: false,
    gardenTrackerServiceUrl: 'https://localhost:44374/'
};
// "applicationUrl": "http://localhost:64015",
// "sslPort": 44374
/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm2015/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm2015/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(err => console.log(err));


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\Projects\Workspace\Magenic\MMO\GardenTracker\Website\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map