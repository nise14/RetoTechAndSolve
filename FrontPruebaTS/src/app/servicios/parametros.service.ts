import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Constantes } from '../modelos/constantes';
import { Observable } from 'rxjs';
import { iparametros } from '../modelos/iparametros';

@Injectable({
  providedIn: 'root'
})
export class ParametrosService {

  header: HttpHeaders = Constantes.Header;
  constantes:Constantes=new Constantes();

  constructor(private httpClient: HttpClient) { }

  ObtenerParametros(): Observable<any>{
    let header = this.header;

    return this.httpClient.get(`${this.constantes.HTTP}/Parametros/ObtenerParametros`,
      { headers: header });
  }

  ReiniciarParametros(): Observable<any>{
    let header = this.header;

    return this.httpClient.get(`${this.constantes.HTTP}/Parametros/ReiniciarParametros`,
      { headers: header });
  }
}
