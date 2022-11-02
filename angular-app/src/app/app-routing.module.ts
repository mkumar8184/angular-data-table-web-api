import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DatatableExampleComponent } from './datatable-example/datatable-example.component';

const routes: Routes = [{
  path: '',
  component: DatatableExampleComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
