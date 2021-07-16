import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { LogisticApiService } from './logistic-api.service';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { NewDepotComponent } from './new-depot/new-depot.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { NewVehicleComponent } from './new-vehicle/new-vehicle.component';
import { OrderListComponent } from './order-list/order-list.component';
import { NewOrderComponent } from './new-order/new-order.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';
import { DepotEditComponent } from './depot-edit/depot-edit.component';
import { OrderEditComponent } from './order-edit/order-edit.component';
import { DepotListComponent } from './depot-list/depot-list.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { JwtModule } from "@auth0/angular-jwt";
import { AuthGuard } from './guards/auth-guard.service';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { AuthAdminGuard } from './guards/admin-auth.service';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    DepotListComponent,
    NewDepotComponent,
    VehicleListComponent,
    NewVehicleComponent,
    OrderListComponent,
    NewOrderComponent,
    UserHomeComponent,
    AdminHomeComponent,
    VehicleEditComponent,
    DepotEditComponent,
    OrderEditComponent,
    UserSettingsComponent,
    UserLoginComponent,
    UserRegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule ,
    DlDateTimeDateModule,
    DlDateTimePickerModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:44376"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [
    AuthAdminGuard,
    AuthGuard,
    LogisticApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
