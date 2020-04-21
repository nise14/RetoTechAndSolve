import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Constantes } from '../modelos/constantes';

@Injectable({
  providedIn: 'root'
})
export class InsertarService {
  header: HttpHeaders = Constantes.Header;
  headerFile:HttpHeaders = Constantes.HeaderFile;

  constantes: Constantes = new Constantes();

  constructor(private httpClient: HttpClient) { }

  ObtenerSupervisado(cedula: number) {
    let header = this.header;

    return this.httpClient.get(`${this.constantes.HTTP}/supervisor/ObtenerSupervisado/${cedula}`,
      { headers: header })
  }

  GuardarArchivo(file: File) {
    let headerFile = this.headerFile;

    const input = new FormData();  
    input.append("nombre", file);  

    const headers = new HttpHeaders();
        headers.append('Content-Type', 'multipart/form-data');

    return this.httpClient.post(`${this.constantes.HTTP}/Viajes/GuardarArchivo`,input,{reportProgress: true, observe: 'events'});
  }

  Descargar(){
    return this.httpClient.get(`${this.constantes.HTTP}/Viajes/Descargar`, { responseType: 'blob' });
  }
}
