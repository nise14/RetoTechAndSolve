import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { iobtenersupervisado } from 'src/app/modelos/iobtenersupervisado';
import { InsertarService } from 'src/app/servicios/insertar.service';

@Component({
  selector: 'app-insertar',
  templateUrl: './insertar.component.html',
  styleUrls: ['./insertar.component.css']
})
export class InsertarComponent implements OnInit {
  formulario: FormGroup;
  obtenerSupervisados: iobtenersupervisado[] = [];
  mensaje: string = "";
  selectedFile: File = null;
  habilitarDescargar:boolean = false;

  constructor(private formBuilder: FormBuilder,
    private insertarService: InsertarService) { }

  ngOnInit() {

    this.formulario = this.formBuilder.group({
      Cedula: ['', [Validators.required]],
      CargarArchivo: new FormControl(null)
    });
  }

  buscarCedula() {
    this.mensaje = "";

    this.insertarService.ObtenerSupervisado(this.getCedula.value).subscribe((r: iobtenersupervisado[]) => {
      this.obtenerSupervisados = r;
      this.mensaje = "";
      sessionStorage.setItem("cedula", "");
      if (r.length == 0) {
        this.mensaje = "No existen registros para la cédula que está consultando";
      } else {
        sessionStorage.setItem("cedula", this.getCedula.value);
      }
    });
  }

  CargarArchivo(event) {
    this.selectedFile = <File>event.target.files[0];

    if(this.selectedFile==undefined){
      this.habilitarDescargar=false;
    }
  }

  Descargar() {
    this.insertarService.Descargar().subscribe((data) => {

      var downloadURL = window.URL.createObjectURL(data);
      var link = document.createElement('a');
      link.href = downloadURL;
      link.download = "lazy_loading_example_output.txt";
      link.click();

    });
  }

  GuardarArchivo() {
    this.habilitarDescargar = false;
    this.insertarService.GuardarArchivo(this.selectedFile).subscribe(r => {
      this.habilitarDescargar = true;
    });
  }

  get getCedula() {
    return this.formulario.get("Cedula");
  }

  get getFile() {
    return this.formulario.get("CargarArchivo");
  }

}
