import { AppconfigService } from "../servicios/appconfig.service";
import { HttpHeaders } from "@angular/common/http";

export class Constantes {
    public HTTP: string;

    public static Header: HttpHeaders = new HttpHeaders(
        { 
            'Content-Type': 'application/JSON'
            
        });

        public static HeaderFile: HttpHeaders = new HttpHeaders(
            { 
                'Content-Type': 'text/plain'
                
            });

    constructor(){
        this.HTTP = AppconfigService.instance.getConfig("HTTP");
    }
}