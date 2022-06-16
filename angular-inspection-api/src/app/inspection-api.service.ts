import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {
  constructor(private http: HttpClient) { }

  getInspectionList(): Observable<any[]> {
    return this.http.get<any>(environment.inspectionAPIUrl + '/inspections');
  }

  addInspection(data: any) {
    return this.http.post(environment.inspectionAPIUrl + '/inspections', data);
  }

  updateInspection(id: number | string, data: any) {
    return this.http.put(environment.inspectionAPIUrl + `/inspections/${id}`, data);
  }

  deleteInspection(id: number | string) {
    return this.http.delete(environment.inspectionAPIUrl + `/inspections/${id}`);
  }

  // Inspection Types
  getInspectionTypesList(): Observable<any[]> {
    return this.http.get<any>(environment.inspectionAPIUrl + '/inspectionTypes');
  }

  addInspectionTypes(data: any) {
    return this.http.post(environment.inspectionAPIUrl + '/inspectionTypes', data);
  }

  updateInspectionTypes(id: number | string, data: any) {
    return this.http.put(environment.inspectionAPIUrl + `/inspectionTypes/${id}`, data);
  }

  deleteInspectionTypes(id: number | string) {
    return this.http.delete(environment.inspectionAPIUrl + `/inspectionTypes/${id}`);
  }

  // Statuses
  getStatusList(): Observable<any[]> {
    return this.http.get<any>(environment.inspectionAPIUrl + '/status');
  }

  addStatus(data: any) {
    return this.http.post(environment.inspectionAPIUrl + '/status', data);
  }

  updateStatus(id: number | string, data: any) {
    return this.http.put(environment.inspectionAPIUrl + `/status/${id}`, data);
  }

  deleteStatus(id: number | string) {
    return this.http.delete(environment.inspectionAPIUrl + `/status/${id}`);
  }
}