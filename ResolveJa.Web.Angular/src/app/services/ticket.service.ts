import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http: HttpClient) { }

  getSearch(cpf: string, urlEmpresa: string) {

    let params = new HttpParams();
    params.set('cpf', cpf);
    params.set('urlEmpresa', urlEmpresa);
  }
}
