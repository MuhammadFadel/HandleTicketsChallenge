export interface Governorate {
  name: string,
  cities: City[]
}

export interface City {
  name: string,
  districts: district[]
}

export interface district {
  name: string
}
