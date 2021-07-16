import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { DepotEditComponent } from './depot-edit/depot-edit.component';
import { DepotListComponent } from './depot-list/depot-list.component';
import { AuthAdminGuard } from './guards/admin-auth.service';
import { AuthGuard } from './guards/auth-guard.service';
import { NewDepotComponent } from './new-depot/new-depot.component';
import { NewOrderComponent } from './new-order/new-order.component';
import { NewVehicleComponent } from './new-vehicle/new-vehicle.component';
import { OrderEditComponent } from './order-edit/order-edit.component';
import { OrderListComponent } from './order-list/order-list.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { UserSettingsComponent } from './user-settings/user-settings.component';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';

const routes: Routes = [
  {
    path: 'admin/depot',
    component: DepotListComponent, canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/depot/new',
    component: NewDepotComponent , canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/depot/edit/:id',
    component: DepotEditComponent, canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/vehicle',
    component: VehicleListComponent , canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/vehicle/new',
    component: NewVehicleComponent , canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/vehicle/edit/:id',
    component: VehicleEditComponent , canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/order',
    component: OrderListComponent , canActivate:[AuthAdminGuard]
  },
  {
    path: 'admin/order/edit/:id',
    component: OrderEditComponent, canActivate:[AuthAdminGuard]
  },
  {
    path: 'customer/order/new',
    component: NewOrderComponent, canActivate:[AuthGuard]
  },
  {
    path: 'customer',
    component: UserHomeComponent , canActivate:[AuthGuard]
  },
  {
    path: 'admin',
    component: AdminHomeComponent , canActivate:[AuthAdminGuard]
  },
  {
    path: 'customer/user/:id',
    component: UserSettingsComponent, canActivate:[AuthGuard]
  },
  {
    path: 'login',
    component: UserLoginComponent
  },
  {
    path: 'registration',
    component: UserRegistrationComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
