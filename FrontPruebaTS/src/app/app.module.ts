import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';

import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http';
import { ParametrosComponent } from './componentes/parametros/parametros.component';
import { AppconfigService } from './servicios/appconfig.service';
import { AppRoutingProviders } from './app.routing';
import { MenuComponent } from './componentes/menu/menu.component';
import { InsertarComponent } from './componentes/insertar/insertar.component';

export function get_settings(appLoadService: AppconfigService) {
  return () => appLoadService.load();
}

@NgModule({
  declarations: [
    AppComponent,
    ParametrosComponent,
    MenuComponent,
    InsertarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingProviders
  ],
  providers: [AppconfigService,
    { 
      provide: APP_INITIALIZER, 
      useFactory: get_settings, 
      deps: [AppconfigService], 
      multi: true }],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
