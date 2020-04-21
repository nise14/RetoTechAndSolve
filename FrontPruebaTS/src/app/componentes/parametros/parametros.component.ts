import { Component, OnInit } from '@angular/core';
import { ParametrosService } from 'src/app/servicios/parametros.service';
import { iparametros } from 'src/app/modelos/iparametros';

@Component({
  selector: 'app-parametros',
  templateUrl: './parametros.component.html',
  styleUrls: ['./parametros.component.css']
})
export class ParametrosComponent implements OnInit {

  parametros: iparametros[] = [];

  constructor(private parametrosService: ParametrosService) { }

  ngOnInit() {

    this.ReiniciarParametros();
    this.ObtenerParametros();
  }

  ObtenerParametros() {
    this.parametrosService.ObtenerParametros().subscribe((parametros: iparametros[]) => {
      this.parametros = parametros;
    });
  }

  ReiniciarParametros() {
    this.parametrosService.ReiniciarParametros().subscribe(r => r);
  }
}
