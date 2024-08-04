import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Empresa } from '../models/empresa.model';
import { API_CONFIG } from '../config/api.config';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  constructor(private http: HttpClient) { }

  getByUrl(url: string): Observable<Empresa> {
    return this.http.get<Empresa>(`${API_CONFIG.baseUrl}/api/Empresas/${url}`);
  }
}
