import { ListaTratamentosComponent } from './lista-tratamentos/lista-tratamentos.component';
import { NgModule } from "@angular/core";
import { RouterModule } from '@angular/router';
import { tratamentoRouterConfig } from './tratamento.routes';
import { TratamentoComponent } from './tratamento.component';


@NgModule({
  imports: [
    RouterModule.forChild(tratamentoRouterConfig)
  ],
  declarations: [
    ListaTratamentosComponent,
    TratamentoComponent
  ],
  exports: [
    RouterModule
  ]
})
export class TratamentoModule { }