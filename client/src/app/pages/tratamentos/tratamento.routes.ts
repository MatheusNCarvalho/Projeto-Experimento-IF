import { Routes } from "@angular/router";
import { ListaTratamentosComponent } from './lista-tratamentos/lista-tratamentos.component';
import { TratamentoComponent } from "./tratamento.component";


export const tratamentoRouterConfig: Routes = [
  {
    path: '', component: TratamentoComponent,
    children: [
      { path: '', component: ListaTratamentosComponent }
    ]
  }

];