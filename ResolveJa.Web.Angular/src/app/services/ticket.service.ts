import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../models/ticket.model';
import { API_CONFIG } from '../config/api.config';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http: HttpClient) { }

  getSearch(cpf: string, urlEmpresa: string) {

    const params = new HttpParams().set('cpf', cpf).set('urlEmpresa', urlEmpresa);
    return this.http.get<Array<Ticket>>(`${API_CONFIG.baseUrl}/api/Tickets`, { params: params });
  }
}
