import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { PlotComponent } from './plot/plot.component';

const routes: Routes = [
  { path: '', redirectTo: '/plot', pathMatch: 'full' },
  { path: 'plot', component: PlotComponent },
  { path: 'list', component: ListComponent }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
