import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppconfigService {
  private config: Object = null;
  static instance:AppconfigService;

  constructor(private httpClient: HttpClient) { 
    AppconfigService.instance=this;
  }

  public getConfig(key: any) {
    return this.config[key];
  }

  public load(): Promise<any> {
    let header:HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/JSON' });
    header = header.append("No-Auth", "True");

    const promise = this.httpClient.get('assets/config.json', { headers: header })
      .toPromise()
      .then(settings => {
        this.config = settings;
        return settings;
      });

    return promise;
  }
}
