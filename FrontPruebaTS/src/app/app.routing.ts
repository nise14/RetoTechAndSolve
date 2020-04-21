import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { ParametrosComponent } from './componentes/parametros/parametros.component';
import { InsertarComponent } from './componentes/insertar/insertar.component';

export const appRoutes: Routes = [
    {
        path:'parametros',
        component:ParametrosComponent
    },
    {
        path:"insertar",
        component:InsertarComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, {useHash: true })],
    exports: [RouterModule]
})
export class AppRoutingProviders { }     