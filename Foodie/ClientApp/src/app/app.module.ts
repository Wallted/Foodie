import { BrowserModule, HAMMER_GESTURE_CONFIG, HammerGestureConfig } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ProductsComponent } from './products/products.component';
import { MealCalendarComponent } from './meal-calendar/meal-calendar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { IngriedientDialogComponent } from './ingriedient-dialog/ingriedient-dialog.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { CountoModule } from 'angular2-counto';
import { DataComponent } from './data/data.component';
import * as Hammer from 'hammerjs';
import { StartingComponent } from './starting/starting.component';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { MatIconModule } from '@angular/material/icon';

export class MyHammerConfig extends HammerGestureConfig {
  overrides = <any>{
    swipe: { direction: Hammer.DIRECTION_HORIZONTAL, touchAction: 'auto' },
    pinch: { enable: false },
    rotate: { enable: false },
    pan: { enable: false }
  };
}


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductsComponent,
    MealCalendarComponent,
    IngriedientDialogComponent,
    DataComponent,
    StartingComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: 'products', component: ProductsComponent, canActivate: [AuthorizeGuard] },
      { path: 'home', component: HomeComponent, canActivate: [AuthorizeGuard] },
      { path: "mealcalendar", component: MealCalendarComponent, canActivate: [AuthorizeGuard] },
      { path: 'data', component: DataComponent, canActivate: [AuthorizeGuard] },
      { path: '', component: StartingComponent},
    ]),
    BrowserAnimationsModule,
    MatButtonModule,
    MatExpansionModule,
    MatTableModule,
    MatInputModule,
    MatDialogModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    MatTooltipModule,
    MatProgressBarModule,
    CountoModule,
    MatIconModule
  ],
  entryComponents: [
    IngriedientDialogComponent
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: HAMMER_GESTURE_CONFIG, useClass: MyHammerConfig, },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
