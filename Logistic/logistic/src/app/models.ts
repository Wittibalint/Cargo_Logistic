export type Depot = {
    id? : number,
    locationX: number,
    locationY: number,
    address:string,
    vehicles?:[Vehicle]
}

export type Vehicle = {
    id?: number,
    speed:number,
    maxSize:number,
    maxWeight:number,
    depotId?:number,
    licensePlate:string
}

export type Order = {
    id?: number,
    transportFrom: string,
    transportTo:string,
    transportFromX:number,
    transportFromY:number,
    transportToX:number,
    transportToY:number,
    registryDate?:Date,
    shippingDate:Date,
    size:number,
    weight:number,
    vehicleId?:number,
    userId?:number,
    phoneNumber:string,
    delivered?:string,
    description:string
}
export type OrderWithEmail = {
    order:Order,
    email:string
}
export type User = {
    id?:number,
    email:string,
    name:string,
    password:string
}
