export interface Ticket {
  id: number;
  phoneNumber: string;
  governorate: string;
  city: string;
  district: string;
  createdDate: Date;
  status: boolean;
}
