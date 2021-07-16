import { query } from '@angular/animations';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Depot, Order, OrderWithEmail, User, Vehicle } from './models';
import { VehicleEditComponent } from './vehicle-edit/vehicle-edit.component';


@Injectable({
  providedIn: 'root'
})
export class LogisticApiService {

  constructor(private http: HttpClient) { }

  public getUserByAsync(id:string): Promise<User> {
    return this.http.get<User>('https://localhost:44376/user/'+id).toPromise();
  }
  public updateUserAsync(user:User): Promise<any> {
    return this.http.put('https://localhost:44376/user/'+user.id, user).toPromise();
  }
  public createUserAsync(user:User): Promise<any> {

    return this.http.post('https://localhost:44376/user', user).toPromise();
  }
  public getDepotsAsync(): Promise<Depot[]> {
    return this.http.get<Depot[]>('https://localhost:44376/depot').toPromise();
  }
  public getDepotByIdAsync(id:string|undefined): Promise<Depot> {
    return this.http.get<Depot>('https://localhost:44376/depot/'+id).toPromise();
  }
  public createDepotsAsync(depot:Depot): Promise<any> {

    return this.http.post('https://localhost:44376/depot', depot).toPromise();
  }
  public updateDepotsAsync(depot: Depot): Promise<any> {

    return this.http.put('https://localhost:44376/depot/'+depot.id, depot).toPromise();
  }
  public getVehiclesAsync(): Promise<Vehicle[]> {
    return this.http.get<Vehicle[]>('https://localhost:44376/vehicle').toPromise();
  }
  public getVehicleByIdAsync(id:string|undefined): Promise<Vehicle> {
    return this.http.get<Vehicle>('https://localhost:44376/vehicle/'+id).toPromise();
  }
  public updateVehicleAsync(vehicle:Vehicle): Promise<any> {
    return this.http.put('https://localhost:44376/vehicle/'+vehicle.id, vehicle).toPromise();
  }

  public createVehicleAsync(vehicle:Vehicle): Promise<any> {

    return this.http.post('https://localhost:44376/vehicle', vehicle).toPromise();
  }
  public getOrderAsync(date: Date): Promise<OrderWithEmail[]> {
    return this.http.get<OrderWithEmail[]>('https://localhost:44376/order/date', {params:new HttpParams().append(
      'date',date.toLocaleDateString())}).toPromise();
  }
  public getOrderDeliveredAsync(date: Date): Promise<OrderWithEmail[]> {
    return this.http.get<OrderWithEmail[]>('https://localhost:44376/order/date/delivered', {params:new HttpParams().append(
      'date',date.toLocaleDateString())}).toPromise();
  }
  public getOrderByIdAsync(id:string): Promise<Order> {
    return this.http.get<Order>('https://localhost:44376/order/'+id).toPromise();
  }
  public getOrdersByUserIdAsync(id:string|undefined): Promise<Order[]> {
    return this.http.get<Order[]>('https://localhost:44376/order/user/'+id).toPromise();
  }
  public updateOrderAsync(order:Order): Promise<any> {
    return this.http.put('https://localhost:44376/order/'+order.id, order).toPromise();
  }
  public createOrderAsync(order:Order): Promise<any> {

    return this.http.post('https://localhost:44376/order', order).toPromise();
  }
  public deleteOrderAsync(id: string | undefined): Promise<any> {
    return this.http.delete('https://localhost:44376/order/'+id).toPromise();
  }
  public deleteDepotAsync(id: string | undefined): Promise<any> {
    return this.http.delete('https://localhost:44376/depot/'+id).toPromise();
  }
  public deleteVehicleAsync(id: string | undefined): Promise<any> {
    return this.http.delete('https://localhost:44376/vehicle/'+id).toPromise();
  }
}

